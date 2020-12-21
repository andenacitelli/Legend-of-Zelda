using game_project.ECS;
using game_project.ECS.Components;

namespace game_project.CollisionResponse
{
    public class RigidCollisionResponse : ECS.Components.CollisionResponse
    {
        public RigidCollisionResponse(Entity e) : base(e)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

    }
}
