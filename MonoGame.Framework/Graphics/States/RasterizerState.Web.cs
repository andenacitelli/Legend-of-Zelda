// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using static WebHelper;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class RasterizerState
    {
        internal void PlatformApplyState(GraphicsDevice device, bool force = false)
        {
            // When rendering offscreen the faces change order.
            var offscreen = device.IsRenderTargetBound;

            if (force)
            {
                // Turn off dithering to make sure data returned by Texture.GetData is accurate
                gl.disable(gl.DITHER);
            }

            if (CullMode == CullMode.None)
            {
                gl.disable(gl.CULL_FACE);
                GraphicsExtensions.CheckGLError();
            }
            else
            {
                gl.enable(gl.CULL_FACE);
                GraphicsExtensions.CheckGLError();
                gl.cullFace(gl.BACK);
                GraphicsExtensions.CheckGLError();

                if (CullMode == CullMode.CullClockwiseFace)
                {
                    if (offscreen)
                        gl.frontFace(gl.CW);
                    else
                        gl.frontFace(gl.CCW);
                    GraphicsExtensions.CheckGLError();
                }
                else
                {
                    if (offscreen)
                        gl.frontFace(gl.CCW);
                    else
                        gl.frontFace(gl.CW);
                    GraphicsExtensions.CheckGLError();
                }
            }

            if (FillMode != FillMode.Solid)
                throw new NotImplementedException();

            if (force || this.ScissorTestEnable != device._lastRasterizerState.ScissorTestEnable)
			{
			    if (ScissorTestEnable)
				    gl.enable(gl.SCISSOR_TEST);
			    else
				    gl.disable(gl.SCISSOR_TEST);
                GraphicsExtensions.CheckGLError();
                device._lastRasterizerState.ScissorTestEnable = this.ScissorTestEnable;
            }

            if (force || 
                this.DepthBias != device._lastRasterizerState.DepthBias ||
                this.SlopeScaleDepthBias != device._lastRasterizerState.SlopeScaleDepthBias)
            {
                if (this.DepthBias != 0 || this.SlopeScaleDepthBias != 0)
                {
                    // from the docs it seems this works the same as for Direct3D
                    // https://www.khronos.org/opengles/sdk/docs/man/xhtml/glPolygonOffset.xml
                    // explanation for Direct3D is  in https://github.com/MonoGame/MonoGame/issues/4826
                    int depthMul;
                    switch (device.ActiveDepthFormat)
                    {
                        case DepthFormat.None:
                            depthMul = 0;
                            break;
                        case DepthFormat.Depth16:
                            depthMul = 1 << 16 - 1;
                            break;
                        case DepthFormat.Depth24:
                        case DepthFormat.Depth24Stencil8:
                            depthMul = 1 << 24 - 1;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    gl.enable(gl.POLYGON_OFFSET_FILL);
                    gl.polygonOffset(this.SlopeScaleDepthBias, this.DepthBias * depthMul);
                }
                else
                    gl.disable(gl.POLYGON_OFFSET_FILL);
                GraphicsExtensions.CheckGLError();
                device._lastRasterizerState.DepthBias = this.DepthBias;
                device._lastRasterizerState.SlopeScaleDepthBias = this.SlopeScaleDepthBias;
            }

            // TODO: Implement DepthClamp
            // TODO: Implement MultiSampleAntiAlias
        }
    }
}
