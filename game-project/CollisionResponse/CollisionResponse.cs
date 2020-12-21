using System;
using game_project.CollisionResponse;

namespace game_project.ECS.Components
{
    // Visitor Pattern
    public class CollisionResponse
    {
        public Entity entity;

        public bool enabled = true;
        public CollisionResponse(Entity e)
        {
            entity = e;
        }

        public virtual void ResolveCollision(BaseCollisionResponse other) { }
        public virtual void ResolveCollision(RigidCollisionResponse other) { }
        public virtual void ResolveCollision(WallCollisionResponse other) { }
        public virtual void ResolveCollision(StairsCollisionResponse other) { }
        public virtual void ResolveCollision(BombCollisionResponse other) { }
        public virtual void ResolveCollision(MovableCollisionResponse other) { }
        public virtual void ResolveCollision(EnemyCollisionResponse other) { }
        public virtual void ResolveCollision(BoomerangCollisionResponse other) { }
        public virtual void ResolveCollision(BladeTrapCollisionResponse other) { }
        public virtual void ResolveCollision(KeeseCollisionResponse other) { }
        public virtual void ResolveCollision(LinkCollisionResponse other) { }
        public virtual void ResolveCollision(DoorCollisionResponse other) { }
        public virtual void ResolveCollision(FirstItemCollisionResponse other) { }
        public virtual void ResolveCollision(InvisibleBlockCollisionResponse other) { }
        public virtual void ResolveCollision(SpecialItemCollisionResponse other) { }
        public virtual void ResolveCollision(ItemCollisionResponse other) { }
        public virtual void ResolveCollision(MovableKeyCollisionResponse other) { }
        public virtual void ResolveCollision(FireballCollisionResponse other) { }
        public virtual void ResolveCollision(SwordCollisionResponse other) { }
        public virtual void ResolveCollision(SwordBeamCollisionResponse other) { }
        public virtual void ResolveCollision(WideLinkCollisionResponse other) { }

        public virtual void Visit(CollisionResponse other) { }
    }

    public class BaseCollisionResponse : CollisionResponse
    {
        public BaseCollisionResponse(Entity e) : base(e)
        {
        }

        public override void Visit(CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(RigidCollisionResponse other)
        {

        }

        public override void ResolveCollision(MovableCollisionResponse other)
        {

        }

        public override void ResolveCollision(EnemyCollisionResponse other)
        {

        }

        public override void ResolveCollision(BoomerangCollisionResponse other)
        {

        }

        public override void ResolveCollision(LinkCollisionResponse other)
        {

        }

        public override void ResolveCollision(BaseCollisionResponse other)
        {

        }

        public override void ResolveCollision(DoorCollisionResponse other)
        {

        }

        public override void ResolveCollision(FirstItemCollisionResponse other)
        {

        }

        public override void ResolveCollision(InvisibleBlockCollisionResponse other)
        {

        }
        public override void ResolveCollision(SpecialItemCollisionResponse other)
        {
            // no impact
        }

        public override void ResolveCollision(ItemCollisionResponse other)
        {

        }

        public override void ResolveCollision(BladeTrapCollisionResponse other)
        {

        }
    }
}
