using game_project.Levels;

namespace game_project.Commands
{
    class CommandPlayPause : ICommand
    {
        public void Execute()
        {
            if (GameStateManager.State == GameStates.Paused)
            {
                GameStateManager.State = GameStates.Playing;
                LevelManager.mapRoot.State = EntityStates.Playing;
                LevelManager.pausedText.State = EntityStates.Disabled;
            }
            else if (GameStateManager.State == GameStates.Playing)
            {
                GameStateManager.State = GameStates.Paused;
                LevelManager.mapRoot.State = EntityStates.Paused;
                LevelManager.pausedText.State = EntityStates.Playing;
            }
        }
    }
}
