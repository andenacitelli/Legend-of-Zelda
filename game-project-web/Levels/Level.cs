using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.ECS.Systems;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Items;
using game_project.GameObjects.Block;
using game_project.GameObjects.Link;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using game_project.Sounds;
using game_project.GameObjects.Writing;
using Bridge;

namespace game_project.Levels
{
    public class Level
    {
        public static readonly float screen_width, screen_height;
        private static readonly float horiz_grid_units, vert_grid_units;
        private static readonly float pixels_per_grid_x, pixels_per_grid_y;

        // Needed so we don't need switch statements in switch statements
        private static readonly Dictionary<string, int> enemyMap = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> itemMap = new Dictionary<string, int>();

        // Keep a list of entities associated with this level so the level can be destroyed later
        public Entity Root = new Entity();


        // Valid Levels so we don't Load a file that doesn't exist
        public static List<string> ValidLevels = new List<string>()
        {
            "0_0",
            "0_2",
            "1_0",
            "1_2",
            "1_3",
            "1_5",
            "2_0",
            "2_1",
            "2_2",
            "2_3",
            "2_4",
            "2_5",
            "3_2",
            "3_3",
            "3_5",
            "4_1",
            "4_2",
            "5_1",
        };

        // Static constructor only runs for first instance of object
        static Level()
        {
            // TODO: Actually calculate these. 800x480 is the default screen size (in px); 16x10.5 is grid units we approximated from gameplay videos.
            screen_width = Game1.viewport.Width;
            screen_height = Game1.viewport.Height * Constants.SCREEN_HEIGHT_MULTIPLICATIVE_RATIO + Constants.SCREEN_HEIGHT_OFFSET;
            horiz_grid_units = Constants.HORIZ_GRID_UNITS;
            vert_grid_units = Constants.VERT_GRID_UNITS;
            pixels_per_grid_x = screen_width / horiz_grid_units;
            pixels_per_grid_y = screen_height / vert_grid_units;

            // Populate enemy-related map with values
            enemyMap.Add("aquamentus", 0);
            enemyMap.Add("bladetrap", 1);
            enemyMap.Add("gel", 2);
            //enemyMap.Add("goriya", 3);
            enemyMap.Add("keese", 4);
            enemyMap.Add("rope", 5);
            enemyMap.Add("stalfo", 6);
            enemyMap.Add("wallmaster", 7);

            // TODO: Populate item-related map with values. I don't think we've really implemented items all the way so this can come later.
            enemyMap.Add("noitem", 0);
        }

