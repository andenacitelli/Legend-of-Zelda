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
    public class WideLinkCollisionResponse : ECS.Components.CollisionResponse
    {
        public WideLinkCollisionResponse(Entity entity) : base(entity)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {
            entity.GetComponent<Collider>().CollidingWithRigid = true;
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {
            entity.GetComponent<Collider>().CollidingWithRigid = true;
        }









        public override void ResolveCollision(MovableCollisionResponse other)
        {
            if (other.entity.GetComponent<BlockMovement>() != null)
            {

            }
            else
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