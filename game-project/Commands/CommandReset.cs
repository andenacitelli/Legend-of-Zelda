using game_project.Levels;
using game_project.Sounds;

namespace game_project.Commands
{
    class CommandReset : ICommand
    {

        // Tells Program to run the program again, then exits
        public void Execute()
        {
            Sound.StopAllSounds();
            LevelManager.Reset();
            Sound.PlayTrack(Sound.Tracks.Underworld);
        }
    }
}
