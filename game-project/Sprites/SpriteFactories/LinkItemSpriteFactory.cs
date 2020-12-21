using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class LinkItemSpriteFactory
    {
        private Texture2D LinkSpriteSheet;
        private readonly LinkItemSpriteFrames linkItemSpriteFrames = new LinkItemSpriteFrames();

        private static readonly LinkItemSpriteFactory instance = new LinkItemSpriteFactory();

        public static LinkItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkItemSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            LinkSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Link");
        }

        //public async Task LoadAllTexturesAsync(ContentManager content)
        //{
        //    LinkSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - Link");
        //}

        public BasicSprite CreateWoodenSwordUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WoodenSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWoodenSwordDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WoodenSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipVertically);
        }
        public BasicSprite CreateWoodenSwordRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WoodenSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWoodenSwordLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WoodenSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateWoodenSwordBeam()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WoodenSwordBeam"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWhiteBlueSwordUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteBlueSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWhiteBlueSwordDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteBlueSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipVertically);
        }
        public BasicSprite CreateWhiteBlueSwordRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteBlueSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWhiteBlueSwordLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteBlueSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateWhiteBlueSwordBeam()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteBlueSwordBeam"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWhiteRedSwordUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteRedSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWhiteRedSwordDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteRedSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipVertically);
        }
        public BasicSprite CreateWhiteRedSwordRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteRedSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateWhiteRedSwordLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteRedSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateWhiteRedSwordBeam()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["WhiteRedSwordBeam"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateRedSwordUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["RedSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateRedSwordDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["RedSwordUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipVertically);
        }
        public BasicSprite CreateRedSwordRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["RedSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateRedSwordLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["RedSwordRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateRedSwordBeam()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["RedSwordBeam"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateGreenArrowUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["GreenArrowUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateGreenArrowDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["GreenArrowUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipVertically);
        }
        public BasicSprite CreateGreenArrowRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["GreenArrowRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateGreenArrowLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["GreenArrowRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateBlueArrowUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["BlueArrowUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateBlueArrowDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["BlueArrowUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipVertically);
        }
        public BasicSprite CreateBlueArrowRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["BlueArrowRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateBlueArrowLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["BlueArrowRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateBoomerangWooden()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["BoomerangWoodenLR"],
                linkItemSpriteFrames.frames["BoomerangWooden45"],
                linkItemSpriteFrames.frames["BoomerangWoodenUD"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateBomb()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["Bomb"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateExplosionFull()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["ExplosionFull"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateExplosionHalf()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["ExplosionHalf"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateExplosionFinished()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["ExplosionFinished"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }

        public BasicSprite CreateExplosion()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["ExplosionFull"],
                linkItemSpriteFrames.frames["ExplosionHalf"],
                linkItemSpriteFrames.frames["ExplosionFinished"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateFire()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["Fire"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }

        public BasicSprite CreateFireFlipped()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkItemSpriteFrames.frames["Fire"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
    }
}
