using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.Levels
{
    public enum GameStates
    {
        Playing,
        Paused,
        Defeat,
        Victory,
        ItemSelection
    }

    public enum EntityStates
    {
        Playing, // Update() and Draw()
        Paused, // Draw() but do not Update()
        Disabled, // do not Update() or Draw()
        // Deleted, // ToDo: move setForDeletion to here perhaps
    }


    public static class GameStateManager
    {
        public static GameStates State = GameStates.Playing;
        //public static GameStates State = GameStates.ItemSelection;
    }
}
