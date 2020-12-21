using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    public class HUDMap : Entity
    {
        public HUDMap(Vector2 position)
        {
            GetComponent<Transform>().position = position;

            var sprite = new Sprite(HUDSpriteFactory.Instance.CreateMapItem());
            sprite.SetVisible(false);
            AddComponent(sprite);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Debug);

            var script = new HUDMapDisplayManager();
            AddComponent(script);
        }
    }
}
