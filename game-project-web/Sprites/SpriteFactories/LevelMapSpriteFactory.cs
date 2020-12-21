using System.Collections.Generic;
using game_project.Sprites;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class LevelMapSpriteFactory
    {
        private Texture2D TileSpriteSheet;
        private readonly LevelMapSpriteFrames tileSpriteFrames = new LevelMapSpriteFrames();

        private static readonly LevelMapSpriteFactory instance = new LevelMapSpriteFactory();

        public static LevelMapSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LevelMapSpriteFactory() { }

        public async Task LoadAllTextures(ContentManager content)
        {
            TileSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
        }
        public async Task LoadAllTexturesAsync(ContentManager content)
        {
            TileSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
        }

        public BasicSprite CreateExterior()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["Exterior"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        // Doors
        public BasicSprite CreateTopWall()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TopWall"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTopOpen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TopOpen"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTopLock()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TopLock"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTopBoss()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TopBoss"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTopHole()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TopHole"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateLeftWall()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["LeftWall"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateLeftOpen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["LeftOpen"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateLeftLock()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["LeftLock"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateLeftBoss()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["LeftBoss"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateLeftHole()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["LeftHole"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRightWall()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RightWall"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRightOpen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RightOpen"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRightLock()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RightLock"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRightBoss()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RightBoss"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRightHole()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RightHole"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateDownWall()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["DownWall"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateDownOpen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["DownOpen"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateDownLock()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["DownLock"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateDownBoss()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["DownBoss"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateDownHole()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["DownHole"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        // tiles
        public BasicSprite CreateTileBasic()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileBasic"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileRaised()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileRaised"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateStatueFace()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileStatueFace"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateStatueDragon()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileStatueDragon"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }

        public BasicSprite CreateBlueStatueFace()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileBlueStatueFace"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateBlueStatueDragon()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileBlueStatueDragon"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileBlack()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileBlack"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileSand()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileSand"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileNavy()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileNavy"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileBlue()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileBlue"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileStairs()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileStairs"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileBlackBricks()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileBlackBricks"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileWhiteStripes()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileWhiteStripes"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateTileInvis()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["TileInvis"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        // rooms
        public BasicSprite CreateRoomItem()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomItem"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRoomDungeon()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomDungeon"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        // interiors
        public BasicSprite CreateRoomEntrance()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomEntrance"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRoomEmpty()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomBlankFloor"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRoomBlack()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomBlack"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRoomWaterMaze()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomWaterMaze"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRoomWaterHourglass()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomWaterHourglass"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
        public BasicSprite CreateRoomBlocksRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                tileSpriteFrames.frames["RoomRightBlock"]
            };
            return new BasicSprite(TileSpriteSheet, frames);
        }
    }
}
