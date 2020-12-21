using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Writing;
using game_project.Levels;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace game_project.GameObjects.GUI
{
    public class ManualDrawing : Entity
    {

        public ManualDrawing(Color color, Rectangle rect)
        {

            Transform transform = GetComponent<Transform>();
            Constants.SetLayerDepth(this, Constants.LayerDepth.Text);
            Texture2D texture = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            texture.SetData(new[] { color });
            List<Rectangle> frames = new List<Rectangle>()
            {
                rect
            };
            BasicSprite basicSprite = new BasicSprite(texture, frames);
            Sprite sprite = new Sprite(basicSprite);
        }
    }
}
