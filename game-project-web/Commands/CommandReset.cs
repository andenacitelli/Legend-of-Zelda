using game_project.Levels;
using game_project.Sounds;

namespace game_project.Commands
{
    class CommandReset : ICommand
    {

        // Tells Program to run the program again, then exits
        public void Execute()
        {
            LevelManager.Reset();
            Sound.StopAllSounds();
            //Program.shouldReset = true;
            //new CommandExit().Execute();
        }
    }
}
