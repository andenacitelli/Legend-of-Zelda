using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace game_project.Content.Sprites
{
    class LinkSpriteFrames
    {
        public Dictionary<string, Rectangle> frames;
        public LinkSpriteFrames()
        {
            frames = new Dictionary<string, Rectangle>();

            // link walking
            frames.Add("LinkWalkingDownFrame1", new Rectangle(1, 11, 15, 16));
            frames.Add("LinkWalkingDownFrame2", new Rectangle(19, 11, 13, 16));
            frames.Add("LinkWalkingRightFrame1", new Rectangle(35, 11, 15, 16));
            frames.Add("LinkWalkingRightFrame2", new Rectangle(52, 12, 14, 15));
            frames.Add("LinkWalkingUpFrame1", new Rectangle(71, 11, 12, 16));
            frames.Add("LinkWalkingUpFrame2", new Rectangle(88, 11, 12, 16));

            // link use item
            frames.Add("LinkUseItemDown", new Rectangle(107, 11, 16, 15));
            frames.Add("LinkUseItemRight", new Rectangle(124, 12, 15, 15));
            frames.Add("LinkUseItemUp", new Rectangle(141, 11, 16, 16));

            // link pick up item
            frames.Add("LinkPickUpItemFrameOneHand", new Rectangle(214, 11, 13, 16));
            frames.Add("LinkPickUpItemFrameTwoHands", new Rectangle(231, 11, 14, 16));

            // link magic sheild
            frames.Add("LinkMagicSheildDownFrame1", new Rectangle(289, 11, 15, 16));
            frames.Add("LinkMagicSheildDownFrame2", new Rectangle(306, 11, 14, 16));
            frames.Add("LinkMagicSheildRightFrame1", new Rectangle(323, 11, 16, 16));
            frames.Add("LinkMagicSheildRightFrame2", new Rectangle(340, 12, 15, 15));

            // link wooden sword
            frames.Add("LinkWoodenSwordDownFrame1", new Rectangle(1, 47, 16, 15));
            frames.Add("LinkWoodenSwordDownFrame2", new Rectangle(18, 47, 16, 27));
            frames.Add("LinkWoodenSwordDownFrame3", new Rectangle(35, 47, 15, 13));
            frames.Add("LinkWoodenSwordDownFrame4", new Rectangle(53, 47, 13, 19));

            frames.Add("LinkWoodenSwordRightFrame1", new Rectangle(1, 78, 15, 15));
            frames.Add("LinkWoodenSwordRightFrame2", new Rectangle(18, 78, 27, 15));
            frames.Add("LinkWoodenSwordRightFrame3", new Rectangle(46, 78, 23, 15));
            frames.Add("LinkWoodenSwordRightFrame4", new Rectangle(70, 77, 19, 16));

            frames.Add("LinkWoodenSwordUpFrame1", new Rectangle(1, 109, 16, 16));
            frames.Add("LinkWoodenSwordUpFrame2", new Rectangle(18, 97, 16, 28));
            frames.Add("LinkWoodenSwordUpFrame3", new Rectangle(37, 98, 12, 27));
            frames.Add("LinkWoodenSwordUpFrame4", new Rectangle(54, 106, 12, 19));

            // link wooden sword magic sheild
            frames.Add("LinkWoodenSwordMagicSheildDownFrame1", new Rectangle(1, 128, 15, 23));
            frames.Add("LinkWoodenSwordMagicSheildDownFrame2", new Rectangle(18, 128, 14, 19));
            frames.Add("LinkWoodenSwordMagicSheildRightFrame1", new Rectangle(35, 129, 23, 15));
            frames.Add("LinkWoodenSwordMagicSheildRightFrame2", new Rectangle(59, 128, 19, 16));
        }

    }
}
