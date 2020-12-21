using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    public class SelectedItem : Entity
    {
        public SelectedItem(Vector2 position)
        {
            GetComponent<Transform>().position = position;

            var sprite = new Sprite(HUDSpriteFactory.Instance.CreateBoomerang());
            sprite.sprite.scalar *= Constants.HUD_BOOMERANG_SCALE * 1.5f;
            AddComponent(sprite);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Debug);

            var script = new SelectedItemDisplayManager();
            AddComponent(script);
        }
    }
}
