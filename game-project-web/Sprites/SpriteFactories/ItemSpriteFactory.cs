using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class ItemSpriteFactory
    {
        private Texture2D ItemSpriteSheet;
        private ItemSpriteFrames itemSpriteFrames = new ItemSpriteFrames();
        private List<Rectangle> frames = new List<Rectangle>();

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory() { }

        public async Task LoadAllTextures(ContentManager content)
        {
            ItemSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
        }

        public async Task LoadAllTexturesAsync(ContentManager content)
        {
            ItemSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
        }

        public BasicSprite CreateHeartFull()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["HeartFull"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateHeartHalf()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["HeartHalfFull"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateHeartEmpty()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["HeartEmpty"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateHeartContainer()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["HeartContainer"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateFairy()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["FairyFrame1"],
                itemSpriteFrames.frames["FairyFrame2"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateClock()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Clock"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateRupee()
        {
            // rupee flashes colors
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["RupeeYellow"],
                itemSpriteFrames.frames["RupeeBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateRedPotion()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["PotionRed"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBluePotion()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["PotionBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateYellowMap()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["MapYellow"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBlueMap()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["MapBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateCandy()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Candy"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBrownBoomerang()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["BoomerangBrown"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBomb()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Bomb"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBow()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Bow"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateRedArrow()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["ArrowRed"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBlueArrow()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["ArrowBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateRedCandle()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["CandleRed"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBlueCandle()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["CandleBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateRedRing()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["RingRed"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBlueRing()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["RingBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBridge()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Bridge"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateLadder()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Ladder"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateRegularKey()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["KeyRegular"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateBossKey()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["KeyBoss"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateCompass()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["Compass"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
        public BasicSprite CreateTriforce()
        {
            // triforce flashes colors
            List<Rectangle> frames = new List<Rectangle>
            {
                itemSpriteFrames.frames["TriforceYellow"],
                itemSpriteFrames.frames["TriforceBlue"]
            };
            return new BasicSprite(ItemSpriteSheet, frames);
        }
    }
}
