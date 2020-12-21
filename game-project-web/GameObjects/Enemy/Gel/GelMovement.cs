using System;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class GelMovement : BehaviorScript
    {
        // speed
        private readonly float speed; // Multiplicative speed constant

        private int timer;
        private readonly int initialStopTime;
        private readonly int moveAgainTime;
        private readonly int changeDirectionTime;

        // direction of gel
        private Constants.Direction direction;

        // state
        private State state;
        private enum State
        {
            STILL, // not moving
            MOVING // moving and animating
        };

        public GelMovement()
        {
            // initial values
            direction = Constants.RandomEnumValue<Constants.Direction>();
            state = State.STILL;

            timer = 0;

            // constant value
            speed = .2f;
        }

        public override void Update(GameTime gameTime)
        {
            if (((Enemy)entity).frozen)
            {
                return;
            }

            var transform = entity.GetComponent<Transform>();
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            switch (state)
            {
                case State.STILL:
                    break;
                case State.MOVING:
                    MoveGel(transform, delta);
                    break;
                default:
                    Console.WriteLine("KeeseMovement @ Update(): Unrecognized state!");
                    break;
            }

            timer++;
            // initial movement in direction
            if (timer < Constants.GEL_INITIAL_STOP_TIME)
            {
                state = State.MOVING;
            }
            // stop period
            else if (Constants.GEL_INITIAL_STOP_TIME < timer && timer < Constants.GEL_MOVE_AGAIN_TIME)
            {
                state = State.STILL;
            }
            // move again
            else if (Constants.GEL_MOVE_AGAIN_TIME < timer && timer < Constants.GEL_CHANGE_DIRECTION_TIME)
            {
                state = State.MOVING;
            }
            // change direction
            else if (timer == Constants.GEL_CHANGE_DIRECTION_TIME)
            {
                timer = 0; // reset timer
                direction = Constants.RandomEnumValue<Constants.Direction>();
            }

        }
        private void MoveGel(Transform transform, float delta)
        {
            switch (direction)
            {
                case Constants.Direction.UP:
                    transform.position.Y -= delta * speed;
                    break;
                case Constants.Direction.DOWN:
                    transform.position.Y += delta * speed;
                    break;
                case Constants.Direction.LEFT:
                    transform.position.X -= delta * speed;
                    break;
                case Constants.Direction.RIGHT:
                    transform.position.X += delta * speed;
                    break;
                default:
                    Console.WriteLine("GelMovement: Unrecognized position transition!");
                    break;
            }
        }
    }
}
