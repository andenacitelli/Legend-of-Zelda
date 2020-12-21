using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Projectiles
{
    public class Fireball : Projectile
    {

        public Fireball(Vector2 position, float angle)
        {
            Sprite s = new Sprite(BossSpriteFactory.Instance.CreateAquamentusFireball());
            AddComponent(s);
            s.SetAnimate(true);

            GetComponent<Transform>().position = position;
            //Constants.SetLayerDepth(this, Constants.LayerDepthEnemy);

            BehaviorScript b = new FireballMovement(angle);
            AddComponent(b);

            Collider coll = new Collider();
            AddComponent(coll);
            coll.response = new FireballCollisionResponse(this); // Half a heart of damage, we'll say 
            Constants.SetLayerDepth(this, Constants.LayerDepth.Item);

            // Doesn't seem to be a sound effect for fireball (or enemy projectiles in general) in the download, so assuming one doesn't exist
            // See http://noproblo.dayjo.org/ZeldaSounds/
        }
    }
}
