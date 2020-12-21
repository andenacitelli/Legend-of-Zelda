using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sounds;

namespace game_project.GameObjects.Projectiles
{
    public class Boomerang : Projectile
    {
        public Boomerang(Constants.Direction direction, Entity entity)
        {
            var entityTransform = entity.GetComponent<Transform>();
            GetComponent<Transform>().position = entityTransform.position;

            Constants.SetLayerDepth(this, Constants.LayerDepth.Item);

            Sprite s = new Sprite(EnemySpriteFactory.Instance.CreateGoriyaBoomerang());
            AddComponent(s);
            s.SetAnimate(true);

            BehaviorScript b = new BoomerangMovement(entity, direction);
            AddComponent(b);

            var coll = new Collider();
            coll.response = new BoomerangCollisionResponse(this, entity, 1); // Half a heart of damage, we'll say 
            AddComponent(coll);

            // Play sound
            Sound.PlaySound(Sound.SoundEffects.Arrow_Boomerang, entity, !Sound.SOUND_LOOPS);
        }
    }
}
