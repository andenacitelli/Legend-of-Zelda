using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Link;
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
            Entity.Destroy(entity);
        }

    }
}