using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    public class ItemSelector : Entity
    {
        public ItemSelector(Vector2 position)
        {
            GetComponent<Transform>().position = position;

            var sprite = new Sprite(HUDSpriteFactory.Instance.CreateSelectedItemChooser());
            sprite.SetAnimate(true);
            AddComponent(sprite);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Debug);

            var script = new ItemSelectorDisplayManager();
            AddComponent(script);
        }
    }
}
