// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using static Retyped.dom;
using static Retyped.gamepad;

namespace Microsoft.Xna.Framework.Input
{
    static partial class GamePad
    {
        private static int PlatformGetMaxNumberOfGamePads()
        {
            return 16;
        }

        private static GamePadCapabilities PlatformGetCapabilities(int index)
        {
            var gamepads = navigator.getGamepads();
            if (gamepads.Length <= index || gamepads[index] == null)
                return new GamePadCapabilities();

            var gamepad = gamepads[index];
            if (gamepads[index].mapping != GamepadMappingType.standard)
            {
                return new GamePadCapabilities
                {
                    IsConnected = gamepad.connected,
                    DisplayName = gamepad.id,
                    Identifier = gamepad.id,
                    GamePadType = GamePadType.Unknown
                };
            }

            return new GamePadCapabilities
            {
                IsConnected = gamepad.connected,
                DisplayName = gamepad.id,
                Identifier = gamepad.id,
                GamePadType = GamePadType.GamePad,
                HasAButton = gamepad.buttons.Length > 0,
                HasBButton = gamepad.buttons.Length > 1,
                HasXButton = gamepad.buttons.Length > 2,
                HasYButton = gamepad.buttons.Length > 3,
                HasBigButton = gamepad.buttons.Length > 16,
                HasBackButton = gamepad.buttons.Length > 8,
                HasLeftTrigger = gamepad.buttons.Length > 6,
                HasStartButton = gamepad.buttons.Length > 9,
                HasDPadUpButton = gamepad.buttons.Length > 12,
                HasRightTrigger = gamepad.buttons.Length > 7,
                HasDPadDownButton = gamepad.buttons.Length > 13,
                HasDPadLeftButton = gamepad.buttons.Length > 14,
                HasDPadRightButton = gamepad.buttons.Length > 15,
                HasLeftStickButton = gamepad.buttons.Length > 10,
                HasLeftXThumbStick = gamepad.axes.Length >= 2,
                HasLeftYThumbStick = gamepad.axes.Length >= 2,
                HasRightStickButton = gamepad.buttons.Length > 11,
                HasRightXThumbStick = gamepad.axes.Length >= 4,
                HasRightYThumbStick = gamepad.axes.Length >= 4,
                HasLeftShoulderButton = gamepad.buttons.Length > 4,
                HasLeftVibrationMotor = false,
                HasRightShoulderButton = gamepad.buttons.Length > 5,
                HasRightVibrationMotor = false
            };
        }

        private static GamePadState PlatformGetState(int index, GamePadDeadZone deadZoneMode)
        {
            var gamepads = navigator.getGamepads();
            if (gamepads.Length <= index || gamepads[index] == null)
                return new GamePadState();

            var gamepad = gamepads[index];

            if (gamepad.mapping != GamepadMappingType.standard)
            {
                return new GamePadState
                {
                    IsConnected = gamepad.connected,
                    PacketNumber = (int)gamepad.timestamp
                };
            }

            var buttons = new GamePadButtons(
                (gamepad.buttons.Length > 0 && gamepad.buttons[0].pressed ? Buttons.A : 0) |
                (gamepad.buttons.Length > 1 && gamepad.buttons[1].pressed ? Buttons.B : 0) |
                (gamepad.buttons.Length > 8 && gamepad.buttons[8].pressed ? Buttons.Back : 0) |
                (gamepad.buttons.Length > 16 && gamepad.buttons[16].pressed ? Buttons.BigButton : 0) |
                (gamepad.buttons.Length > 4 && gamepad.buttons[4].pressed ? Buttons.LeftShoulder : 0) |
                (gamepad.buttons.Length > 5 && gamepad.buttons[5].pressed ? Buttons.RightShoulder : 0) |
                (gamepad.buttons.Length > 10 && gamepad.buttons[10].pressed ? Buttons.LeftStick : 0) |
                (gamepad.buttons.Length > 11 && gamepad.buttons[11].pressed ? Buttons.RightStick : 0) |
                (gamepad.buttons.Length > 9 && gamepad.buttons[9].pressed ? Buttons.Start : 0) |
                (gamepad.buttons.Length > 2 && gamepad.buttons[2].pressed ? Buttons.X : 0) |
                (gamepad.buttons.Length > 3 && gamepad.buttons[3].pressed ? Buttons.Y : 0) |
                (gamepad.buttons.Length > 6 && gamepad.buttons[6].pressed ? Buttons.LeftTrigger : 0) |
                (gamepad.buttons.Length > 7 && gamepad.buttons[7].pressed ? Buttons.RightTrigger : 0)
            );

            var dpad = new GamePadDPad(
                gamepad.buttons.Length > 12 && gamepad.buttons[12].pressed ? ButtonState.Pressed : ButtonState.Released,
                gamepad.buttons.Length > 13 && gamepad.buttons[13].pressed ? ButtonState.Pressed : ButtonState.Released,
                gamepad.buttons.Length > 14 && gamepad.buttons[14].pressed ? ButtonState.Pressed : ButtonState.Released,
                gamepad.buttons.Length > 15 && gamepad.buttons[15].pressed ? ButtonState.Pressed : ButtonState.Released
            );

            var thumbsticks = new GamePadThumbSticks(
                gamepad.axes.Length >= 2 ? new Vector2((float)gamepad.axes[0], (float)gamepad.axes[1]) : Vector2.Zero,
                gamepad.axes.Length >= 4 ? new Vector2((float)gamepad.axes[2], (float)gamepad.axes[3]) : Vector2.Zero,
                deadZoneMode
            );

            var triggers = new GamePadTriggers(
                gamepad.buttons.Length > 6 && gamepad.buttons[6].pressed ? 1 : 0,
                gamepad.buttons.Length > 7 && gamepad.buttons[7].pressed ? 1 : 0
            );

            return new GamePadState
            {
                IsConnected = gamepad.connected,
                PacketNumber = (int)gamepad.timestamp,
                Buttons = buttons,
                DPad = dpad,
                ThumbSticks = thumbsticks,
                Triggers = triggers
            };
        }

        private static bool PlatformSetVibration(int index, float leftMotor, float rightMotor)
        {
            // TODO: Implement experimental API or wait for stable?

            return false;
        }
    }
}
