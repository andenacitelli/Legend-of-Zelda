using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Link;
using game_project.GameObjects.Projectiles;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class SwordBeamCollisionResponse : ECS.Components.CollisionResponse
    {
        private int damage = Constants.SWORD_BEAM_DAMAGE;
        public SwordBeamCollisionResponse(Entity entity) : base(entity)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {
            Entity.Destroy(entity);
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {
            Entity.Destroy(entity);
        }

        public override void ResolveCollision(DoorCollisionResponse other)
        {
            Entity.Destroy(entity);
        }

        public override void ResolveCollision(EnemyCollisionResponse other)
        {
            Entity enemy = other.entity;
            // sound effect 
            Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, enemy, !Sound.SOUND_LOOPS);

            // take damage
            if (enemy.GetType().Equals(typeof(Stalfo)))
            {
                enemy.GetComponent<StalfoHealthManagement>().Damage(Constants.LINK_SWORD_DAMAGE);
            }
            else if (enemy.GetType().Equals(typeof(Aquamentus)))
            {
                enemy.GetComponent<AquamentusHealthManagement>().Damage(Constants.LINK_SWORD_DAMAGE);
            }
            else
            {
                enemy.GetComponent<EnemyHealthManagement>().Damage(Constants.LINK_SWORD_DAMAGE);
            }

            // Push back
            enemy.AddComponent(new EnemyKnockback(((SwordProjectile)entity).direction, Constants.ENEMY_KNOCKBACK_DISTANCE, Constants.ENEMY_KNOCKBACK_FRAMES));

            Entity.Destroy(entity);
        }

        public override void ResolveCollision(KeeseCollisionResponse other)
        {
            Entity enemy = other.entity;
            // sound effect 
            Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, enemy, !Sound.SOUND_LOOPS);

            // take damage
            if (enemy.GetType().Equals(typeof(Stalfo)))
            {
                enemy.GetComponent<StalfoHealthManagement>().Damage(Constants.LINK_SWORD_DAMAGE);
            }
            else if (enemy.GetType().Equals(typeof(Aquamentus)))
            {
                enemy.GetComponent<AquamentusHealthManagement>().Damage(Constants.LINK_SWORD_DAMAGE);
            }
            else
            {
                enemy.GetComponent<EnemyHealthManagement>().Damage(Constants.LINK_SWORD_DAMAGE);
            }

            // Push back
            enemy.AddComponent(new EnemyKnockback(((SwordProjectile)entity).direction, Constants.ENEMY_KNOCKBACK_DISTANCE, Constants.ENEMY_KNOCKBACK_FRAMES));

            Entity.Destroy(entity);
        }

    }
}