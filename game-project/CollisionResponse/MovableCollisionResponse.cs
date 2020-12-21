using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Link;
using game_project;

namespace game_project.CollisionResponse
{
    // TODO: move EnemyCollisionResponse here

    public class MovableCollisionResponse : ECS.Components.CollisionResponse
    {
        private Constants.Direction direction;
        private bool done = false;
        public MovableCollisionResponse(Entity e, Constants.Direction direction) : base(e)
        {
            this.direction = direction;
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }


        public override void ResolveCollision(LinkCollisionResponse other)
        {
            if (!done && LinkBehavior.linkDirection == direction)
            {
                BehaviorScript script = new BlockMovement(direction);
                entity.AddComponent(script);
                done = true;
            }
        }

    }
}
