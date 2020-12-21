// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using static Retyped.dom;
using static WebHelper;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class RenderTargetCube
    {
        WebGLTexture IRenderTarget.GLTexture
        {
            get { return glTexture; }
        }

        double IRenderTarget.GLTarget
        {
            get { return glTarget; }
        }

        WebGLRenderbuffer IRenderTarget.GLColorBuffer { get; set; }
        WebGLRenderbuffer IRenderTarget.GLDepthBuffer { get; set; }
        WebGLRenderbuffer IRenderTarget.GLStencilBuffer { get; set; }

        double IRenderTarget.GetFramebufferTarget(RenderTargetBinding renderTargetBinding)
        {
            return gl.TEXTURE_CUBE_MAP_POSITIVE_X + renderTargetBinding.ArraySlice;
        }

        private void PlatformConstruct(GraphicsDevice graphicsDevice, bool mipMap, DepthFormat preferredDepthFormat, int preferredMultiSampleCount, RenderTargetUsage usage)
        {
            graphicsDevice.PlatformCreateRenderTarget(this, size, size, mipMap, this.Format, preferredDepthFormat, preferredMultiSampleCount, usage);
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
                this.GraphicsDevice.PlatformDeleteRenderTarget(this);

            base.Dispose(disposing);
        }
    }
}
