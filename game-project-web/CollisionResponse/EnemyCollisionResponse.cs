using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Link;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class EnemyCollisionResponse : ECS.Components.CollisionResponse
    {
        // Damage that the enemy linked to this given collider does to the player 
        public int damage;
        private bool isProjectile;

        public EnemyCollisionResponse(Entity e, int damage, bool isProjectile = false) : base(e)
        {
            this.isProjectile = isProjectile;
            this.damage = damage;
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {
            if (isProjectile) Entity.Destroy(entity);

            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(DoorCollisionResponse other)
        {
            if (isProjectile) Entity.Destroy(entity);

            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {
            if (isProjectile) Entity.Destroy(entity);

            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(BoomerangCollisionResponse other)
        {
            Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, entity, !Sound.SOUND_LOOPS);
            if (other.owner == Scene.Find("link"))
            {
                entity.AddComponent(new EnemyFreeze());
            }
        }

        public override void ResolveCollision(LinkCollisionResponse other)
        {
            LinkBehavior linkBehavior = other.entity.GetComponent<LinkBehavior>();
            if (linkBehavior.attacking)
            {
                // sound effect 
                Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, entity, !Sound.SOUND_LOOPS);

                // take damage
                if (entity.GetType().Equals(typeof(Stalfo)))
                {
                    entity.GetComponent<StalfoHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
                }
                else if (entity.GetType().Equals(typeof(Aquamentus)))
                {
                    entity.GetComponent<AquamentusHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
                }
                else
                {
                    entity.GetComponent<EnemyHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
                }

                // Push back
                Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
                Vector2 linkPos = entity.GetComponent<Transform>().position;
                Vector2 diff = enemyPos - linkPos;
                int distance = Constants.ENEMY_KNOCKBACK_DISTANCE;
                int frames = Constants.ENEMY_KNOCKBACK_FRAMES;

                // Enemy is Up from Link
                // UPWARD && MORE VERTICAL THAN HORIZONTAL
                if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new EnemyKnockback(Constants.Direction.DOWN, distance, frames));
                    // Console.WriteLine("Enemy is up from link!");
                }

                // Enemy is Right from Link
                // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new EnemyKnockback(Constants.Direction.LEFT, distance, frames));
                    // Console.WriteLine("Enemy is right from link!");
                }

                // Enemy is Down from Link
                // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
                else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new EnemyKnockback(Constants.Direction.UP, distance, frames));
                    // Console.WriteLine("Enemy is down from link!");
                }

                // Enemy is Left from Link
                // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new EnemyKnockback(Constants.Direction.RIGHT, distance, frames));
                    // Console.WriteLine("Enemy is left from link!");
                }

                // Debug; If this ever gets output, something is wrong.
                else
                {
                    Console.WriteLine("Link was unrecognized direction!");
                }
            }
        }

        public override void ResolveCollision(SwordCollisionResponse other)
        {
            // sound effect 
            Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, entity, !Sound.SOUND_LOOPS);

            // take damage
            if (entity.GetType().Equals(typeof(Stalfo)))
            {
                entity.GetComponent<StalfoHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
            }
            else if (entity.GetType().Equals(typeof(Aquamentus)))
            {
                entity.GetComponent<AquamentusHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
            }
            else
            {
                entity.GetComponent<EnemyHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
            }

            // Push back
            Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
            Vector2 linkPos = entity.GetComponent<Transform>().position;
            Vector2 diff = enemyPos - linkPos;
            int distance = 150, frames = 10;

            // Enemy is Up from Link
            // UPWARD && MORE VERTICAL THAN HORIZONTAL
            if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.DOWN, distance, frames));
                // Console.WriteLine("Enemy is up from link!");
            }

            // Enemy is Right from Link
            // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
            else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.LEFT, distance, frames));
                // Console.WriteLine("Enemy is right from link!");
            }

            // Enemy is Down from Link
            // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
            else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.UP, distance, frames));
                // Console.WriteLine("Enemy is down from link!");
            }

            // Enemy is Left from Link
            // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
            else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.RIGHT, distance, frames));
                // Console.WriteLine("Enemy is left from link!");
            }

            // Debug; If this ever gets output, something is wrong.
            else
            {
                Console.WriteLine("Link was unrecognized direction!");
            }
        }

        public override void ResolveCollision(SwordBeamCollisionResponse other)
        {
            // sound effect 
            Sound.PlaySound(Sound.SoundEffects.Enemy_Hit, entity, !Sound.SOUND_LOOPS);

            // take damage
            if (entity.GetType().Equals(typeof(Stalfo)))
            {
                entity.GetComponent<StalfoHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
            }
            else if (entity.GetType().Equals(typeof(Aquamentus)))
            {
                entity.GetComponent<AquamentusHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
            }
            else
            {
                entity.GetComponent<EnemyHealthManagement>().DeductHealth(Constants.LINK_SWORD_DAMAGE);
            }

            // Push back
            Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
            Vector2 linkPos = entity.GetComponent<Transform>().position;
            Vector2 diff = enemyPos - linkPos;
            int distance = 150, frames = 10;

            // Enemy is Up from Link
            // UPWARD && MORE VERTICAL THAN HORIZONTAL
            if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.DOWN, distance, frames));
                // Console.WriteLine("Enemy is up from link!");
            }

            // Enemy is Right from Link
            // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
            else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.LEFT, distance, frames));
                // Console.WriteLine("Enemy is right from link!");
            }

            // Enemy is Down from Link
            // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
            else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.UP, distance, frames));
                // Console.WriteLine("Enemy is down from link!");
            }

            // Enemy is Left from Link
            // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
            else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
            {
                entity.AddComponent(new EnemyKnockback(Constants.Direction.RIGHT, distance, frames));
                // Console.WriteLine("Enemy is left from link!");
            }

            // Debug; If this ever gets output, something is wrong.
            else
            {
                Console.WriteLine("Link was unrecognized direction!");
            }
        }

    }
}
