using game_project.ECS.Components;
using game_project.GameObjects.Block;
using game_project.Levels;
using Microsoft.Xna.Framework;

// Similar to GameObjects.Layout.LevelParentBehavior
namespace game_project.CollisionResponse
{
    class LinkLevelBehavior : BehaviorScript
    {
        private bool moving = false;
        private float deltaT = .025f;
        private Vector2 goal;
        private Vector2 start;
        private float t = 0;

        public override void Update(GameTime gameTime)
        {
            var transform = entity.GetComponent<Transform>();

            if (moving)
            {
                transform.position = Vector2.Lerp(start, goal, t);
                t += deltaT;

                if (t >= 1f)
                {
                    moving = false;
                    t = 0;
                }
            }
        }

        public void Move(Constants.Direction direction)
        {
            moving = true;

            goal = entity.GetComponent<Transform>().position;
            int offsetUpDown = -270;
            int offsetLeftRight = -310;
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