using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Link;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class SwordCollisionResponse : ECS.Components.CollisionResponse
    {
        public SwordCollisionResponse(Entity entity) : base(entity)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

    }
}