using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace game_project.Content.Sprites
{
    class LinkItemSpriteFrames
    {

        public Dictionary<string, Rectangle> frames;
        public LinkItemSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // wooden sword
            frames.Add("WoodenSwordUp", new Rectangle(1, 154, 7, 16));
            frames.Add("WoodenSwordRight", new Rectangle(10, 159, 16, 7));
            frames.Add("WoodenSwordBeam", new Rectangle(27, 157, 8, 10));
            // white blue sword
            frames.Add("WhiteBlueSwordUp", new Rectangle(36, 154, 7, 16));
            frames.Add("WhiteBlueSwordRight", new Rectangle(45, 159, 16, 7));
            frames.Add("WhiteBlueSwordBeam", new Rectangle(62, 157, 8, 10));
            // white red sword
            frames.Add("WhiteRedSwordUp", new Rectangle(71, 154, 7, 16));
            frames.Add("WhiteRedSwordRight", new Rectangle(80, 159, 16, 7));
            frames.Add("WhiteRedSwordBeam", new Rectangle(97, 157, 8, 10));
            // red sword
            frames.Add("RedSwordUp", new Rectangle(106, 154, 7, 16));
            frames.Add("RedSwordRight", new Rectangle(115, 159, 16, 7));
            frames.Add("RedSwordBeam", new Rectangle(132, 157, 8, 10));
            // green arrow
            frames.Add("GreenArrowUp", new Rectangle(3, 185, 5, 16));
            frames.Add("GreenArrowRight", new Rectangle(10, 190, 16, 5));
            // blue arrow
            frames.Add("BlueArrowUp", new Rectangle(29, 185, 5, 16));
            frames.Add("BlueArrowRight", new Rectangle(36, 190, 16, 5));
            // arrow poof
            frames.Add("ArrowPoof", new Rectangle(53, 189, 8, 8));
            // wooden boomerang
            frames.Add("BoomerangWoodenLR", new Rectangle(65, 189, 5, 8));
            frames.Add("BoomerangWooden45", new Rectangle(73, 189, 8, 8));
            frames.Add("BoomerangWoodenUD", new Rectangle(82, 191, 8, 5));
            // blue boomerang
            frames.Add("BoomerangBlueLR", new Rectangle(92, 189, 5, 8));
            frames.Add("BoomerangBlue45", new Rectangle(100, 189, 8, 8));
            frames.Add("BoomerangBlueUD", new Rectangle(109, 191, 8, 5));
            // bomb
            frames.Add("Bomb", new Rectangle(129, 185, 8, 14));
            frames.Add("ExplosionFull", new Rectangle(138, 185, 16, 16));
            frames.Add("ExplosionHalf", new Rectangle(155, 185, 16, 16));
            frames.Add("ExplosionFinished", new Rectangle(172, 185, 16, 16));
            // fire
            frames.Add("Fire", new Rectangle(191, 185, 16, 16));
        }
    }
}
