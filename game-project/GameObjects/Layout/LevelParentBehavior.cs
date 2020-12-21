using game_project.CollisionResponse;
using game_project.ECS.Components;
using game_project.GameObjects.Block;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Layout
{
    class LevelParentBehavior : BehaviorScript
    {
        private bool moving = false;
        private float deltaT = .015f;
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

                    // Pause the Level you've just left
                    LevelManager.previousLevel.Root.State = EntityStates.Paused;
                    LevelManager.previousLevel = LevelManager.currentLevel;
                    LevelManager.previousLevel = LevelManager.currentLevel;
                }
            }

        }

        public void Move(Constants.Direction direction)
        {
            moving = true;

            goal = entity.GetComponent<Transform>().position;
            switch (direction)
            {
                case Constants.Direction.UP:
                    goal.Y += Level.screen_height;
                    break;
                case Constants.Direction.LEFT:
                    goal.X += Level.screen_width;
                    break;
                case Constants.Direction.RIGHT:
                    goal.X -= Level.screen_width;
                    break;
                case Constants.Direction.DOWN:
                    goal.Y -= Level.screen_height;
                    break;
            }
            start = entity.GetComponent<Transform>().position;
        }
    }
}
