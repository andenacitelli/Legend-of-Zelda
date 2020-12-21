using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.Commands
{
    class CommandBossRush : ICommand
    {
        public void Execute()
        {
            // Shouldn't "transition" to Boss rush if boss rush already exists
            if (Game1.inBossRush)
                return;

            Sound.StopAllSounds();
            // Stored in Game1 class so we don't lose all references and
            // become at the mercy of the garbage collector
            Game1.bossRush = new BossRush();
        }
    }
}
