using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;
using System;

namespace game_project.GameObjects.Enemy
{
    class BladeTrapMovement : BehaviorScript
    {
        public State state;

        public enum State
        {
            WAITING, // Waiting for the player to be either horizontal or vertical from the blade trap 
            EXTENDING, // Extending until it hits something (for now, hardcoded for just a time)
            RETRACTING // Retracting back to where it came
        };

        /* Directions are from LinkState.directions enum. Set to -1 if not moving. */
        // TODO: Relocate LinkState.directions enum to somewhere more general
        private Constants.Direction direction;

        // Variables tracked during certain states
        public Vector2 homePos; // When we transition WAITING -> Either of the other two, track where we started

        public BladeTrapMovement()
        {
            // Initial State
            state = State.WAITING;
            direction = Constants.Direction.UP; // Doesn't need a default, but here to be safe 
        }

        public override void Update(GameTime gameTime)
        {
            // If homepos hasn't been initialized, initialize it to current pos
            // These values are never realistically achieved due to wall bounds so it's fine to check
            // Can't do this in constructor because entity isn't initialized yet 
            if (homePos.X == 0 && homePos.Y == 0)
            {
                homePos = entity.GetComponent<Transform>().position;
            }

            // Console.WriteLine("BladeTrap Update.");
            // Console.WriteLine("Current Pos: " + entity.GetComponent<Transform>().position);
            // Console.WriteLine("Current State: " + state);

            if (!LevelManager.currentLevelPath.Equals("1_0"))
            {
                Disabled();
                state = State.WAITING;
                return;
            }

            var transform = entity.GetComponent<Transform>();
            switch (state)
            {
                case State.EXTENDING:
                    //Console.WriteLine("Extending.");
                    Extending(gameTime);
                    break;
                case State.RETRACTING:
                    //Console.WriteLine("Retracting.");
                    Retracting(gameTime);
                    break;
                case State.WAITING:
                    //Console.WriteLine("Waiting.");
                    Waiting();
                    break;
                default:
                    //Console.WriteLine("Blade trap switched to unrecognized state.");
                    break;
            }
        }

        private void Disabled()
        {
            entity.GetComponent<Transform>().position = homePos;
        }

        // Move one more frame in our direction, then check if we collided. If we collided, set to retracting.
        // For sprint 2, we just go same direction
        private void Extending(GameTime gameTime)
        {
            // Modify position
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (direction)
            {
                case Constants.Direction.UP:
                    entity.GetComponent<Transform>().position.Y -= delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    break;
                case Constants.Direction.DOWN:
                    entity.GetComponent<Transform>().position.Y += delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    break;
                case Constants.Direction.LEFT:
                    entity.GetComponent<Transform>().position.X -= delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    break;
                case Constants.Direction.RIGHT:
                    entity.GetComponent<Transform>().position.X += delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    break;
                default:
                    //Console.WriteLine("BladeTrapMovement extending switch statement screwed up!");
                    break;
            }
        }

        // Move one frame in our current direction (the direction will be back to home). Transition back to moving once we cross either homePos x,y coord.
        private void Retracting(GameTime gameTime)
        {
            // Modify position
            // IMPORTANT: Doesn't work if you create a reference to transform.position and then change that.
            // Also checks if we're back at home position here, rather than doing two switch statements as done before
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (direction)
            {
                case Constants.Direction.UP:
                    entity.GetComponent<Transform>().position.Y -= delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    if (entity.GetComponent<Transform>().position.Y <= homePos.Y)
                    {
                        entity.GetComponent<Transform>().position = homePos;
                        state = State.WAITING;
                    }
                    break;
                case Constants.Direction.DOWN:
                    entity.GetComponent<Transform>().position.Y += delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    if (entity.GetComponent<Transform>().position.Y >= homePos.Y)
                    {
                        entity.GetComponent<Transform>().position = homePos;
                        state = State.WAITING;
                    }
                    break;
                case Constants.Direction.LEFT:
                    entity.GetComponent<Transform>().position.X -= delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    if (entity.GetComponent<Transform>().position.X <= homePos.X)
                    {
                        entity.GetComponent<Transform>().position = homePos;
                        state = State.WAITING;
                    }
                    break;
                case Constants.Direction.RIGHT:
                    entity.GetComponent<Transform>().position.X += delta * Constants.BLADETRAP_MOVEMENT_SPEED;
                    if (entity.GetComponent<Transform>().position.X >= homePos.X)
                    {
                        entity.GetComponent<Transform>().position = homePos;
                        state = State.WAITING;
                    }
                    break;
                default:
                    break;
            }
        }

