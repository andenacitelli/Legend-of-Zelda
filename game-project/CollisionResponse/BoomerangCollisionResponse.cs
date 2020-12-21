using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Link;
using game_project.Levels;

namespace game_project.CollisionResponse
{
    public class BoomerangCollisionResponse : ECS.Components.CollisionResponse
    {
        // Damage that the enemy linked to this given collider does to the player 
        public int damage;
        public Entity owner;

        public BoomerangCollisionResponse(Entity e, Entity o, int damage) : base(e)
        {
            this.damage = damage;
            owner = o;
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {

            var transform = entity.GetComponent<Transform>();
            transform.position = transform.lastPosition;
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {

            //var transform = entity.GetComponent<Transform>();
            //transform.position = transform.lastPosition;
        }


        public override void ResolveCollision(LinkCollisionResponse other)
        {
            var link = other.entity;
            var linkBehavior = link.GetComponent<LinkBehavior>();
            if (linkBehavior.attacking)
            {
                Entity.Destroy(entity);
                LevelManager.EnemyKilled();
            }
        }

    }
}
