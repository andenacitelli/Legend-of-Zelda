using Bridge.Utils;
using game_project.Commands;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace game_project.Controllers
{
    class KeyboardController
    {
        Dictionary<Keys, ICommand> keymap;
        Dictionary<Keys, ICommand> keymapOneShot;

        MouseState oldMouseState = Mouse.GetState();
        MouseState mouseState = Mouse.GetState();

        public KeyboardController()
        {
            keymap = new Dictionary<Keys, ICommand>();
            keymapOneShot = new Dictionary<Keys, ICommand>();


            //// Number Keys for Items (1, 2, 3, 4, 5, 6, 7, 8, 9)
            // keymapOneShot.Add(Keys.D1, new LinkUseBomb());
            keymapOneShot.Add(Keys.D2, new CommandItem2());
            // keymapOneShot.Add(Keys.D3, new CommandItem3());
            // keymapOneShot.Add(Keys.D4, new CommandItem4());

            // Link "become damaged" (e)
            //keymapOneShot.Add(Keys.E, new CommandPlayerToggleDamage());

            // Show Colliders for debugging
            keymapOneShot.Add(Keys.OemSemicolon, new CommandDebugColliders());

            /* Other Controls */
            // Exit (q)
            keymap.Add(Keys.Q, new CommandExit());

            // Reset (r) 
            keymapOneShot.Add(Keys.R, new CommandReset());

            // Pause/Play (shift)
            keymapOneShot.Add(Keys.RightShift, new CommandPlayPause());
            // Inventory (e)
            keymapOneShot.Add(Keys.E, new CommandItemSelection());
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

            // mouse control
            mouseState = Mouse.GetState();

            //if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            //{
            //    var command = new CommandRoomNext();
            //    command.Execute();
            //}

            //if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
            //{
            //    var command = new CommandRoomPrevious();
            //    command.Execute();
            //}


            oldMouseState = mouseState;




        }
    }
}
