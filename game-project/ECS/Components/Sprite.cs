using game_project.ECS.Systems;
using game_project.Sprites;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace game_project.ECS.Components
{
    class Sprite : Component
    {
        public BasicSprite sprite; // Needs to be public so we can access frame width/heights from elsewhere
        private bool animate { get; set; } = false;
        private bool visible = true;
        private System.Func<BasicSprite> createXPBarBlank;

        public Color tint { get; set; } = Color.White;

        public Sprite(BasicSprite givenSprite = null)
        {
            SpriteSystem.Register(this);
            sprite = givenSprite;
        }

        public Sprite(System.Func<BasicSprite> createXPBarBlank)
        {
            this.createXPBarBlank = createXPBarBlank;
        }

        public void SetVisible(bool givenVisible)
        {
            visible = givenVisible;
        }

        public void SetSprite(BasicSprite givenSprite)
        {
            sprite = givenSprite;
        }

        public void SetAnimate(bool givenAnimate)
        {
            animate = givenAnimate;
        }

        public void AnimateIfNotAnimating()
        {
            if (!animate)
                animate = true;
        }

        public void SetUpdateFrameSpeed(double updateSpeed)
        {
            if (sprite != null)
            {
                sprite.updatesPerFrame = updateSpeed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (sprite != null)
            {
                sprite.Update(gameTime, animate);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null && visible)
            {
                if (sprite.spriteSheet == null)
                {
                    //Console.Log("Spritesheet null @ " + entity.name);
                    return;
                }

                var transform = entity.GetComponent<Transform>();
                var location = transform.WorldPosition;

                if (sprite.offsets != null)
                {
                    location += sprite.offsets[sprite.currentFrame] * 4;
                }

                var rotation = entity.GetComponent<Transform>().rotation;
                rotation = 0f;
                var Zpos = entity.GetComponent<Transform>().layerDepth;
                float scalar = sprite.scalar;
                Rectangle frame = sprite.frames[sprite.currentFrame];

                if (sprite.spriteSheet.ToString().ToLower().Contains("enemies"))
                {
                    // Console.WriteLine("Drawing an enemy!");
                    // Console.WriteLine("Drawing sprite from spritesheet " + sprite.spriteSheet.ToString() + " at position " + new Vector2(location.X, location.Y).ToString() + ".");

                    var position = entity.GetComponent<Transform>().position;
                    // Console.WriteLine("Transform.position equivalent " + new Vector2(position.X, position.Y).ToString() + ".");
                }

                spriteBatch.Draw(sprite.spriteSheet,
                    new Rectangle((int)location.X, (int)location.Y, (int)(frame.Width * scalar), (int)(frame.Height * scalar)),
                    frame,
                    tint,
                    rotation,
                    new Vector2(0, 0),
                    sprite.spriteEffects,
                    Zpos
                );
            }
        }
    }

    class ManualSprite : Sprite
    {
        public Texture2D texture;
        public ManualSprite(Color color)
        {
            texture = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            texture.SetData(new[] { color });
            //BasicSprite sprite = new BasicSprite(texture, frames)
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Raster.DrawRectangle(spriteBatch, )
        }
    }

    class RectangleSprite : ManualSprite
    {
        public Color color;
        public Rectangle rect;
        public RectangleSprite(Color color, Rectangle rect) : base(color)
        {
            this.color = color;
            this.rect = rect;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            var location = entity.GetComponent<Transform>().WorldPosition;
            var worldRect = new Rectangle((int)((float)rect.X + location.X), (int)((float)rect.Y + location.Y), rect.Width, rect.Height);
            Raster.DrawRectangle(
                spriteBatch,
                worldRect,
                color,
                width: 6);
        }
    }

}
