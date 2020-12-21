using System.Collections.Generic;
using System.Threading.Tasks;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class HUDSpriteFactory
    {
        private Texture2D HUDSpriteSheet;
        private HUDSpriteFrames hudSpriteFrames = new HUDSpriteFrames();
        private List<Rectangle> frames = new List<Rectangle>();

        private static HUDSpriteFactory instance = new HUDSpriteFactory();

        public static HUDSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDSpriteFactory() { }

        public async Task LoadAllTextures(ContentManager content)
        {
            HUDSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - HUD");
        }

        public async Task LoadAllTexturesAsync(ContentManager content)
        {
            HUDSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - HUD");
        }

        public BasicSprite CreateMinimap()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MinimapLayout"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMinimapTile()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MinimapTile"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMinimapBlack()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MinimapBlack"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMinimapTileTop()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MinimapTileTop"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }
        public BasicSprite CreateMinimapTileBottom()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MinimapTileBottom"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMinimapTileBoth()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MinimapTileBoth"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMap()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["Map"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapYellowSquare()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MapYellowSquare"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapClosed()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["Closed"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["RightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapLeftDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["LeftDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapLeftRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["LeftRightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapDownDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["DownDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapDownRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["DownRightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapDownLeftDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["DownLeftDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapDownLeftRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["DownLeftRightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapTopDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }
        public BasicSprite CreateMapTopRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopRightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }
        public BasicSprite CreateMapTopLeftDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopLeftDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }
        public BasicSprite CreateMapTopLeftRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopLeftRightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapTopDownDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopDownDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapTopDownRightDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopDownRightDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapTopDownLeftDoor()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["TopDownLeftDoor"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapAllDoors()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["AllDoors"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapGreenSquare()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["GreenSquare"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapWhiteSquare()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["WhiteSquare"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapBossLocation()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["RedSquare"],
                hudSpriteFrames.frames["NavySquare"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapBlueSquare()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["BlueSquare"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateHUDRupee()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["HUDRupee"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateHUDBomb()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["HUDBomb"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateHUDKey()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["HUDKey"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateBoomerang()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["Boomerang"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateBomb()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["Bomb"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateBow()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["Bow"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }
        public BasicSprite CreateSelectedItemChooser()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["SelectedItemFrameRed"],
                hudSpriteFrames.frames["SelectedItemFrameBlue"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateMapItem()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["MapItem"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

        public BasicSprite CreateCompassItem()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                hudSpriteFrames.frames["CompassItem"]
            };
            return new BasicSprite(HUDSpriteSheet, frames);
        }

    }
}
