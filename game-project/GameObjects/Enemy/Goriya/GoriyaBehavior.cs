using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.GameObjects.Projectiles;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using System;

namespace game_project.GameObjects.Enemy
{
    class GoriyaBehavior : BehaviorScript
    {
        private State state;
        private enum State
        {
            MOVING, // Moving (for sprint 2, just in a square)
            THROWING // Boomerang has been thrown and this is just still
        }

        // sprites        
        protected BasicSprite GoriyaLeft;
        protected BasicSprite GoriyaRight;
        protected BasicSprite GoriyaUp;
        protected BasicSprite GoriyaUpFlipped;
        protected BasicSprite GoriyaDown;
        protected BasicSprite GoriyaDownFlipped;

        // Direction this Goriya is translating
        // Uses Constants.Direction enum
        private Constants.Direction direction;

        // Constants used by states
        private const int framesUntilTurn = 50; // Total frames to go straight until turning
        private int framesUntilThrow; // Total frames to go until throwing a boomerang
        private int framesSinceTurn; // Frames we've been moving since we last turned
        private int framesSinceThrow; // Frames we've been moving since the throw (note: when we are waiting for throw to get back to us, doesn't increment)

        private int framesBeforeLastFlip;

        private bool throwing; // The boomerang is actively out
        private int timeBoomerangIsOut = 0;

        private int health = Constants.GORIYA_HEALTH;

        public GoriyaBehavior(string color)
        {
            // Initial State
            state = State.MOVING;
            direction = Constants.Direction.RIGHT;
            framesSinceTurn = 0;
            framesSinceThrow = 0;
            framesBeforeLastFlip = 0;

            framesUntilThrow = Constants.GetRandomIntMinMax(50, 90);

            // sprites
            if (color.Equals("red"))
            {
                GoriyaLeft = EnemySpriteFactory.Instance.CreateRedGoriyaLeft();
                GoriyaRight = EnemySpriteFactory.Instance.CreateRedGoriyaRight();
                GoriyaUp = EnemySpriteFactory.Instance.CreateRedGoriyaUp();
                GoriyaUpFlipped = EnemySpriteFactory.Instance.CreateRedGoriyaUpFlipped();
                GoriyaDown = EnemySpriteFactory.Instance.CreateRedGoriyaDown();
                GoriyaDownFlipped = EnemySpriteFactory.Instance.CreateRedGoriyaDownFlipped();
            }
            else
            {
                GoriyaLeft = EnemySpriteFactory.Instance.CreateBlueGoriyaLeft();
                GoriyaRight = EnemySpriteFactory.Instance.CreateBlueGoriyaRight();
                GoriyaUp = EnemySpriteFactory.Instance.CreateBlueGoriyaUp();
                GoriyaUpFlipped = EnemySpriteFactory.Instance.CreateBlueGoriyaUpFlipped();
                GoriyaDown = EnemySpriteFactory.Instance.CreateBlueGoriyaDown();
                GoriyaDownFlipped = EnemySpriteFactory.Instance.CreateBlueGoriyaDownFlipped();
            }
        }

        // TODO: Change to a delta time instead of a GameTime
        public override void Update(GameTime gameTime)
        {
            if (((Enemy)entity).frozen)
            {
                return;
            }

            var transform = entity.GetComponent<Transform>();
            var sprite = entity.GetComponent<Sprite>();

            switch (state)
            {
                case State.MOVING:
                    sprite.SetAnimate(true);
                    Moving(gameTime, transform, sprite);
                    break;
                case State.THROWING:
                    sprite.SetAnimate(false);
                    Throwing();
                    break;
                default:
                    Console.WriteLine("RedGoriyaBehavior @ Update(): Unrecognized state!");
                    break;
            }
        }

        // Translate in the direction we are currently moving, turning right if we've hit the frame cap and transitioning to Throwing() if we hit that (different) frame cap
        private void Moving(GameTime gameTime, Transform transform, Sprite sprite)
        {
            // Translate for this frame 
            Translate(gameTime, transform, sprite);

            // Handle Turning
            framesSinceTurn++;
            if (framesSinceTurn >= framesUntilTurn)
            {
                NewDirection(sprite);
                framesSinceTurn = 0;
            }

            // Handle Throwing
            framesSinceThrow++;
            if (framesSinceThrow >= framesUntilThrow)
            {
                state = State.THROWING;
                framesSinceThrow = 0;
            }
        }

