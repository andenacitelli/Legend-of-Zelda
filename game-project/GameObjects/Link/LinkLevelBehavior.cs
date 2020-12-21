using game_project.ECS.Components;
using game_project.GameObjects.Block;
using game_project.GameObjects.Layout;
using game_project.Levels;
using Microsoft.Xna.Framework;

// Similar to GameObjects.Layout.LevelParentBehavior
namespace game_project.CollisionResponse
{
    class LinkLevelBehavior : BehaviorScript
    {
        private float deltaT = .015f;
        private Vector2 goal;
        private Vector2 start;
        private float t = 0;
        private Constants.Direction direction = Constants.Direction.UP;

        private readonly int waitCount = 60;
        private int waitCounter = 0;

        private enum State
        {
            Reset,
            Beginning,
            Move1,
            Wait,
            Move2,
        }

        private State state = State.Reset;

        public override void Update(GameTime gameTime)
        {
            var transform = entity.GetComponent<Transform>();

            switch (state)
            {
                case State.Reset:
                    // reset doors and stuff
                    GameStateManager.Transition = false;
                    foreach (DoorCollisionResponse d in Door.doorResponses)
                    {
                        d.enabled = true;
                    }
                    state = State.Beginning;
                    break;
                case State.Beginning:
                    //do nothing, wait for Move() to be called
                    state = State.Beginning;
                    break;
                case State.Move1:
                    // move then stop halfway and wait
                    transform.position = Vector2.Lerp(start, goal, t);
                    t += deltaT;

                    if (t >= .4f)
                    {
                        LevelManager.mapRoot.GetComponent<LevelParentBehavior>().Move(direction);

                        state = State.Wait;
                    }
                    break;
                case State.Wait:
                    // wait a while
                    if (waitCounter < waitCount)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        waitCounter = 0;
                        state = State.Move2;
                    }
                    break;
                case State.Move2:
                    // move the rest of the way
                    transform.position = Vector2.Lerp(start, goal, t);
                    t += deltaT;

                    if (t >= 1f)
                    {
                        // return control to the player
                        state = State.Reset;
                        t = 0;
                    }
                    break;
            }

        }

        public void Move(Constants.Direction direction)
        {
            state = State.Move1;

            goal = entity.GetComponent<Transform>().position;
            int offsetUpDown = -270;
            int offsetLeftRight = -270;
            this.direction = direction;
            switch (direction)
            {
                case Constants.Direction.UP:
                    goal.Y += offsetUpDown;
                    break;
                case Constants.Direction.LEFT:
                    goal.X += offsetLeftRight;
                    break;
                case Constants.Direction.RIGHT:
                    goal.X -= offsetLeftRight;
                    break;
                case Constants.Direction.DOWN:
                    goal.Y -= offsetUpDown;
                    break;
            }
            start = entity.GetComponent<Transform>().position;
        }
    }
}