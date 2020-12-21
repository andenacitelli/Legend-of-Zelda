using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class BossSpriteFactory
    {
        private Texture2D BossSpriteSheet;
        private readonly BossesSpriteFrames bossSpriteFrames = new BossesSpriteFrames();

        private static readonly BossSpriteFactory instance = new BossSpriteFactory();

        public static BossSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BossSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            BossSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Bosses");
        }
        public BasicSprite CreateAquamentus()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["AquamentusFrame1"],
                bossSpriteFrames.frames["AquamentusFrame2"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }

        public BasicSprite CreateAquamentusAttack()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["AquamentusFrame3"],
                bossSpriteFrames.frames["AquamentusFrame4"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }
        public BasicSprite CreateAquamentusFireball()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["AquamentusFireball1"],
                bossSpriteFrames.frames["AquamentusFireball2"],
                bossSpriteFrames.frames["AquamentusFireball3"],
                bossSpriteFrames.frames["AquamentusFireball4"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }
        public BasicSprite CreateDodongoDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["DodongoDownFrame1"],
                bossSpriteFrames.frames["DodongoDownFrame2"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }
        public BasicSprite CreateDodongoUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["DodongoUpFrame1"],
                bossSpriteFrames.frames["DodongoUpFrame2"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }
        public BasicSprite CreateDodongoRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["DodongoRightFrame1"],
                bossSpriteFrames.frames["DodongoRightFrame2"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }
        public BasicSprite CreateDodongoLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["DodongoRightFrame1"],
                bossSpriteFrames.frames["DodongoRightFrame2"]
            };
            return new BasicSprite(BossSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateDodongoCollisionRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["DodongoRightFrame3"]
            };
            return new BasicSprite(BossSpriteSheet, frames);
        }
        public BasicSprite CreateDodongoCollisionLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                bossSpriteFrames.frames["DodongoRightFrame3"]
            };
            return new BasicSprite(BossSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
    }
}
