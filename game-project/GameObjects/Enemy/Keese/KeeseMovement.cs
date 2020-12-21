using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System;

namespace game_project.GameObjects.Enemy
{
    class KeeseMovement : BehaviorScript
    {
        // states
        private State state;
        private enum State
        {
            STILL, // not moving
            MOVING // moving and animating
        };

        // variables
        private int deltaX;
        private float direction;

        private int currentFrame;
        private int movementFrame;

        private int health = Constants.KEESE_HEALTH;

        private static Random random = new Random(); // random number generator, shared among all keese instances

        public KeeseMovement()
        {
            currentFrame = 0;
            movementFrame = Constants.GetRandomIntMinMax(100, 200);
            state = State.STILL;
            deltaX = Constants.KEESE_DELTA_X;

            direction = (float)Math.Cos(random.Next(0, 360));
        }

        public override void Update(GameTime gameTime)
        {
            if (((Enemy)entity).frozen)
            {
                return;
            }

            var transform = entity.GetComponent<Transform>();
            var sprite = entity.GetComponent<Sprite>();

            if (currentFrame % 30 == 0)
            {
                GetNewDirection();
            }

            if (currentFrame == movementFrame)
            {
                state = State.MOVING;
                sprite.SetAnimate(true);
                sprite.SetUpdateFrameSpeed(8);
            }
            else if (currentFrame == 2 * movementFrame) // speed up
            {
                sprite.SetUpdateFrameSpeed(5);
            }
            else if (currentFrame == 3 * movementFrame)
            {
                deltaX = -deltaX; // swtich direction
            }
            else if (currentFrame == 4 * movementFrame) // slow down
            {
                sprite.SetUpdateFrameSpeed(8);
            }
            else if (currentFrame == 5 * movementFrame)
            {
                currentFrame = 0; // reset current frame
                movementFrame = Constants.GetRandomIntMinMax(100, 200); // get new movement time
                state = State.STILL;
                sprite.SetAnimate(false);
            }
            currentFrame++;

            switch (state)
            {
                case State.STILL:
                    break;
                case State.MOVING:
                    MoveKeese(transform);
                    break;
                default:
                    Console.WriteLine("KeeseMovement @ Update(): Unrecognized state!");
                    break;
            }
        }

        private void GetNewDirection()
        {
            direction = (float)Math.Cos(random.Next(0, 360));
        }

        private void MoveKeese(Transform transform)
        {
            transform.position.X += Constants.KEESE_MOVEMENT_SPEED * deltaX;
            transform.position.Y += Constants.KEESE_MOVEMENT_SPEED * deltaX * direction;
        }
    }
}