using game_project.Commands;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace game_project.Controllers
{
    class KeyboardController
    {
        Dictionary<Keys, ICommand> keymap;
        Dictionary<Keys, ICommand> keymapOneShot;

        public KeyboardController()
        {
            keymap = new Dictionary<Keys, ICommand>();
            keymapOneShot = new Dictionary<Keys, ICommand>();

            // keymapOneShot.Add(Keys.D1, new LinkUseBomb());
            // keymapOneShot.Add(Keys.D2, new CommandLinkUseBoomerang());

            // Show Colliders for debugging
            keymapOneShot.Add(Keys.OemSemicolon, new CommandDebugColliders());
            // Show Colliders for debugging
            keymapOneShot.Add(Keys.OemQuotes, new CommandDebugFPS());

            /* Other Controls */
            // Exit (q)
            keymap.Add(Keys.Q, new CommandExit());

            // Reset (r) 
            keymapOneShot.Add(Keys.R, new CommandReset());

            // Pause/Play (shift)
            keymapOneShot.Add(Keys.RightShift, new CommandPlayPause());
            // Inventory (e)
            keymapOneShot.Add(Keys.E, new CommandItemSelection());

            // Trigger Boss Rush (u)
            keymapOneShot.Add(Keys.U, new CommandBossRush());
        }

        public void Update()
        {
            // Iterate through all keys being pressed right now and fire their command if they are being pressed
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                if (keymap.TryGetValue(keys[i], out ICommand command))
                {
                    command.Execute();
                }
            }

            foreach (KeyValuePair<Keys, ICommand> pair in keymapOneShot)
            {
                if (Input.KeyDown(pair.Key))
                {
                    pair.Value.Execute();
                }
            }

        }
    }
}
