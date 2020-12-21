using System;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.Link;
using Microsoft.Xna.Framework;

namespace game_project.CollisionResponse
{
    public class BladeTrapCollisionResponse : EnemyCollisionResponse
    {
        public BladeTrapCollisionResponse(Entity e, int damage) : base(e, Constants.BLADETRAP_CONTACT_DAMAGE)
        {

        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        /* Want to reverse direction if it hits link, another blade trap, or a wall. */

        public override void ResolveCollision(LinkCollisionResponse other)
        {
            BladeTrapMovement btMovement = entity.GetComponent<BladeTrapMovement>();
            if (entity.GetComponent<BladeTrapMovement>().state == BladeTrapMovement.State.EXTENDING)
            {
                btMovement.ReverseDirection();
            }
        }

        public override void ResolveCollision(WallCollisionResponse other)
        {
            // Console.WriteLine("BladeTrap detected wall collision!");
            BladeTrapMovement btMovement = entity.GetComponent<BladeTrapMovement>();

            // If this isn't a collision with one of the far walls, get out
            // Top-Left Blade Trap colliding with top or left walls 
            if (entity.GetComponent<BladeTrapMovement>().homePos.X < 400 && entity.GetComponent<BladeTrapMovement>().homePos.Y < 400 &&
                (other.entity.GetComponent<Transform>().position.Y < 400 || other.entity.GetComponent<Transform>().position.X < 200)) {
                return;
            }

            // Top-Right Blade Trap colliding with top or right walls 
            if (entity.GetComponent<BladeTrapMovement>().homePos.X > 400 && entity.GetComponent<BladeTrapMovement>().homePos.Y < 400 &&
                (other.entity.GetComponent<Transform>().position.Y < 400 || other.entity.GetComponent<Transform>().position.X > 600)) {
                return;
            }

            // I have ZERO clue why I only need to do it for the top two blade traps. I spent two hours debugging it. Don't ask. 

            // Mandate it's currently extending and isn't colliding with the wall right next to homePos
            if (entity.GetComponent<BladeTrapMovement>().state == BladeTrapMovement.State.EXTENDING)
                // && Vector2.Distance(entity.GetComponent<BladeTrapMovement>().homePos, entity.GetComponent<Transform>().position) >= 5)
            {
                btMovement.ReverseDirection();
            }
        }

        public override void ResolveCollision(BladeTrapCollisionResponse other)
        {
            BladeTrapMovement btMovement = entity.GetComponent<BladeTrapMovement>();
            if (entity.GetComponent<BladeTrapMovement>().state == BladeTrapMovement.State.EXTENDING)
            {
                btMovement.ReverseDirection();
            }
        }


        /* Last three are to override the "don't clip into walls" feature. */
        public override void ResolveCollision(RigidCollisionResponse other)
        {
            // Just overriding

            BladeTrapMovement btMovement = entity.GetComponent<BladeTrapMovement>();
            btMovement.ReverseDirection();
        }

        public override void ResolveCollision(DoorCollisionResponse other)
        {
            // Just overriding
        }
    }
}
