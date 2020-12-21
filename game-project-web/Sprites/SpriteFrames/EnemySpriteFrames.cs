using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace game_project.Content.Sprites
{
    class EnemySpriteFrames
    {
        public Dictionary<string, Rectangle> frames;
        public EnemySpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // stalfos
            frames.Add("Stalfos", new Rectangle(2, 59, 15, 16));
            frames.Add("StalfosSwordUp1", new Rectangle(18, 59, 7, 16));
            frames.Add("StalfosSwordUp2", new Rectangle(27, 59, 7, 16));
            frames.Add("StalfosSwordUp3", new Rectangle(36, 59, 7, 16));
            frames.Add("StalfosSwordUp4", new Rectangle(45, 59, 7, 16));
            frames.Add("StalfosSwordRight1", new Rectangle(54, 64, 16, 7));
            frames.Add("StalfosSwordRight2", new Rectangle(71, 64, 16, 7));
            frames.Add("StalfosSwordRight3", new Rectangle(88, 64, 16, 7));
            frames.Add("StalfosSwordRight4", new Rectangle(105, 64, 16, 7));
            // rope
            frames.Add("RopeFrame1", new Rectangle(127, 59, 14, 15));
            frames.Add("RopeFrame2", new Rectangle(144, 60, 15, 14));
            // blade trap
            frames.Add("BladeTrap", new Rectangle(164, 59, 16, 16));
            // wallmaster
            frames.Add("WallmasterFrame1", new Rectangle(393, 11, 16, 16));
            frames.Add("WallmasterFrame2", new Rectangle(410, 12, 14, 15));
            // keese
            frames.Add("KeeseBlueFrame1", new Rectangle(183, 15, 16, 8));
            frames.Add("KeeseBlueFrame2", new Rectangle(203, 15, 10, 10));
            frames.Add("KeeseRedFrame1", new Rectangle(183, 32, 16, 8));
            frames.Add("KeeseRedFrame2", new Rectangle(203, 32, 10, 10));
            // goriya
            frames.Add("GoriyaRedDown", new Rectangle(224, 11, 13, 16));
            frames.Add("GoriyaRedUp", new Rectangle(241, 11, 13, 16));
            frames.Add("GoriyaRedRightFrame1", new Rectangle(257, 11, 13, 16));
            frames.Add("GoriyaRedRightFrame2", new Rectangle(275, 12, 14, 15));
            frames.Add("GoriyaBlueDown", new Rectangle(224, 28, 13, 16));
            frames.Add("GoriyaBlueUp", new Rectangle(241, 28, 13, 16));
            frames.Add("GoriyaBlueRightFrame1", new Rectangle(257, 28, 13, 16));
            frames.Add("GoriyaBlueRightFrame2", new Rectangle(275, 29, 14, 15));
            // goriya boomerang
            frames.Add("BoomerangLR", new Rectangle(291, 15, 5, 8));
            frames.Add("Boomerang45", new Rectangle(299, 15, 8, 8));
            frames.Add("BoomerangUD", new Rectangle(308, 17, 8, 5));
            // gel navy
            frames.Add("GelNavyFrame1", new Rectangle(1, 16, 8, 8));
            frames.Add("GelNavyFrame2", new Rectangle(11, 15, 6, 9));
            // gel blue
            frames.Add("GelBlueFrame1", new Rectangle(19, 16, 8, 8));
            frames.Add("GelBlueFrame2", new Rectangle(29, 15, 6, 9));
            // gel green
            frames.Add("GelGreenFrame1", new Rectangle(37, 16, 8, 8));
            frames.Add("GelGreenFrame2", new Rectangle(47, 15, 6, 9));
            // gel black gold
            frames.Add("GelBlackGoldFrame1", new Rectangle(55, 16, 8, 8));
            frames.Add("GelBlackGoldFrame2", new Rectangle(65, 15, 6, 9));
            // gel emerald
            frames.Add("GelEmeraldFrame1", new Rectangle(1, 33, 8, 8));
            frames.Add("GelEmeraldFrame2", new Rectangle(11, 32, 6, 9));
            // gel gold
            frames.Add("GelGoldFrame1", new Rectangle(19, 33, 8, 8));
            frames.Add("GelGoldFrame2", new Rectangle(29, 32, 6, 9));
            // gel black silver
            frames.Add("GelBlackSilverFrame1", new Rectangle(55, 33, 8, 8));
            frames.Add("GelBlackSilverFrame2", new Rectangle(65, 32, 6, 9));
            // zol green 
            frames.Add("ZolGreenFrame1", new Rectangle(79, 11, 12, 16));
            frames.Add("ZolGreenFrame2", new Rectangle(95, 13, 14, 14));
            // zol black gold
            frames.Add("ZolBlackGoldFrame1", new Rectangle(113, 11, 12, 16));
            frames.Add("ZolBlackGoldFrame2", new Rectangle(129, 13, 14, 14));
            // zol emerald
            frames.Add("ZolEmeraldFrame1", new Rectangle(147, 11, 12, 16));
            frames.Add("ZolEmeraldFrame2", new Rectangle(163, 13, 14, 14));
            // zol brown 
            frames.Add("ZolBrownFrame1", new Rectangle(79, 28, 12, 16));
            frames.Add("ZolBrownFrame2", new Rectangle(95, 30, 14, 14));
            // zol black silver
            frames.Add("ZolBlackSilverFrame1", new Rectangle(147, 28, 12, 16));
            frames.Add("ZolBlackSilverFrame2", new Rectangle(163, 30, 14, 14));
        }
    }
}
