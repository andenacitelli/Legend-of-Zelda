using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class BackdropBehavior : BehaviorScript
    {
        enum OpenClose
        {
            Open, Closed, Opening, Closing
        }

        private OpenClose openState = OpenClose.Closed;

        float t = 0;
        float deltaT = 0.03f;

        private Vector2 start = new Vector2(0, -Game1.viewport.Height + (Game1.viewport.Height - Level.screen_height));
        private Vector2 goal = new Vector2(0, 0);

        public override void Update(GameTime gameTime)
        {
            var transform = entity.GetComponent<Transform>();

            switch (openState)
            {
                case OpenClose.Open:
                    // do nothing, the panel is open
                    // allow for item selection?
                    if (GameStateManager.State == GameStates.Playing)
                    {
                        openState = OpenClose.Closing;
                    }
                    break;
                case OpenClose.Closed:
                    // do nothing, the panel is closed
                    if (GameStateManager.State == GameStates.ItemSelection)
                    {
                        openState = OpenClose.Opening;
                    }
                    break;
                case OpenClose.Opening:
                    // lerp to open position

                    transform.position = Vector2.Lerp(start, goal, t);
                    t += deltaT;

                    if (t >= 1f)
                    {
                        openState = OpenClose.Open;
                        t = 0;
                    }
                    break;
                case OpenClose.Closing:
                    // lerp to closed position

                    transform.position = Vector2.Lerp(goal, start, t);
                    t += deltaT;

                    if (t >= 1f)
                    {
                        openState = OpenClose.Closed;
                        t = 0;
                    }
                    break;
            }
        }
    }
}