        // If Link is within a small distance of either vertical or horizontal axis from us, move in that direction.
        private void Waiting()
        {
            // TODO: Convert all the rectangles to floating point. Only noticeable on the subpixel layer so it's not super important though.
            // Have to reconstruct a rectangle here because if we just grab the rectangle from the Sprite class it isn't the transform we expect (is instead on the spritesheet I think)
            
            // Grab a rectangle representing each entity at this point in time
            Entity link = Scene.Find("Link");
            Rectangle linkSpriteRect = link.GetComponent<Sprite>().sprite.frames[0];
            Vector2 linkTransform = link.GetComponent<Transform>().WorldPosition; // link.
            Rectangle linkRect = new Rectangle((int)linkTransform.X, (int)linkTransform.Y, linkSpriteRect.Width, linkSpriteRect.Height);

            Rectangle bladeSpriteRect = entity.GetComponent<Sprite>().sprite.frames[0];
            Vector2 bladeTransform = entity.GetComponent<Transform>().position;
            Rectangle bladeRect = new Rectangle((int)bladeTransform.X, (int)bladeTransform.Y, bladeSpriteRect.Width, bladeSpriteRect.Height);

            // Check if Link is horizontal
            if (HorizontallyAligned(linkRect, bladeRect))
            {
                // Console.WriteLine("BladeTrap at pos " + entity.GetComponent<Transform>().position + " detected link horiziontally!");
                state = State.EXTENDING;

                // If blade trap is to the left of Link right now
                if (linkRect.X >= bladeRect.X)
                {
                    // Console.WriteLine("BladeTrap going right.");
                    direction = Constants.Direction.RIGHT;
                }

                else
                {
                    // Console.WriteLine("BladeTrap going left.");
                    direction = Constants.Direction.LEFT;
                }
            }

            // Check if Link is vertical 
            else if (VerticallyAligned(linkRect, bladeRect))
            {
                // Console.WriteLine("BladeTrap at pos " + entity.GetComponent<Transform>().position + " detected link vertically!");
                state = State.EXTENDING;

                // If Blade trap is above Link right now
                if (linkRect.Y >= bladeRect.Y)
                {
                    // Console.WriteLine("BladeTrap going down.");
                    direction = Constants.Direction.DOWN;
                }

                else
                {
                    // Console.WriteLine("BladeTrap going up.");
                    direction = Constants.Direction.UP;
                }
            }

            else
            {
                // Console.WriteLine("BladeTrap at pos " + entity.GetComponent<Transform>().position + " detected nothing!");
            }
        }

        // Returns true if there's any vertical overlap between two rectangles
        private bool VerticallyAligned(Rectangle rect1, Rectangle rect2)
        {
            float rect1left = rect1.X, rect1right = rect1.X + rect1.Width;
            float rect2left = rect2.X, rect2right = rect2.X + rect2.Width;

            // bool returnValue = (rect2left >= rect1left && rect2left <= rect1right) || (rect2right >= rect1left && rect2right <= rect1right);
            bool returnValue = Math.Abs(rect1left - rect2left) <= 75;
            // Console.WriteLine("VerticallyAligned(): Given rect1 " + rect1.ToString() + " and rect2 " + rect2.ToString() + " function returned " + returnValue);

            // If left bound is between or if right bound is between 
            return returnValue;
        }

        // Returns true if there's any horizontal overlap between two rectangles
        private bool HorizontallyAligned(Rectangle rect1, Rectangle rect2)
        {
            float rect1top = rect1.Y, rect1bottom = rect1.Y + rect1.Height;
            float rect2top = rect2.Y, rect2bottom = rect2.Y + rect2.Height;

            // bool returnValue = (rect2top >= rect1top && rect2top <= rect1bottom) || (rect2bottom >= rect1top && rect2bottom <= rect1bottom);
            bool returnValue = Math.Abs(rect1top - rect2top) <= 75;
            // Console.WriteLine("HorizontallyAligned(): Given rect1 " + rect1.ToString() + " and rect2 " + rect2.ToString() + " function returned " + returnValue);

            // If left bound is between or if right bound is between 
            return returnValue;
        }

        // Helper function that reverses current direction (used in EXTENDING -> RETRACTING transition)
        public void ReverseDirection()
        {
            // Console.WriteLine("Reversing direction.");
            if (state == State.RETRACTING) state = State.EXTENDING;
            else state = State.RETRACTING;

            switch (direction)
            {
                case Constants.Direction.UP:
                    direction = Constants.Direction.DOWN;
                    break;
                case Constants.Direction.RIGHT:
                    direction = Constants.Direction.LEFT;
                    break;
                case Constants.Direction.DOWN:
                    direction = Constants.Direction.UP;
                    break;
                case Constants.Direction.LEFT:
                    direction = Constants.Direction.RIGHT; 
                    break;
                default:
                    //Console.WriteLine("BladeTrapMovement: Unrecognized direction transition!");
                    break;
            }
        }
    }
}
