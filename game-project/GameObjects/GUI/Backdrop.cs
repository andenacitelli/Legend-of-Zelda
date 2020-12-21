using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Writing;
using game_project.Levels;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace game_project.GameObjects.GUI
{
    public class Backdrop : Entity
    {
        public Minimap Minimap { get; }
        public Entity Bow { get; } = new HUDItem(HUDSpriteFactory.Instance.CreateBow(), new Vector2(680, 189), Constants.HUD_BOW_SCALE, false);

        public int CurrentItemSelectorIndex { get; set; } = 1;
        public int CurrentMaxItemCount { get; set; } = 2;
        public readonly List<Vector2> ItemSelectorPositions = new List<Vector2>()
        {
            new Vector2(508, 181),
            new Vector2(584, 181),
            new Vector2(660, 181),
            new Vector2(736, 181),
            new Vector2(812, 181)
        };
        public Backdrop()
        {

            Transform transform = GetComponent<Transform>();
            Constants.SetLayerDepth(this, Constants.LayerDepth.Backdrop);

            // get initial position at top of screen
            var viewport = Game1.viewport.Bounds;
            //transform.position.Y = -viewport.Height;// - Level.screen_height;
            transform.position.Y = -viewport.Height + (viewport.Height - Level.screen_height);

            // Blue boxes
            RectangleSprite smallBlueBox = new RectangleSprite(Color.Blue, new Rectangle(236, 173, 101, 104));
            AddComponent(smallBlueBox);
            RectangleSprite bigBlueBox = new RectangleSprite(Color.Blue, new Rectangle(492, 173, 388, 171));
            AddComponent(bigBlueBox);
            RectangleSprite itemBBlueBox = new RectangleSprite(Color.Blue, new Rectangle(492, 801, 69, 105));
            AddComponent(itemBBlueBox);
            RectangleSprite itemABlueBox = new RectangleSprite(Color.Blue, new Rectangle(588, 801, 69, 105));
            AddComponent(itemABlueBox);

            Texture2D blackRectangle = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            blackRectangle.SetData(new[] { Color.Black });
            List<Rectangle> frames = new List<Rectangle>()
            {
                new Rectangle(
                    0,
                    0,
                    (int)(viewport.Width/Constants.SPRITE_SCALAR),
                    (int)(viewport.Height/Constants.SPRITE_SCALAR + Constants.SCREEN_HEIGHT_OFFSET)
                ),
            };
            Sprite sprite = new Sprite(new BasicSprite(blackRectangle, frames));
            AddComponent(sprite);

            AddComponent(new BackdropBehavior());

            float textScale = 0.5f;
            int xOffset = 18;
            int yOffset = 18;
            int itemOffset = 32;
            List<TextEntity> texts = new List<TextEntity>()
            {
            new TextEntity(new Vector2(137, 92), "Inventory", Color.Red, textScale),
            new TextEntity(new Vector2(63, 292), "Use B Button", Color.White, textScale),
            new TextEntity(new Vector2(127, 326), "For This", Color.White, textScale),
            new TextEntity(new Vector2(159, 392), "Map", Color.Red, textScale),
            new TextEntity(new Vector2(96, 556), "Compass", Color.Red, textScale),
            new TextEntity(new Vector2(68, 720), "Level-1", Color.White, textScale),
            new TextEntity(new Vector2(733, 785), "- Life -", Color.Red, textScale),
            new TextEntity(new Vector2(492 + xOffset, 801 - yOffset), "B", Color.White, textScale),
            new TextEntity(new Vector2(588 + xOffset, 801 - yOffset), "A", Color.White, textScale),
            new TextEntity(new Vector2(680, 720), "XP:", Color.Green, textScale),
            new TextEntity(new Vector2(885, 720), "/", Color.Green, textScale),
            new TextEntity(new Vector2(920, 720), Constants.MAX_XP.ToString(), Color.Green, textScale),
            new HUDTextRupee(new Vector2(400, 801 - yOffset), "X", Color.White, textScale),
            new HUDTextKey(new Vector2(400, 801 - yOffset + itemOffset * 2), "X", Color.White, textScale),
            new HUDTextBomb(new Vector2(400, 801 - yOffset + itemOffset * 3), "X", Color.White, textScale),
            // boss rush only
            new HUDTextBossRush(new Vector2(68, 790), "X", Color.White, textScale)
            };

            foreach (var t in texts)
            {
                transform.AddChild(t);
                Scene.Add(t);
            }

            // ToDo: add a "Manual" Sprite drawing mode so I can add the blue lines.
            List<Entity> sprites = new List<Entity>()
            {
            new HUDItem(HUDSpriteFactory.Instance.CreateHUDRupee(), new Vector2(350, 801 - yOffset)),
            new HUDItem(HUDSpriteFactory.Instance.CreateHUDKey(), new Vector2(350, 801 - yOffset + itemOffset * 2)),
            new HUDItem(HUDSpriteFactory.Instance.CreateHUDBomb(), new Vector2(350, 801 - yOffset + itemOffset * 3)),
            new HUDMap(new Vector2(191, 440)),
            new HUDCompass(new Vector2(175, 600)),
            new HUDItem(HUDSpriteFactory.Instance.CreateBoomerang(), new Vector2(524, 189), Constants.HUD_BOOMERANG_SCALE),
            new HUDItem(HUDSpriteFactory.Instance.CreateBomb(), new Vector2(600, 189), Constants.HUD_BOMB_SCALE),
            Bow,
            new SelectedItem(new Vector2(260, 181)),
            new ItemSelector(ItemSelectorPositions[CurrentItemSelectorIndex]),
            new SelectedItem(new Vector2(500, 820)),
            new SelectedWeapon(new Vector2(607, 825))
            };

            foreach (var s in sprites)
            {
                transform.AddChild(s);
                Scene.Add(s);
            }

            // Hearts
            var hearts = new List<Heart>();
            AddComponent(new HeartDisplayManager(hearts, new Vector2(710, 880), this));

            // Xp
            AddComponent(new XPDisplayManager(new Vector2(780, 15)));

            // Map
            var map = new Map();
            transform.AddChild(map);

            Minimap = new Minimap(new Vector2(68, 776), false);
            transform.AddChild(Minimap);
        }
    }
}