        // Executed during state where we are either
        // (1) throwing boomerang this frame or
        // (2) Waiting for the boomerang to come back to us
        private void Throwing()
        {
            // If we haven't thrown, throw
            if (!throwing)
            {
                throwing = true;
                ThrowBoomerang();
                timeBoomerangIsOut = 0;
            }

            // Otherwise, just move the boomerang one more frame and check if it's back to us yet
            else
            {
                // TODO: Instead of hardcoding # of frames, make boomerang pos static or smth
                timeBoomerangIsOut++;
                if (timeBoomerangIsOut >= Constants.GORIYA_BOOMERANG_FRAMES)
                {
                    state = State.MOVING;
                    throwing = false;
                }
            }
        }

        // Actually throws the boomerang
        private void ThrowBoomerang()
        {
            new Boomerang(direction, entity);
        }

        // Helper function that moves the Goriya one frame in its current direction
        private void Translate(GameTime gameTime, Transform transform, Sprite sprite)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (direction)
            {
                case Constants.Direction.UP:
                    transform.position.Y -= delta * Constants.GORIYA_MOVEMENT_SPEED;

                    // Handle Flipping
                    framesBeforeLastFlip++;
                    if (framesBeforeLastFlip == Constants.GORIYA_FRAMES_TO_FLIP_AT) // reset timer and flip back
                    {
                        framesBeforeLastFlip = 0;
                        sprite.SetSprite(GoriyaUp);
                    }
                    else if (framesBeforeLastFlip == Constants.GORIYA_FRAMES_TO_FLIP_AT / 2) // flip
                    {
                        sprite.SetSprite(GoriyaUpFlipped);
                    }

                    break;
                case Constants.Direction.DOWN:
                    transform.position.Y += delta * Constants.GORIYA_MOVEMENT_SPEED;

                    // Handle Flipping
                    framesBeforeLastFlip++;
                    if (framesBeforeLastFlip == Constants.GORIYA_FRAMES_TO_FLIP_AT) // reset timer and flip back
                    {
                        framesBeforeLastFlip = 0;
                        sprite.SetSprite(GoriyaDown);
                    }
                    else if (framesBeforeLastFlip == Constants.GORIYA_FRAMES_TO_FLIP_AT / 2) // flip
                    {
                        sprite.SetSprite(GoriyaDownFlipped);
                    }

                    break;
                case Constants.Direction.LEFT:
                    transform.position.X -= delta * Constants.GORIYA_MOVEMENT_SPEED;
                    sprite.SetSprite(GoriyaLeft);
                    break;
                case Constants.Direction.RIGHT:
                    transform.position.X += delta * Constants.GORIYA_MOVEMENT_SPEED;
                    sprite.SetSprite(GoriyaRight);
                    break;
                default:
                    Console.WriteLine("RedGoriyaBehavior @ Translate(): Unrecognized direction!");
                    break;
            }
        }

        // Helper function to choose a new direction
        private void NewDirection(Sprite sprite)
        {
            direction = Constants.RandomEnumValue<Constants.Direction>();
            switch (direction)
            {
                case Constants.Direction.UP:
                    direction = Constants.Direction.RIGHT;
                    sprite.SetSprite(GoriyaRight);
                    break;
                case Constants.Direction.RIGHT:
                    direction = Constants.Direction.DOWN;
                    sprite.SetSprite(GoriyaDown);
                    break;
                case Constants.Direction.DOWN:
                    direction = Constants.Direction.LEFT;
                    sprite.SetSprite(GoriyaLeft);
                    break;
                case Constants.Direction.LEFT:
                    direction = Constants.Direction.UP;
                    sprite.SetSprite(GoriyaUp);
                    break;
                default:
                    Console.WriteLine("RedGoriyaBehavior @ TurnRight(): Unrecognized direction!");
                    break;
            }
        }
    }
}
