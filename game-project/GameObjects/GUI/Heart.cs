using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;

namespace game_project.GameObjects.GUI
{
    public class Heart : Entity
    {
        public Heart()
        {
            var s = new Sprite(ItemSpriteFactory.Instance.CreateHeartFull());
            AddComponent(s);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Debug);
        }
    }
}
