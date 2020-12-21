using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    public class Map : Entity
    {
        public Map()
        {
            Constants.SetLayerDepth(this, Constants.LayerDepth.Boxes);

            var s = new Sprite(HUDSpriteFactory.Instance.CreateMap());
            AddComponent(s);

            var transform = GetComponent<Transform>();
            transform.position = new Vector2(385, 371);

            AddComponent(new MapDisplay(transform));
        }
    }
}
