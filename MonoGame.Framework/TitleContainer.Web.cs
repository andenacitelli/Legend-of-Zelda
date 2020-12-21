// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.IO;
using System.Threading.Tasks;
using static Retyped.dom;
using static Retyped.es5;

namespace Microsoft.Xna.Framework
{
    partial class TitleContainer
    {
        static partial void PlatformInit()
        {
            Location = string.Empty;
        }

        private static Stream PlatformOpenStream(string safeName)
        {
            return System.IO.File.OpenRead(safeName);
        }

        private static async Task<Stream> PlatformOpenStreamAsync(string safeName)
        {
            var loaded = false;
            var request = new XMLHttpRequest();

            request.open("GET", safeName, true);
            request.responseType = XMLHttpRequestResponseType.arraybuffer;

            request.onload += (a) => {
                loaded = true;
            };
            request.send();

            while (!loaded)
                await Task.Delay(10);

            return new MemoryStream((new Uint8Array(request.response.As<ArrayBuffer>())).As<byte[]>());
        }
    }
}

