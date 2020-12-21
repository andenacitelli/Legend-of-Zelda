using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace game_project.Content.Sprites
{
    class ItemSpriteFrames
    {
        public Dictionary<string, Rectangle> frames;
        public ItemSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // heart
            frames.Add("HeartFull", new Rectangle(0, 0, 7, 8));
            frames.Add("HeartHalfFull", new Rectangle(8, 0, 7, 8));
            frames.Add("HeartEmpty", new Rectangle(16, 0, 7, 8));
            // heart container
            frames.Add("HeartContainer", new Rectangle(25, 1, 13, 13));
            // fairy
            frames.Add("FairyFrame1", new Rectangle(40, 0, 8, 16));
            frames.Add("FairyFrame2", new Rectangle(48, 0, 8, 16));
            // clock
            frames.Add("Clock", new Rectangle(58, 0, 11, 16));
            // rupees
            frames.Add("RupeeYellow", new Rectangle(72, 0, 8, 16));
            frames.Add("RupeeBlue", new Rectangle(72, 16, 8, 16));
            // potions
            frames.Add("PotionRed", new Rectangle(80, 0, 8, 16));
            frames.Add("PotionBlue", new Rectangle(80, 16, 8, 16));
            // maps
            frames.Add("MapYellow", new Rectangle(88, 0, 8, 16));
            frames.Add("MapBlue", new Rectangle(88, 16, 8, 16));
            // candy
            frames.Add("Candy", new Rectangle(96, 0, 8, 16));
            // boomerang
            frames.Add("BoomerangBrown", new Rectangle(129, 3, 5, 8));
            // bomb
            frames.Add("Bomb", new Rectangle(136, 0, 8, 14));
            // bow
            frames.Add("Bow", new Rectangle(144, 0, 8, 16));
            // arrows
            frames.Add("ArrowRed", new Rectangle(154, 0, 5, 16));
            frames.Add("ArrowBlue", new Rectangle(154, 16, 5, 16));
            // candles
            frames.Add("CandleRed", new Rectangle(160, 0, 8, 16));
            frames.Add("CandleBlue", new Rectangle(160, 16, 8, 16));
            // rings
            frames.Add("RingRed", new Rectangle(169, 3, 7, 9));
            frames.Add("RingBlue", new Rectangle(169, 19, 7, 9));
            // bridge
            frames.Add("Bridge", new Rectangle(193, 0, 14, 16));
            // ladder
            frames.Add("Ladder", new Rectangle(208, 0, 16, 16));
            // keys
            frames.Add("KeyRegular", new Rectangle(240, 0, 8, 16));
            frames.Add("KeyBoss", new Rectangle(248, 0, 8, 16));
            // compass
            frames.Add("Compass", new Rectangle(258, 1, 11, 12));
            // triforce
            frames.Add("TriforceYellow", new Rectangle(275, 3, 10, 10));
            frames.Add("TriforceBlue", new Rectangle(275, 19, 10, 10));
        }
    }
}
