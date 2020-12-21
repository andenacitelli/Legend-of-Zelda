// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input
{
    public static partial class Keyboard
    {
        static List<Keys> _keys;
        internal static bool CapsLock, NumLock;

        private static KeyboardState PlatformGetState()
        {
            return new KeyboardState(_keys, CapsLock, NumLock);
        }

        internal static void SetKeys(List<Keys> keys)
        {
            _keys = keys;
        }
    }
}
