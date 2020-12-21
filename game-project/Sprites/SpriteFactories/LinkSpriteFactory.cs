using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class LinkSpriteFactory
    {
        private Texture2D LinkSpriteSheet;
        private readonly LinkSpriteFrames linkSpriteFrames = new LinkSpriteFrames();

        private static readonly LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            LinkSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Link");
        }

        private LinkSpriteFactory() { }

        public BasicSprite CreateLinkWalkingDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWalkingDownFrame1"],
                linkSpriteFrames.frames["LinkWalkingDownFrame2"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkWalkingRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWalkingRightFrame1"],
                linkSpriteFrames.frames["LinkWalkingRightFrame2"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkWalkingLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWalkingRightFrame1"],
                linkSpriteFrames.frames["LinkWalkingRightFrame2"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateLinkWalkingUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWalkingUpFrame1"],
                linkSpriteFrames.frames["LinkWalkingUpFrame2"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkUseItemDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkUseItemDown"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkUseItemRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkUseItemRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkUseItemLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkUseItemRight"]
            };
            return new BasicSprite(LinkSpriteSheet, frames, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateLinkUseItemUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkUseItemUp"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkPickUpItemOneHand()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkPickUpItemFrameOneHand"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkPickUpItemTwoHands()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkPickUpItemFrameTwoHands"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkWoodenSwordDown()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWoodenSwordDownFrame1"],
                linkSpriteFrames.frames["LinkWoodenSwordDownFrame2"],
                linkSpriteFrames.frames["LinkWoodenSwordDownFrame3"],
                linkSpriteFrames.frames["LinkWoodenSwordDownFrame4"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkWoodenSwordRight()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame1"],
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame2"],
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame3"],
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame4"]
            };
            return new BasicSprite(LinkSpriteSheet, frames);
        }
        public BasicSprite CreateLinkWoodenSwordLeft()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame1"],
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame2"],
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame3"],
                linkSpriteFrames.frames["LinkWoodenSwordRightFrame4"]
            };

            List<Vector2> offsets = new List<Vector2>
            {
                new Vector2(0,0),
                new Vector2(-12,0),
                new Vector2(-9,0),
                new Vector2(-4,0),
            };
            return new BasicSprite(LinkSpriteSheet, frames, offsets, SpriteEffects.FlipHorizontally);
        }
        public BasicSprite CreateLinkWoodenSwordUp()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                linkSpriteFrames.frames["LinkWoodenSwordUpFrame1"],
                linkSpriteFrames.frames["LinkWoodenSwordUpFrame2"],
                linkSpriteFrames.frames["LinkWoodenSwordUpFrame3"],
                linkSpriteFrames.frames["LinkWoodenSwordUpFrame4"]
            };
            List<Vector2> offsets = new List<Vector2>
            {
                new Vector2(0,0),
                new Vector2(0,-12),
                new Vector2(0,-11),
                new Vector2(0,-4),
            };
            return new BasicSprite(LinkSpriteSheet, frames, offsets);
        }
    }
}
