using game_project.CollisionResponse;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    public class BombExplosion : Item
    {
        public BombExplosion(BasicSprite sprite, Vector2 position) : base(sprite, position)
        {
            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = position;

            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BehaviorScript behavior = new BombExplosionBehaviorScript();
            AddComponent(behavior);

            Collider coll = new Collider();
            coll.response = new BombCollisionResponse(this);
            this.AddComponent(coll);
        }
    }
}
