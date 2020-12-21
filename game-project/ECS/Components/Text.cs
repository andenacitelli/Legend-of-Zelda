using System;
using System.Runtime.InteropServices;
using game_project.ECS.Systems;
using game_project.Fonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static game_project.Constants;
using game_project.Sounds;

namespace game_project.ECS.Components
{
    class Text : Component
    {
        public string StringToWrite { get; set; }
        public string CurrentString { get; set; } = "";
        private int currentTextIndex = 0;
        private float timeSinceLastIncrement = 0;
        private bool Animate { get; set; }
        public Color Color { get; set; }
        public SpriteFont font;
        public TextHorizontal TextHorzAlign = TextHorizontal.LeftAligned;
        public TextVertical TextVertAlign = TextVertical.TopAligned;
        public float Scale { get; set; } = 1f;
        private Vector2 origin = new Vector2(0, 0);
        public Rectangle TextBox { get; set; }
        public bool Visible { get; set; } = true;
        public Text(string givenString, bool givenAnimate)
        {
            TextSystem.Register(this);

            font = GameContent.Font.hudFont;

            StringToWrite = givenString;
            Animate = givenAnimate;
            if (!Animate)
            {
                CurrentString = givenString;
            }
            else
            {
                Sound.PlaySound(Sound.SoundEffects.Text, true);
            }
            TextBox = new Rectangle(0, 0, Game1.viewport.Bounds.Width, Game1.viewport.Bounds.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (Animate)
            {
                if (currentTextIndex != StringToWrite.Length)
                {
                    timeSinceLastIncrement += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timeSinceLastIncrement >= TEXT_MOVEMENT_TIME)
                    {
                        CurrentString += StringToWrite[currentTextIndex];
                        currentTextIndex++;
                        timeSinceLastIncrement = 0;
                    }
                }

                else
                {
                    Sound.StopSound(Sound.SoundEffects.Text);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                // get info
                var location = entity.GetComponent<Transform>().WorldPosition;
                var rotation = entity.GetComponent<Transform>().rotation;
                var Zpos = entity.GetComponent<Transform>().layerDepth;

                // align text
                var size = font.MeasureString(CurrentString);

                switch (TextHorzAlign)
                {
                    case TextHorizontal.CenterAligned:
                        location.X += (TextBox.Width - size.X) / 2;
                        break;
                    case TextHorizontal.RightAligned:
                        location.X += TextBox.Width - size.X;
                        break;
                }

                switch (TextVertAlign)
                {
                    case TextVertical.CenterAligned:
                        location.Y += (TextBox.Height - size.Y) / 2;
                        break;
                    case TextVertical.BottomAligned:
                        location.Y += TextBox.Height - size.Y;
                        break;
                }

                // draw
                spriteBatch.DrawString(font,
                    parseText(CurrentString),
                    location,
                    Color,
                    rotation,
                    origin,
                    Scale,
                    SpriteEffects.None,
                    Zpos
                );
            }
        }

        private string parseText(string text)
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = text.Split(' ');

            foreach (string word in wordArray)
            {
                if (font.MeasureString(line + word).Length() * Scale > TextBox.Width)
                {
                    returnString = returnString + line + '\n';
                    line = string.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
        }
    }
}
