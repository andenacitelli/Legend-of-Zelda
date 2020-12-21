using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace game_project.Content.Sprites
{
    class BossesSpriteFrames
    {
        public Dictionary<string, Rectangle> frames;
        public BossesSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // aquamentus
            frames.Add("AquamentusFrame1", new Rectangle(1, 11, 24, 32));
            frames.Add("AquamentusFrame2", new Rectangle(26, 11, 24, 32));
            frames.Add("AquamentusFrame3", new Rectangle(51, 11, 24, 32));
            frames.Add("AquamentusFrame4", new Rectangle(76, 11, 24, 32));
            // aquamentus fireball
            frames.Add("AquamentusFireball1", new Rectangle(101, 14, 8, 10));
            frames.Add("AquamentusFireball2", new Rectangle(110, 14, 8, 10));
            frames.Add("AquamentusFireball3", new Rectangle(119, 14, 8, 10));
            frames.Add("AquamentusFireball4", new Rectangle(128, 14, 8, 10));
            // dodongo
            frames.Add("DodongoDownFrame1", new Rectangle(1, 58, 15, 16));
            frames.Add("DodongoDownFrame2", new Rectangle(18, 58, 16, 16));
            frames.Add("DodongoUpFrame1", new Rectangle(35, 58, 15, 16));
            frames.Add("DodongoUpFrame2", new Rectangle(52, 58, 16, 16));
            frames.Add("DodongoRightFrame1", new Rectangle(69, 59, 28, 15));
            frames.Add("DodongoRightFrame2", new Rectangle(102, 58, 28, 16));
            frames.Add("DodongoRightFrame3", new Rectangle(135, 58, 32, 16));

        }
    }
}
