using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game_project.Controllers
{
    class Input
    {
        static KeyboardState currentKeyState;
        static KeyboardState previousKeyState;

        static GamePadState currentGamePadState;
        static GamePadState previousGamePadState;

        static bool gamePadLeftTriggerPressed;
        static bool gamePadRightTriggerPressed;

        public enum Inputs
        {
            UP = 0,
            DOWN,
            LEFT,
            RIGHT,
            ATTACK,
            BOMB,
            B_ITEM,
            SELECT_ITEM_LEFT,
            SELECT_ITEM_RIGHT,
            SELECT_ITEM_UP,
            SELECT_ITEM_DOWN,
            SELECT_ITEM_SELECT,
        }

        public static KeyboardState GetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            return currentKeyState;
        }

        public static GamePadState GetGamePadState()
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            return currentGamePadState;
        }

        // checks if a key is pressed when it was released the previous frame
        public static bool KeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }

        public static bool KeyDown(params Keys[] keys)
        {
            bool found = false;
            foreach (var key in keys)
            {
                if (currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        // checks if a key is released when it was pressed the previous frame
        public static bool KeyUp(Keys key)
        {
            return !currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyDown(key);
        }

        // checks if gamepad key is pressed when it was released previous frame
        public static bool GamePadKeyDown(Buttons button)
        {
            return currentGamePadState.IsButtonDown(button) && !previousGamePadState.IsButtonDown(button);
        }

        public static bool GamePadKeyDown(params Buttons[] buttons)
        {
            bool found = false;
            foreach (var button in buttons)
            {
                if (currentGamePadState.IsButtonDown(button) && !previousGamePadState.IsButtonDown(button))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public static bool GamePadLeftTriggerDown(GamePadTriggers trigger)
        {
            if (gamePadLeftTriggerPressed && trigger.Left < 0.5)
            {
                gamePadLeftTriggerPressed = false;
            } else if (!gamePadLeftTriggerPressed && trigger.Left > 0.5)
            {
                gamePadLeftTriggerPressed = true;
                return true;
            }
            return false;
        }

        public static bool GamePadRightTriggerDown(GamePadTriggers trigger)
        {
            if (gamePadRightTriggerPressed && trigger.Right < 0.5)
            {
                gamePadRightTriggerPressed = false;
            }
            else if (!gamePadRightTriggerPressed && trigger.Right > 0.5)
            {
                gamePadRightTriggerPressed = true;
                return true;
            }
            return false;
        }

        // checks if a key is released when it was pressed the previous frame
        public static bool GamePadKeyUp(Buttons button)
        {
            return !currentGamePadState.IsButtonDown(button) && previousGamePadState.IsButtonDown(button);
        }

        public static bool Down(Inputs input)
        {
            var keyboard = Keyboard.GetState();
            var gamepad = GamePad.GetState(PlayerIndex.One);
            bool result = false;

            switch (input)
            {
                case Inputs.LEFT:
                    result = keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left) || (gamepad.ThumbSticks.Left.X < -0.5);
                    break;
                case Inputs.RIGHT:
                    result = keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right) || (gamepad.ThumbSticks.Left.X > 0.5);
                    break;
                case Inputs.UP:
                    result = keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up) || (gamepad.ThumbSticks.Left.Y > 0.5);
                    break;
                case Inputs.DOWN:
                    result = keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down) || (gamepad.ThumbSticks.Left.Y < -0.5);
                    break;
                case Inputs.ATTACK:
                    result = keyboard.IsKeyDown(Keys.Z) || keyboard.IsKeyDown(Keys.N) || GamePadRightTriggerDown(gamepad.Triggers);
                    break;
                case Inputs.BOMB:
                    result = KeyDown(Keys.D1) || (gamepad.IsButtonDown(Buttons.Y));
                    break;
                case Inputs.B_ITEM:
                    result = KeyDown(Keys.B) || GamePadLeftTriggerDown(gamepad.Triggers);
                    break;
                // these would be better if we could give function pointers since they have the same key mappings
                case Inputs.SELECT_ITEM_LEFT:
                    result = KeyDown(Keys.A) || KeyDown(Keys.Left) || (gamepad.ThumbSticks.Left.X < -0.5);
                    break;
                case Inputs.SELECT_ITEM_RIGHT:
                    result = KeyDown(Keys.D) || KeyDown(Keys.Right) || (gamepad.ThumbSticks.Left.X > 0.5);
                    break;
                case Inputs.SELECT_ITEM_UP:
                    result = KeyDown(Keys.W) || KeyDown(Keys.Up) || (gamepad.ThumbSticks.Left.Y > 0.5);
                    break;
                case Inputs.SELECT_ITEM_DOWN:
                    result = KeyDown(Keys.S) || KeyDown(Keys.Down) || (gamepad.ThumbSticks.Left.Y < -0.5);
                    break;
                case Inputs.SELECT_ITEM_SELECT:
                    result = KeyDown(Keys.Z) || KeyDown(Keys.N) || GamePadRightTriggerDown(gamepad.Triggers);
                    break;
            }
            return result;
        }


        public static bool Up(Inputs input)
        {
            var keyboard = Keyboard.GetState();
            var gamepad = GamePad.GetState(PlayerIndex.One);
            bool result = false;

            switch (input)
            {
                case Inputs.LEFT:
                    result = KeyUp(Keys.A) || KeyUp(Keys.Left) || (gamepad.ThumbSticks.Left.X == 0);
                    break;
                case Inputs.RIGHT:
                    result = KeyUp(Keys.D) || KeyUp(Keys.Right) || (gamepad.ThumbSticks.Left.X == 0);
                    break;
                case Inputs.UP:
                    result = KeyUp(Keys.W) || KeyUp(Keys.Up) || (gamepad.ThumbSticks.Left.X == 0);
                    break;
                case Inputs.DOWN:
                    result = KeyUp(Keys.S) || KeyUp(Keys.Down) || (gamepad.ThumbSticks.Left.X == 0);
                    break;
                case Inputs.ATTACK:
                    result = keyboard.IsKeyDown(Keys.Z) || keyboard.IsKeyDown(Keys.N) || (gamepad.ThumbSticks.Left.X == 0);
                    break;
            }
            return result;
        }

    }
}
