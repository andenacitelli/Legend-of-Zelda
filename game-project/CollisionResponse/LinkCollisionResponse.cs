using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Link;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class LinkCollisionResponse : ECS.Components.CollisionResponse
    {
        public LinkCollisionResponse(Entity entity) : base(entity)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {
            entity.GetComponent<Collider>().CollidingWithRigid = true;
            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {
            // step back one frame of motion
            entity.GetComponent<Collider>().CollidingWithRigid = true;

            // access Link transform
            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(EnemyCollisionResponse other)
        {
            LinkBehavior linkBehavior = entity.GetComponent<LinkBehavior>();

            // Trigger drag away and reset animation if WallMaster got him
            if (!Game1.inBossRush && other.entity.GetType() == typeof(WallMaster))
            {
                if (entity.GetComponent<DragAndReset>() == null)
                {
                    LevelManager.link.AddComponent(new DragAndReset(other.entity));
                }                                
                return;
            }

            // Change to Hurt Sprite (enables and disables immunity inside)
            if (!entity.GetComponent<LinkHealthManagement>().immune)
            {
                // Take Damage
                Console.WriteLine("Link is hurt");
                entity.GetComponent<LinkHealthManagement>().Damage(other.damage);

                // Push back
                Vector2 linkPos = entity.GetComponent<Transform>().position;
                Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
                Vector2 diff = linkPos - enemyPos;
                int distance = Constants.ENEMY_KNOCKBACK_DISTANCE;
                int frames = Constants.ENEMY_KNOCKBACK_FRAMES;

                // Enemy is Up from Link
                // UPWARD && MORE VERTICAL THAN HORIZONTAL
                if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.DOWN, distance, frames));
                    // Console.WriteLine("Enemy is up from link!");
                }

                // Enemy is Right from Link
                // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.LEFT, distance, frames));
                    // Console.WriteLine("Enemy is right from link!");
                }

                // Enemy is Down from Link
                // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
                else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.UP, distance, frames));
                    // Console.WriteLine("Enemy is down from link!");
                }

                // Enemy is Left from Link
                // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.RIGHT, distance, frames));
                    // Console.WriteLine("Enemy is left from link!");
                }

                // Debug; If this ever gets output, something is wrong.
                else
                {
                    Console.WriteLine("Enemy was unrecognized direction!");
                }
            }

            
        }

        public override void ResolveCollision(KeeseCollisionResponse other)
        {
            LinkBehavior linkBehavior = entity.GetComponent<LinkBehavior>();
            if (!linkBehavior.attacking)
            {

                // Change to Hurt Sprite (enables and disables immunity inside)
                if (!entity.GetComponent<LinkHealthManagement>().immune)
                {
                    // Take Damage
                    entity.GetComponent<LinkHealthManagement>().Damage(other.damage);

                    // decrease xp
                    entity.GetComponent<LinkXPManager>().LinkDamaged_XPDecrease();

                    // Push back
                    Vector2 linkPos = entity.GetComponent<Transform>().position;
                    Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
                    Vector2 diff = linkPos - enemyPos;
                    int distance = Constants.ENEMY_KNOCKBACK_DISTANCE;
                    int frames = Constants.ENEMY_KNOCKBACK_FRAMES;

                    // Enemy is Up from Link
                    // UPWARD && MORE VERTICAL THAN HORIZONTAL
                    if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.DOWN, distance, frames));
                        // Console.WriteLine("Enemy is up from link!");
                    }

                    // Enemy is Right from Link
                    // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
                    else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.LEFT, distance, frames));
                        // Console.WriteLine("Enemy is right from link!");
                    }

                    // Enemy is Down from Link
                    // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
                    else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.UP, distance, frames));
                        // Console.WriteLine("Enemy is down from link!");
                    }

                    // Enemy is Left from Link
                    // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
                    else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.RIGHT, distance, frames));
                        // Console.WriteLine("Enemy is left from link!");
                    }

                    // Debug; If this ever gets output, something is wrong.
                    else
                    {
                        Console.WriteLine("Enemy was unrecognized direction!");
                    }
                }

            }
        }


        // Unsure why I need to duplicate this for BladeTrap... It *should* be using the Enemy one
        public override void ResolveCollision(BladeTrapCollisionResponse other)
        {
            LinkBehavior linkBehavior = entity.GetComponent<LinkBehavior>();

            // Change to Hurt Sprite (enables and disables immunity inside)
            if (!entity.GetComponent<LinkHealthManagement>().immune)
            {
                // Take Damage
                entity.GetComponent<LinkHealthManagement>().Damage(other.damage);

                // Push back
                Vector2 linkPos = entity.GetComponent<Transform>().WorldPosition;
                Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
                Vector2 diff = linkPos - enemyPos;
                int distance = Constants.ENEMY_KNOCKBACK_DISTANCE;
                int frames = Constants.ENEMY_KNOCKBACK_FRAMES;

                // Enemy is Up from Link
                // UPWARD && MORE VERTICAL THAN HORIZONTAL
                if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.DOWN, distance, frames));
                    // Console.WriteLine("Enemy is up from link!");
                }

                // Enemy is Right from Link
                // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.LEFT, distance, frames));
                    // Console.WriteLine("Enemy is right from link!");
                }

                // Enemy is Down from Link
                // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
                else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.UP, distance, frames));
                    // Console.WriteLine("Enemy is down from link!");
                }

                // Enemy is Left from Link
                // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.RIGHT, distance, frames));
                    // Console.WriteLine("Enemy is left from link!");
                }

                // Debug; If this ever gets output, something is wrong.
                else
                {
                    Console.WriteLine("Enemy was unrecognized direction!");
                }
            }

            
        }

        public override void ResolveCollision(BoomerangCollisionResponse other)
        {
            LinkBehavior linkBehavior = entity.GetComponent<LinkBehavior>();
            if (other.owner != entity)
            {
                // Take Damage
                entity.GetComponent<LinkHealthManagement>().DeductHealth(other.damage);

                // decrease xp
                entity.GetComponent<LinkXPManager>().LinkDamaged_XPDecrease();

                // Change to Hurt Sprite (enables and disables immunity inside)
                if (!entity.GetComponent<LinkHealthManagement>().immune)
                {
                    linkBehavior.damaged = true;
                    entity.GetComponent<LinkHealthManagement>().immune = true;

                    // Push back
                    Vector2 linkPos = entity.GetComponent<Transform>().position;
                    Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
                    Vector2 diff = linkPos - enemyPos;
                    int distance = Constants.ENEMY_KNOCKBACK_DISTANCE;
                    int frames = Constants.ENEMY_KNOCKBACK_FRAMES;

                    // Enemy is Up from Link
                    // UPWARD && MORE VERTICAL THAN HORIZONTAL
                    if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.DOWN, distance, frames));
                        // Console.WriteLine("Enemy is up from link!");
                    }

                    // Enemy is Right from Link
                    // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
                    else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.LEFT, distance, frames));
                        // Console.WriteLine("Enemy is right from link!");
                    }

                    // Enemy is Down from Link
                    // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
                    else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.UP, distance, frames));
                        // Console.WriteLine("Enemy is down from link!");
                    }

                    // Enemy is Left from Link
                    // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
                    else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                    {
                        entity.AddComponent(new LinkKnockback(Constants.Direction.RIGHT, distance, frames));
                        // Console.WriteLine("Enemy is left from link!");
                    }

                    // Debug; If this ever gets output, something is wrong.
                    else
                    {
                        Console.WriteLine("Enemy was unrecognized direction!");
                    }
                }
            }
        }

        public override void ResolveCollision(FireballCollisionResponse other)
        {
            LinkBehavior linkBehavior = entity.GetComponent<LinkBehavior>();
            // Take Damage
            entity.GetComponent<LinkHealthManagement>().DeductHealth(other.damage);

            // Change to Hurt Sprite (enables and disables immunity inside)
            if (!entity.GetComponent<LinkHealthManagement>().immune)
            {
                entity.GetComponent<LinkHealthManagement>().DeductHealth(Constants.FIREBALL_DAMAGE);
                linkBehavior.damaged = true;
                entity.GetComponent<LinkHealthManagement>().immune = true;

                // decrease xp
                entity.GetComponent<LinkXPManager>().LinkDamaged_XPDecrease();

                // Push back
                Vector2 linkPos = entity.GetComponent<Transform>().position;
                Vector2 enemyPos = other.entity.GetComponent<Transform>().position;
                Vector2 diff = linkPos - enemyPos;
                int distance = Constants.ENEMY_KNOCKBACK_DISTANCE;
                int frames = Constants.ENEMY_KNOCKBACK_FRAMES;

                // Enemy is Up from Link
                // UPWARD && MORE VERTICAL THAN HORIZONTAL
                if (enemyPos.Y <= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.DOWN, distance, frames));
                    // Console.WriteLine("Enemy is up from link!");
                }

                // Enemy is Right from Link
                // RIGHTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X >= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.LEFT, distance, frames));
                    // Console.WriteLine("Enemy is right from link!");
                }

                // Enemy is Down from Link
                // DOWNWARD && MORE VERTICAL THAN HORIZONTAL
                else if (enemyPos.Y >= linkPos.Y && Math.Abs(diff.Y) >= Math.Abs(diff.X))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.UP, distance, frames));
                    // Console.WriteLine("Enemy is down from link!");
                }

                // Enemy is Left from Link
                // LEFTWARD && MORE HORIZONTAL THAN VERTICAL
                else if (enemyPos.X <= linkPos.X && Math.Abs(diff.X) >= Math.Abs(diff.Y))
                {
                    entity.AddComponent(new LinkKnockback(Constants.Direction.RIGHT, distance, frames));
                    // Console.WriteLine("Enemy is left from link!");
                }

                // Debug; If this ever gets output, something is wrong.
                else
                {
                    Console.WriteLine("Enemy was unrecognized direction!");
                }
            }
        }

        public override void ResolveCollision(MovableCollisionResponse other)
        {
            if (other.entity.GetComponent<BlockMovement>() != null)
            {

            } else
            {
                var transform = entity.GetComponent<Transform>();
                transform.position = transform.lastPosition;
            }
        }

        public override void ResolveCollision(MovableKeyCollisionResponse other)
        {
            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(InvisibleBlockCollisionResponse other)
        {
            // step back one frame of motion

            // access Link transform
            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

    }
}