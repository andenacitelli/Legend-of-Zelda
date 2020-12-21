using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Link;

namespace game_project.CollisionResponse
{
    public class FireballCollisionResponse : ECS.Components.CollisionResponse
    {
        // Damage that the enemy linked to this given collider does to the player 
        public int damage;
        public Entity owner;

        public FireballCollisionResponse(Entity e) : base(e)
        {
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {
            Entity.Destroy(entity);
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {
            Entity.Destroy(entity);
        }
    }
}
