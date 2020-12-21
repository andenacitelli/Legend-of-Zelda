using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    class ItemMovement : BehaviorScript
    {
        private bool moving;
        private int framesToDraw, framesDrawn;

        private Constants.Direction directionThrown; // Enum for directions => LinkState.directions
        private bool disappearing;

        public ItemMovement(bool moving, bool disappearing, int framesToDraw, Constants.Direction directionThrown)
        {
            this.moving = moving;
            this.disappearing = disappearing;
            this.framesToDraw = framesToDraw;
            this.directionThrown = directionThrown;

            this.framesDrawn = 0;
        }

        // Translate in the direction specified for the specified number of frames, then self-destruct
        public override void Update(GameTime gameTime)
        {
            // Handles sprites that disappear after a certain amount of time
            if (disappearing)
            {
                framesDrawn++;
                if (framesDrawn > framesToDraw)
                {
                    Entity.Destroy(entity);
                }
            }

            // Handles sprites that move 
            if (moving)
            {
                var transform = entity.GetComponent<Transform>();
                float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                switch (directionThrown)
                {
                    // Up
                    case Constants.Direction.UP:
                        transform.position.Y -= delta * Constants.ITEM_MOVEMENT_SPEED;
                        break;

                    // Left
                    case Constants.Direction.LEFT:
                        transform.position.X -= delta * Constants.ITEM_MOVEMENT_SPEED;
                        break;

                    // Down 
                    case Constants.Direction.DOWN:
                        transform.position.Y += delta * Constants.ITEM_MOVEMENT_SPEED;
                        break;

                    // Right
                    case Constants.Direction.RIGHT:
                        transform.position.X += delta * Constants.ITEM_MOVEMENT_SPEED;
                        break;
                }
            }
        }
    }
}
