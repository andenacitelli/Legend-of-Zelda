using game_project.Levels;

namespace game_project.Commands
{
    class CommandDebugFPS : ICommand
    {
        public void Execute()
        {
            LevelManager.showFPS = !LevelManager.showFPS;
        }
    }
}
