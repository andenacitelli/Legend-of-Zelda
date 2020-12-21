using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace game_project.Sprites
{
    public static class Raster
    {
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            if (color == null)
            {
                color = Color.White;
            }
            var t = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            t.SetData(new[] { color });

            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(t, r, null, color, angle, Vector2.Zero, SpriteEffects.None, Constants.GetLayerDepth(Constants.LayerDepth.Boxes));
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle r, Color color, int width = 1)
        {
            float radius = width / 2;
            DrawLine(spriteBatch, new Vector2(r.X, r.Y - radius), new Vector2(r.X, r.Y + r.Height - radius), color, width);
            DrawLine(spriteBatch, new Vector2(r.X - radius, r.Y + r.Height), new Vector2(r.X + r.Width - radius, r.Y + r.Height), color, width);
            DrawLine(spriteBatch, new Vector2(r.X + r.Width, r.Y + r.Height + radius), new Vector2(r.X + r.Width, r.Y + radius), color, width);
            DrawLine(spriteBatch, new Vector2(r.X + r.Width + radius, r.Y), new Vector2(r.X + radius, r.Y), color, width);
        }

        //public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle r, Color color)
        //{

        //}


    }
}
