// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Diagnostics;
using static WebHelper;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class SamplerState
    {
        internal const double TextureParameterNameTextureMaxAnisotropy = 0x84FE;
        private readonly float[] _openGLBorderColor = new float[4];

        internal void Activate(GraphicsDevice device, double target, bool useMipmaps = false)
        {
            if (GraphicsDevice == null)
            {
                // We're now bound to a device... no one should
                // be changing the state of this object now!
                GraphicsDevice = device;
            }
            Debug.Assert(GraphicsDevice == device, "The state was created for a different device!");

            switch (Filter)
            {
                case TextureFilter.Point:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.NEAREST_MIPMAP_NEAREST : gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.Linear:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.LINEAR_MIPMAP_LINEAR : gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.Anisotropic:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, MathHelper.Clamp(this.MaxAnisotropy, 1.0f, GraphicsDevice.GraphicsCapabilities.MaxTextureAnisotropy));
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.LINEAR_MIPMAP_LINEAR : gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.PointMipLinear:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.NEAREST_MIPMAP_LINEAR : gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.LinearMipPoint:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.LINEAR_MIPMAP_NEAREST : gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.MinLinearMagPointMipLinear:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.LINEAR_MIPMAP_LINEAR : gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.MinLinearMagPointMipPoint:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.LINEAR_MIPMAP_NEAREST : gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.MinPointMagLinearMipLinear:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.NEAREST_MIPMAP_LINEAR : gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    break;
                case TextureFilter.MinPointMagLinearMipPoint:
                    if (GraphicsDevice.GraphicsCapabilities.SupportsTextureFilterAnisotropic)
                    {
                        gl.texParameteri(target, TextureParameterNameTextureMaxAnisotropy, 1.0f);
                        GraphicsExtensions.CheckGLError();
                    }
                    gl.texParameteri(target, gl.TEXTURE_MIN_FILTER, useMipmaps ? gl.NEAREST_MIPMAP_NEAREST : gl.NEAREST);
                    GraphicsExtensions.CheckGLError();
                    gl.texParameteri(target, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                    GraphicsExtensions.CheckGLError();
                    break;
                default:
                    throw new NotSupportedException();
            }

            // Set up texture addressing.
            gl.texParameteri(target, gl.TEXTURE_WRAP_S, (int)GetWrapMode(AddressU));
            GraphicsExtensions.CheckGLError();
            gl.texParameteri(target, gl.TEXTURE_WRAP_T, (int)GetWrapMode(AddressV));
            GraphicsExtensions.CheckGLError();
        }

        private double GetWrapMode(TextureAddressMode textureAddressMode)
        {
            switch (textureAddressMode)
            {
                case TextureAddressMode.Clamp:
                    return gl.CLAMP_TO_EDGE;
                case TextureAddressMode.Wrap:
                    return gl.REPEAT;
                case TextureAddressMode.Mirror:
                    return gl.MIRRORED_REPEAT;
                default:
                    throw new ArgumentException("No support for " + textureAddressMode);
            }
        }
    }
}

