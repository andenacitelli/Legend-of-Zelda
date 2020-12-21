using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace game_project.GameObjects.GUI
{
    public class Minimap : Entity
    {
        public Minimap(Vector2 position, bool visible)
        {
            Constants.SetLayerDepth(this, Constants.LayerDepth.Boxes);

            var sprite = new Sprite(HUDSpriteFactory.Instance.CreateMinimapBlack());
            sprite.SetVisible(visible);
            AddComponent(sprite);

            var transform = GetComponent<Transform>();
            transform.position = position;

            AddComponent(new MinimapDisplay(transform));
        }
    }
}