        // Normal constructor runs for every instance of object
        public Level(string csvFilePath)
        {
            Bridge.Utils.Console.Log("loading level " + csvFilePath);
            // add all Entities in this Level to a common parent
            var transform = Root.GetComponent<Transform>();
            Root.name = csvFilePath;


            string basePath = @"../../../../Content/Maps/";
#if WEB
            basePath = "Content/Maps/";
#endif
            string[] lines = System.IO.File.ReadAllLines(basePath + csvFilePath + ".csv");

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i][0].ToString() != "#")
                {
                    var e = HandleCSVRow(lines[i].Split(','));
                    if (e != null)
                    {
                        transform.AddChild(e);
                    }
                }
            }

            Bridge.Utils.Console.Log("loaded level " + csvFilePath);

            Scene.Add(Root);

            // adjust relative position of this room off of "2_5"
            var split = csvFilePath.Split('_');
            int x = Int16.Parse(split[0]);
            int y = Int16.Parse(split[1]);
            x -= 2;
            y -= 5;
            float X = x * screen_width;
            float Y = y * screen_height;

            transform.position = new Vector2(X, Y);

            //return;
        }

        public void Destroy()
        {
            foreach (var transform in Root.GetComponent<Transform>().Children)
            {
                Entity entity = transform.entity;
                if (entity != null)
                {
                    Entity.Destroy(entity);
                }
            }
            Root.GetComponent<Transform>().Children.Clear();
            TransformSystem.CleanUp();
            ColliderSystem.CleanUp();
            BehaviorScriptSystem.CleanUp();
            SpriteSystem.CleanUp();
        }

        // Takes in a Split() row from the CSV file. Renders it on the screen.
        private Entity HandleCSVRow(string[] line)
        {
            // Parse grid units into pixel units, then add offset
            // Row 0 = Entity Name, 1 = grid_x, 2 = grid_y, 3 = x_offset, 4 = y_offset. Anything further is entity-specific parameters.
            // NOTE: By personal convention, everything except for pos is passed in as strings and parsed inside the function itself.
            Vector2 pos = new Vector2(float.Parse(line[1]) * pixels_per_grid_x + float.Parse(line[3]), float.Parse(line[2]) * pixels_per_grid_y + float.Parse(line[4]));
            pos.Y += Game1.viewport.Height * 0.23f;

            // The Entity described by this row
            Entity entity;

            //Bridge.Utils.Console.Log("handling " + line[0]);

            switch (line[0])
            {
                case "block":
                    entity = LoadBlock(pos, line[5], line[6]);
                    break;
                case "item":
                    entity = LoadItem(pos, line[5], line[6]);
                    break;
                case "enemy":
                    entity = LoadEnemy(pos, line[5], line[6], line[7]);
                    break;
                case "npc":
                    entity = LoadNPC(pos, line[5]);
                    break;
                case "text":
                    entity = LoadText(pos, line[5], line[6]);
                    break;
                default:
                    Console.WriteLine("Level @ HandleCSVRow(): Unrecognized entity \"" + line[0] + "\"!");
                    return null;
            }

            return entity;
        }

        private Entity LoadText(Vector2 pos, string stringToWrite, string animate)
        {
            float scale = Constants.HUD_TEXT_SCALE;
            TextEntity text = new TextEntity(pos, stringToWrite, null, scale, bool.Parse(animate));
            var textComp = text.GetComponent<Text>();
            textComp.textBox = new Rectangle((int)pos.X, (int)pos.Y, Constants.DUNGEON_NPC_TEXT_WIDTH, Constants.DUNGEON_NPC_TEXT_HEIGHT);
            Scene.Add(text);
            return text;
        }

        private Entity LoadBlock(Vector2 pos, string collisionType, string blocktype)
        {
            Block block;
            switch (blocktype)
            {
                case "walls":
                    block = new Wall(LevelMapSpriteFactory.Instance.CreateExterior(), pos);
                    Constants.SetLayerDepth(block, Constants.LayerDepth.Room);
                    break;
                case "entrance":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateRoomEntrance(), pos);
                    Constants.SetLayerDepth(block, Constants.LayerDepth.Room);
                    break;
                case "empty":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateRoomEmpty(), pos);
                    Constants.SetLayerDepth(block, Constants.LayerDepth.Room);
                    break;
                case "black":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateRoomBlack(), pos);
                    Constants.SetLayerDepth(block, Constants.LayerDepth.Room);
                    break;
                case "itemroom":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateRoomItem(), pos);
                    Constants.SetLayerDepth(block, Constants.LayerDepth.Room);
                    break;
                case "downdoor":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateDownOpen(), pos);
                    break;
                case "leftdoor":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateLeftOpen(), pos);
                    break;
                case "rightdoor":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateRightOpen(), pos);
                    break;
                case "updoor":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateTopOpen(), pos);
                    break;
                case "downwall":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateDownWall(), pos, Door.Type.Wall);
                    break;
                case "leftwall":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateLeftWall(), pos, Door.Type.Wall);
                    break;
                case "rightwall":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateRightWall(), pos, Door.Type.Wall);
                    break;
                case "upwall":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateTopWall(), pos, Door.Type.Wall);
                    break;
                case "downlock":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateDownLock(), pos, Door.Type.Locked);
                    break;
                case "leftlock":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateLeftLock(), pos, Door.Type.Locked);
                    break;
                case "rightlock":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateRightLock(), pos, Door.Type.Locked);
                    break;
                case "uplock":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateTopLock(), pos, Door.Type.Locked);
                    break;
                case "downbomb":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateDownWall(), pos, Door.Type.BombWall);
                    break;
                case "leftbomb":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateLeftWall(), pos, Door.Type.BombWall);
                    break;
                case "rightbomb":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateRightWall(), pos, Door.Type.BombWall);
                    break;
                case "upbomb":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateTopWall(), pos, Door.Type.BombWall);
                    break;
                case "downboss":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateDownBoss(), pos, Door.Type.Locked);
                    break;
                case "leftboss":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateLeftBoss(), pos, Door.Type.Locked);
                    block.name = "boss_door";
                    break;
                case "rightboss":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateRightBoss(), pos, Door.Type.Locked);
                    break;
                case "upboss":
                    block = new Door(LevelMapSpriteFactory.Instance.CreateTopBoss(), pos, Door.Type.Locked);
                    break;
                case "statuedragon":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateStatueDragon(), pos);
                    break;
                case "statueface":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateStatueFace(), pos);
                    break;
                case "bluestatuedragon":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateBlueStatueDragon(), pos);
                    break;
                case "bluestatueface":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateBlueStatueFace(), pos);
                    break;
                case "raisedtile":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateTileRaised(), pos);
                    break;
                case "stairs":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateTileStairs(), pos);
                    break;
                case "navytile":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateTileNavy(), pos);
                    break;
                case "water":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateTileBlue(), pos);
                    break;
                case "invis":
                    block = new Block(LevelMapSpriteFactory.Instance.CreateTileInvis(), pos);
                    break;
                default:
                    Console.WriteLine("Level @ LoadBlock(): Unrecognized blocktype \"" + blocktype + "\"!");
                    return null;
            }

            // TODO: Slowly but surely we should create classes for each general type
            // of block (Door, Wall, MovableBlock, etc.) to avoid this collision logic.
            var coll = new Collider();
            switch (collisionType)
            {
                case "movableU":
                    coll.response = new MovableCollisionResponse(block, Constants.Direction.UP);
                    break;
                case "movableD":
                    coll.response = new MovableCollisionResponse(block, Constants.Direction.DOWN);
                    break;
                case "movableL":
                    coll.response = new MovableCollisionResponse(block, Constants.Direction.LEFT);
                    break;
                case "movableR":
                    coll.response = new MovableCollisionResponse(block, Constants.Direction.RIGHT);
                    break;
                case "movableRK":
                    coll.response = new MovableKeyCollisionResponse(block, Constants.Direction.RIGHT, Root.name);
                    break;
                case "rigid":
                    coll.response = new RigidCollisionResponse(block);
                    break;
                //case "door":
                //    coll.response = new DoorCollisionResponse(block);
                //    break;
                case "invis":
                    coll.response = new InvisibleBlockCollisionResponse(block);
                    break;
                case "stairs00":
                    coll.response = new StairsCollisionResponse(block, "0_0");
                    break;
                case "stairs10":
                    coll.response = new StairsCollisionResponse(block, "1_0");
                    break;
                case "wall":
                    // Already handled
                    break;
                case "none":
                    // no collision necessary
                    break;
                default:
                    //coll.response = new BaseCollisionResponse(block);
                    break;
            }
            block.AddComponent(coll);

            Scene.Add(block);
            return block;
        }

        private Entity LoadItem(Vector2 pos, string itemType, string collisionType = "none")
        {
            Item entity = null;
            // TODO: This just instantiates with different sprites. We will want to add actual functionality to some of these at a later point in time.
            switch (itemType)
            {
                case "heartfull":
                    entity = new Item(ItemSpriteFactory.Instance.CreateHeartFull(), pos);
                    break;
                case "hearthalf":
                    entity = new Item(ItemSpriteFactory.Instance.CreateHeartHalf(), pos);
                    break;
                case "heartempty":
                    entity = new Item(ItemSpriteFactory.Instance.CreateHeartEmpty(), pos);
                    break;
                case "heartContainer":
                    entity = new Item(ItemSpriteFactory.Instance.CreateHeartContainer(), pos);
                    break;
                case "fairy":
                    entity = new Item(ItemSpriteFactory.Instance.CreateFairy(), pos);
                    break;
                case "clock":
                    entity = new Item(ItemSpriteFactory.Instance.CreateClock(), pos);
                    break;
                case "rupee":
                    entity = new Item(ItemSpriteFactory.Instance.CreateRupee(), pos);
                    break;
                case "redpotion":
                    entity = new Item(ItemSpriteFactory.Instance.CreateRedPotion(), pos);
                    break;
                case "bluepotion":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBluePotion(), pos);
                    break;
                case "yellowmap":
                    entity = new Item(ItemSpriteFactory.Instance.CreateYellowMap(), pos);
                    break;
                case "bluemap":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBlueMap(), pos);
                    break;
                case "candy":
                    entity = new Item(ItemSpriteFactory.Instance.CreateCandy(), pos);
                    break;
                case "brownboomerang":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBrownBoomerang(), pos);
                    break;
                case "bomb":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBomb(), pos);
                    break;
                case "bow":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBow(), pos);
                    break;
                case "redarrow":
                    entity = new Item(ItemSpriteFactory.Instance.CreateRedArrow(), pos);
                    break;
                case "bluearrow":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBlueArrow(), pos);
                    break;
                case "redcandle":
                    entity = new Item(ItemSpriteFactory.Instance.CreateRedCandle(), pos);
                    break;
                case "bluecandle":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBlueCandle(), pos);
                    break;
                case "redring":
                    entity = new Item(ItemSpriteFactory.Instance.CreateRedRing(), pos);
                    break;
                case "bluering":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBlueRing(), pos);
                    break;
                case "bridge":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBridge(), pos);
                    break;
                case "ladder":
                    entity = new Item(ItemSpriteFactory.Instance.CreateLadder(), pos);
                    break;
                case "regularkey":
                    entity = new Item(ItemSpriteFactory.Instance.CreateRegularKey(), pos);
                    Sound.PlaySound(Sound.SoundEffects.Key_Appear, entity, !Sound.SOUND_LOOPS); // No better place to play this, seeing as we lose memory of what an item is after initialization
                    break;
                case "bosskey":
                    entity = new Item(ItemSpriteFactory.Instance.CreateBossKey(), pos);
                    Sound.PlaySound(Sound.SoundEffects.Key_Appear, entity, !Sound.SOUND_LOOPS); // No better place to play this, seeing as we lose memory of what an item is after initialization
                    break;
                case "compass":
                    entity = new Item(ItemSpriteFactory.Instance.CreateCompass(), pos);
                    break;
                case "triforce":
                    entity = new Item(ItemSpriteFactory.Instance.CreateTriforce(), pos);
                    entity.GetComponent<Sprite>().SetAnimate(true);
                    break;
                case "fire":
                    entity = new Item(LinkItemSpriteFactory.Instance.CreateFire(), pos);
                    entity.AddComponent(new FireStatePattern((Item)entity));
                    Scene.Add(new Poof(pos, entity));
                    break;
                default:
                    Console.WriteLine("Level @ LoadItem: Unrecognized itemType \"" + itemType + "\"!");
                    break;
            }
            entity.SetItemType(itemType);

            var coll = new Collider();
            switch (collisionType)
            {
                case "first":
                    coll.response = new FirstItemCollisionResponse(entity);
                    entity.AddComponent(new ItemDeletionTimer());
                    break;
                case "special":
                    coll.response = new SpecialItemCollisionResponse(entity);
                    entity.AddComponent(new ItemDeletionTimer());
                    break;
                case "hud":
                    coll.response = new ItemCollisionResponse(entity);
                    break;
                case "none":
                    // no collision necessary
                    break;
                default:
                    coll.response = new BaseCollisionResponse(entity);
                    break;
            }
            entity.AddComponent(coll);

            Scene.Add(entity);
            return entity;
        }

        private Entity LoadEnemy(Vector2 pos, string enemyType, string startDirection, string itemHeld)
        {
            Entity entity = null;
            // Parse direction (passed in as string) into Direction enumerable type
            Constants.Direction direction;
            switch (startDirection)
            {
                case "up":
                    direction = Constants.Direction.UP;
                    break;
                case "right":
                    direction = Constants.Direction.RIGHT;
                    break;
                case "down":
                    direction = Constants.Direction.DOWN;
                    break;
                case "left":
                    direction = Constants.Direction.LEFT;
                    break;
                default: // start direction not neccessary, default is right
                    direction = Constants.Direction.RIGHT;
                    break;
            }

            switch (enemyType)
            {
                case "aquamentus":
                    entity = new Aquamentus(pos);
                    break;
                case "bladetrap":
                    entity = new BladeTrap(pos);
                    break;
                case "gel":
                    entity = new Gel(pos);
                    break;
                //case "goriya":
                //    entity = new Goriya(pos);
                //    break;
                case "keese":
                    entity = new Keese(pos);
                    break;
                case "rope":
                    entity = new Rope(pos);
                    break;
                case "stalfo":
                    entity = new Stalfo(pos);
                    if (itemHeld == "regularkey")
                    {
                        entity.AddComponent(new Sprite(ItemSpriteFactory.Instance.CreateRegularKey()));
                        entity.GetComponent<StalfoMovement>().SetItemHeldTrue();
                    }
                    break;
                case "wallmaster":
                    entity = new WallMaster(pos, direction);
                    break;
                default:
                    Console.WriteLine("Level @ LoadEnemy(): Unrecognized enemyType \"" + enemyType + "\"!");
                    return null;
            }
            Scene.Add(entity);
            Scene.Add(new Poof(pos, entity));
            return entity;
        }

        public Link LoadPlayer(Vector2 pos)
        {
            Link entity = new Link(pos);
            Scene.Add(entity);
            return entity;
        }

        private Entity LoadNPC(Vector2 pos, string npcType)
        {
            Entity entity = null;
            switch (npcType)
            {
                case "oldman1":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateOldMan1(), pos);
                    break;
                case "oldman2":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateOldMan2(), pos);
                    break;
                case "oldwoman":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateOldWoman(), pos);
                    break;
                case "merchantgreen":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateMerchantGreen(), pos);
                    break;
                case "merchantwhite":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateMerchantWhite(), pos);
                    break;
                case "merchantred":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateMerchantRed(), pos);
                    break;
                case "circles":
                    entity = new NPC(NPCSpriteFactory.Instance.CreateCircles(), pos);
                    break;
                default:
                    Console.WriteLine("Level @ LoadNPC(): Unrecognized npcType!");
                    break;
            }
            Scene.Add(entity);
            Scene.Add(new Poof(pos, entity));
            return entity;

        }

        /* Function Inputs:
         * Universal: Vector2 (pixels)
         * Block: movable (boolean), collideable (boolean)
         * Item: itemType (string)
         * Enemy: enemyType, startDirection (Direction enum), itemHeld (string)
         * Player (Link):
         * NPC: npcType (string)
         * */
    }
}
