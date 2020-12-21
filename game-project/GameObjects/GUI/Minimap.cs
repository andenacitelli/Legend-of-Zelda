using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

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

        public void Disappear()
        {
            GetComponent<Sprite>().SetVisible(false);

            foreach (Transform child in GetComponent<Transform>().Children)
            {
                child.entity.GetComponent<Sprite>().SetVisible(false);
            }
        }
    }
}
