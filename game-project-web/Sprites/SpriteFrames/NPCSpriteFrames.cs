using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace game_project.Content.Sprites
{
    class NPCSpriteFrames
    {
        public Dictionary<string, Rectangle> frames;
        public NPCSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // old man 1
            frames.Add("OldMan1", new Rectangle(1, 11, 16, 16));
            // old man 2
            frames.Add("OldMan2", new Rectangle(18, 11, 16, 16));
            // old woman
            frames.Add("OldWoman", new Rectangle(35, 11, 16, 16));
            // flame
            frames.Add("Flame", new Rectangle(52, 11, 16, 16));
            // circles
            frames.Add("GreenCircle", new Rectangle(69, 14, 8, 10));
            frames.Add("NavyCircle", new Rectangle(78, 14, 8, 10));
            frames.Add("RedCircle", new Rectangle(87, 14, 8, 10));
            frames.Add("BlueCircle", new Rectangle(96, 14, 8, 10));
            // merchant
            frames.Add("MerchantGreen", new Rectangle(109, 11, 16, 16));
            frames.Add("MerchantWhite", new Rectangle(126, 11, 16, 16));
            frames.Add("MerchantRed", new Rectangle(143, 11, 16, 16));
        }
    }
}
