using game_project.Levels;

namespace game_project.Commands
{
    class CommandItemSelection : ICommand
    {
        public void Execute()
        {
            // TODO: pause after the item selection screen has moved the level down.
            if (GameStateManager.State == GameStates.Playing)
            {
                GameStateManager.State = GameStates.ItemSelection;
                LevelManager.mapRoot.State = EntityStates.Paused;
            }
            else if (GameStateManager.State == GameStates.ItemSelection)
            {
                GameStateManager.State = GameStates.Playing;
                LevelManager.mapRoot.State = EntityStates.Playing;
            }
        }
    }
}
