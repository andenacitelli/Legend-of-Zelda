using game_project.ECS;
using game_project.ECS.Components;

namespace game_project.CollisionResponse
{
    public class InvisibleBlockCollisionResponse : ECS.Components.CollisionResponse
    {
        public InvisibleBlockCollisionResponse(Entity entity) : base(entity)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

    }
}
