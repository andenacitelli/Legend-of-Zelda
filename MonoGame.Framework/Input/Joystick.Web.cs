// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using static Retyped.dom;
using static Retyped.gamepad;

namespace Microsoft.Xna.Framework.Input
{
    static partial class Joystick
    {
        public static bool PlatformIsSupported => true;
        
        private static JoystickCapabilities PlatformGetCapabilities(int index)
        {
            var gamepads = navigator.getGamepads();
            if (gamepads.Length <= index || gamepads[index] == null)
            {
                return new JoystickCapabilities
                {
                    IsConnected = false,
                    Identifier = "",
                    IsGamepad = false,
                    AxisCount = 0,
                    ButtonCount = 0,
                    HatCount = 0
                };
            }

            var gamepad = gamepads[index];
            return new JoystickCapabilities
            {
                IsConnected = false,
                Identifier = gamepad.id,
                IsGamepad = gamepad.mapping == GamepadMappingType.standard,
                AxisCount = gamepad.axes.Length,
                ButtonCount = gamepad.buttons.Length,
                HatCount = 0
            };
        }

        private static JoystickState PlatformGetState(int index)
        {
            var gamepads = navigator.getGamepads();
            if (gamepads.Length <= index || gamepads[index] == null)
            {
                return new JoystickState
                {
                    IsConnected = false,
                    Axes = new int[0],
                    Buttons = new ButtonState[0],
                    Hats = new JoystickHat[0]
                };
            }

            var gamepad = gamepads[index];

            var buttons = new ButtonState[gamepad.buttons.Length];
            for (int i = 0; i < buttons.Length; i++)
                buttons[i] = gamepad.buttons[i].pressed ? ButtonState.Pressed : ButtonState.Released;

            var axes = new int[gamepad.axes.Length];
            for (int i = 0; i < axes.Length; i++)
                axes[i] = (int)(gamepad.axes[i] < 0 ? (gamepad.axes[i] * 32768) : (gamepad.axes[i] * 32767));

            return new JoystickState
            {
                IsConnected = gamepad.connected,
                Axes = axes,
                Buttons = buttons,
                Hats = new JoystickHat[0]
            };
        }
    }
}
