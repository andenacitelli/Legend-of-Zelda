// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using static Retyped.dom;
using static WebHelper;

namespace Microsoft.Xna.Framework.Graphics
{
    public abstract partial class Texture
    {
        internal WebGLTexture glTexture;
        internal double glTarget;
        internal double glTextureUnit = gl.TEXTURE0;
        internal double glInternalFormat;
        internal double glFormat;
        internal double glType;
        internal SamplerState glLastSamplerState;

        private void PlatformGraphicsDeviceResetting()
        {
            DeleteGLTexture();
            glLastSamplerState = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                DeleteGLTexture();
                glLastSamplerState = null;
            }

            base.Dispose(disposing);
        }

        private void DeleteGLTexture()
        {
            if (glTexture != null)
                GraphicsDevice.DisposeTexture(glTexture);
            glTexture = null;
        }
    }
}

