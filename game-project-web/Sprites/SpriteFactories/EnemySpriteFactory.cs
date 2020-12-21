using System.Collections.Generic;
using System.Threading.Tasks;
using game_project.Sprites;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class EnemySpriteFactory
    {
        private Texture2D EnemySpriteSheet;
        private readonly EnemySpriteFrames enemySpriteFrames = new EnemySpriteFrames();

        private static readonly EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory() { }

        public async Task LoadAllTextures(ContentManager content)
        {
            EnemySpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies");
        }
        public async Task LoadAllTexturesAsync(ContentManager content)
        {
            EnemySpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies");
        }

        public BasicSprite CreateStalfo()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["Stalfos"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateStalfoFlipped()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["Stalfos"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }

        public BasicSprite CreateRopeRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["RopeFrame1"],
                enemySpriteFrames.frames["RopeFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateRopeLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["RopeFrame1"],
                enemySpriteFrames.frames["RopeFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateBladeTrap()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["BladeTrap"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }

        public BasicSprite CreateWallMasterRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["WallmasterFrame1"],
                enemySpriteFrames.frames["WallmasterFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateWallMasterLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["WallmasterFrame1"],
                enemySpriteFrames.frames["WallmasterFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }

        public BasicSprite CreateWallMasterDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["WallmasterFrame1"],
                enemySpriteFrames.frames["WallmasterFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipVertically);
        }

        public BasicSprite CreateBlueKeese()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["KeeseBlueFrame1"],
                enemySpriteFrames.frames["KeeseBlueFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateRedKeese()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["KeeseRedFrame1"],
                enemySpriteFrames.frames["KeeseRedFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateRedGoriyaDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaRedDown"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }

        public BasicSprite CreateRedGoriyaDownFlipped()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                // not sure how to flip this every frame. Might have to do that in the animation portion. 
                enemySpriteFrames.frames["GoriyaRedDown"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }

        public BasicSprite CreateRedGoriyaUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaRedUp"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }

        public BasicSprite CreateRedGoriyaUpFlipped()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaRedUp"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }

        public BasicSprite CreateRedGoriyaRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaRedRightFrame1"],
                enemySpriteFrames.frames["GoriyaRedRightFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateRedGoriyaLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaRedRightFrame1"],
                enemySpriteFrames.frames["GoriyaRedRightFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateBlueGoriyaDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaBlueDown"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }

        public BasicSprite CreateBlueGoriyaDownFlipped()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                // not sure how to flip this every frame. Might have to do that in the animation portion. 
                enemySpriteFrames.frames["GoriyaBlueDown"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }

        public BasicSprite CreateBlueGoriyaUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaBlueUp"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }

        public BasicSprite CreateBlueGoriyaUpFlipped()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                // not sure how to flip this every frame. Might have to do that in the animation portion. 
                enemySpriteFrames.frames["GoriyaBlueUp"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }

        public BasicSprite CreateBlueGoriyaRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaBlueRightFrame1"],
                enemySpriteFrames.frames["GoriyaBlueRightFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateBlueGoriyaLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GoriyaBlueRightFrame1"],
                enemySpriteFrames.frames["GoriyaBlueRightFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateGoriyaBoomerang()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["BoomerangLR"],
                enemySpriteFrames.frames["Boomerang45"],
                enemySpriteFrames.frames["BoomerangUD"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateGelNavy()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GelNavyFrame1"],
                enemySpriteFrames.frames["GelNavyFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateGelBlue()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GelBlueFrame1"],
                enemySpriteFrames.frames["GelBlueFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateGelGreen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GelGreenFrame1"],
                enemySpriteFrames.frames["GelGreenFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateGelBlackGold()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GelBlackGoldFrame1"],
                enemySpriteFrames.frames["GelBlackGoldFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateGelEmerald()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GelEmeraldFrame1"],
                enemySpriteFrames.frames["GelEmeraldFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateGelBlackSilver()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["GelBlackSilverFrame1"],
                enemySpriteFrames.frames["GelBlackSilverFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateZolGreen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["ZolGreenFrame1"],
                enemySpriteFrames.frames["ZolGreenFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateZolBlackGold()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["ZolBlackGoldFrame1"],
                enemySpriteFrames.frames["ZolBlackGoldFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateZolEmerald()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["ZolEmeraldFrame1"],
                enemySpriteFrames.frames["ZolEmeraldFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateZolBrown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["ZolBrownFrame1"],
                enemySpriteFrames.frames["ZolBrownFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
        public BasicSprite CreateZolBlackSilver()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                enemySpriteFrames.frames["ZolBlackSilverFrame1"],
                enemySpriteFrames.frames["ZolBlackSilverFrame2"]
            };
            return new BasicSprite(EnemySpriteSheet, frames);
        }
    }
}
