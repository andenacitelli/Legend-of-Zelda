using System;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class WallMasterMovement : BehaviorScript
    {
        // state enum
        private State state;
        private enum State
        {
            ROAMING, // looking around
            GRABBED // grabbed player
        };

        private Constants.Direction direction;

        // variables tracked during states
        private int directionSwitchCurrent; // how long we have waited       
        private int health = Constants.WALLMASTER_HEALTH;

        public WallMasterMovement(Constants.Direction startingDirection)
        {
            // initial state
            state = State.ROAMING;
            direction = startingDirection;

            // initial values
            directionSwitchCurrent = 0;
        }
        public override void Update(GameTime gameTime)
        {
            if (((Enemy)entity).frozen)
            {
                return;
            }

            var transform = entity.GetComponent<Transform>();

            switch (state)
            {
                case State.ROAMING:
                    Roaming(gameTime, transform);
                    break;
                case State.GRABBED:
                    Grabbed();
                    break;
                default:
                    Console.WriteLine("WallMaster swtiched to unrecognized state.");
                    break;
            }
        }

        private void Roaming(GameTime gameTime, Transform transform)
        {
            // Modify position
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (direction)
            {
                case Constants.Direction.UP:
                    transform.position.Y -= delta * Constants.WALLMASTER_MOVEMENT_SPEED;
                    break;
                case Constants.Direction.DOWN:
                    transform.position.Y += delta * Constants.WALLMASTER_MOVEMENT_SPEED;
                    break;
                case Constants.Direction.LEFT:
                    transform.position.X -= delta * Constants.WALLMASTER_MOVEMENT_SPEED;
                    break;
                case Constants.Direction.RIGHT:
                    transform.position.X += delta * Constants.WALLMASTER_MOVEMENT_SPEED;
                    break;
                default:
                    Console.WriteLine("WallMaster roaming switch statement reached default!");
                    break;
            }

            // increase direction switch current and see if we need to change direction
            directionSwitchCurrent++;
            if (directionSwitchCurrent == Constants.WALLMASTER_DIRECTION_SWITCH_WAIT)
            {
                directionSwitchCurrent = 0; // reset
                SwitchDirection();
            }
        }

        private void Grabbed()
        {
            var sprite = entity.GetComponent<Sprite>();
            sprite.SetAnimate(false);       // stop animation
            sprite.sprite.currentFrame = 1; // set frame to grabbed regardless
            // set back to roaming
            state = State.ROAMING;
        }

        private void SwitchDirection()
        {
            direction = Constants.RandomEnumValue<Constants.Direction>();
        }
    }
}
