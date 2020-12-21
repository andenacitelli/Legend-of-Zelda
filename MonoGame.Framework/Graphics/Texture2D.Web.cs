// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.IO;
using System.Threading.Tasks;
using static Retyped.dom;
using static Retyped.es5;
using static WebHelper;
using Math = System.Math;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class Texture2D : Texture
    {
        private void PlatformConstruct(int width, int height, bool mipmap, SurfaceFormat format, SurfaceType type, bool shared)
        {
            this.glTarget = gl.TEXTURE_2D;
            format.GetGLFormat(GraphicsDevice, out glInternalFormat, out glFormat, out glType);

            GenerateGLTextureIfRequired();
            int w = width;
            int h = height;
            int level = 0;

            while (true)
            {
                if (glFormat == gl.COMPRESSED_TEXTURE_FORMATS)
                {
                    int imageSize = 0;
                    // PVRTC has explicit calculations for imageSize
                    // https://www.khronos.org/registry/OpenGL/extensions/IMG/IMG_texture_compression_pvrtc.txt
                    if (format == SurfaceFormat.RgbPvrtc2Bpp || format == SurfaceFormat.RgbaPvrtc2Bpp)
                    {
                        imageSize = (Math.Max(w, 16) * Math.Max(h, 8) * 2 + 7) / 8;
                    }
                    else if (format == SurfaceFormat.RgbPvrtc4Bpp || format == SurfaceFormat.RgbaPvrtc4Bpp)
                    {
                        imageSize = (Math.Max(w, 8) * Math.Max(h, 8) * 4 + 7) / 8;
                    }
                    else
                    {
                        int blockSize = format.GetSize();
                        int blockWidth, blockHeight;
                        format.GetBlockSize(out blockWidth, out blockHeight);
                        int wBlocks = (w + (blockWidth - 1)) / blockWidth;
                        int hBlocks = (h + (blockHeight - 1)) / blockHeight;
                        imageSize = wBlocks * hBlocks * blockSize;
                    }
                }

                gl.texImage2D(gl.TEXTURE_2D, level, glInternalFormat, glFormat, glType, (new ImageData(w, h).As<ImageBitmap>()));
                GraphicsExtensions.CheckGLError();

                if ((w == 1 && h == 1) || !mipmap)
                    break;
                if (w > 1)
                    w = w / 2;
                if (h > 1)
                    h = h / 2;
                ++level;
            }
        }

        private void GenerateGLTextureIfRequired()
        {
            if (this.glTexture == null)
            {
                glTexture = gl.createTexture();
                GraphicsExtensions.CheckGLError();

                // For best compatibility and to keep the default wrap mode of XNA, only set ClampToEdge if either
                // dimension is not a power of two.
                var wrap = gl.REPEAT;
                if (((width & (width - 1)) != 0) || ((height & (height - 1)) != 0))
                    wrap = gl.CLAMP_TO_EDGE;

                gl.bindTexture(gl.TEXTURE_2D, glTexture);
                GraphicsExtensions.CheckGLError();
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, (_levelCount > 1) ? gl.LINEAR_MIPMAP_LINEAR : gl.LINEAR);
                GraphicsExtensions.CheckGLError();
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR);
                GraphicsExtensions.CheckGLError();
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_S, wrap);
                GraphicsExtensions.CheckGLError();
                gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_T, wrap);
                GraphicsExtensions.CheckGLError();
            }
        }

        private void PlatformSetData<T>(int level, T[] data, int startIndex, int elementCount) where T : struct
        {
            int w, h;
            GetSizeForLevel(Width, Height, level, out w, out h);

            // Store the current bound texture.
            var prevTexture = GraphicsExtensions.GetBoundTexture2D();

            if (prevTexture != glTexture)
            {
                gl.bindTexture(gl.TEXTURE_2D, glTexture);
                GraphicsExtensions.CheckGLError();
            }

            GenerateGLTextureIfRequired();
            gl.pixelStorei(gl.UNPACK_ALIGNMENT, Math.Min(_format.GetSize(), 8));

            ArrayBufferView arrayBuffer = null;
            var size = Utilities.ReflectionHelpers.SizeOf<T>.Get();

            if (size == 1)
            {
                var subarr = new Uint8Array(data.As<ArrayBuffer>(), startIndex.As<uint>(), elementCount.As<uint>());
                arrayBuffer = subarr.As<ArrayBufferView>();
            }
            else if (size == 4 && typeof(T) == typeof(Color))
            {
                var subarr = new Uint8Array(4 * elementCount.As<uint>());
                uint subarrindex = 0;

                for (uint i = startIndex.As<uint>(); i < startIndex.As<uint>() + elementCount; i++)
                {
                    var col = data[i].As<Color>();

                    subarr[subarrindex + 0] = col.R;
                    subarr[subarrindex + 1] = col.G;
                    subarr[subarrindex + 2] = col.B;
                    subarr[subarrindex + 3] = col.A;

                    subarrindex += 4;
                }

                arrayBuffer = subarr.As<ArrayBufferView>();
            }
            else
            {
                throw new NotImplementedException();
            }

            if (glFormat == gl.COMPRESSED_TEXTURE_FORMATS)
                gl.compressedTexImage2D(gl.TEXTURE_2D, level, glInternalFormat, w, h, 0, arrayBuffer.As<Int8Array>());
            else
                gl.texImage2D(gl.TEXTURE_2D, level, glInternalFormat, w, h, 0, glFormat, glType, arrayBuffer);

            GraphicsExtensions.CheckGLError();

            // Restore the bound texture.
            if (prevTexture != glTexture)
            {
                gl.bindTexture(gl.TEXTURE_2D, prevTexture);
                GraphicsExtensions.CheckGLError();
            }
        }

        private void PlatformSetData<T>(int level, int arraySlice, Rectangle rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            // Store the current bound texture.
            var prevTexture = GraphicsExtensions.GetBoundTexture2D();

            if (prevTexture != glTexture)
            {
                gl.bindTexture(gl.TEXTURE_2D, glTexture);
                GraphicsExtensions.CheckGLError();
            }

            GenerateGLTextureIfRequired();
            gl.pixelStorei(gl.UNPACK_ALIGNMENT, Math.Min(_format.GetSize(), 8));

            ArrayBufferView arrayBuffer = null;
            var size = Utilities.ReflectionHelpers.SizeOf<T>.Get();

            if (size == 1)
            {
                var subarr = new Uint8Array(data.As<ArrayBuffer>(), startIndex.As<uint>(), elementCount.As<uint>());
                arrayBuffer = subarr.As<ArrayBufferView>();
            }
            else if (size == 4 && typeof(T) == typeof(Color))
            {
                var subarr = new Uint8Array(4 * elementCount.As<uint>());
                uint subarrindex = 0;

                for (uint i = startIndex.As<uint>(); i < startIndex.As<uint>() + elementCount; i++)
                {
                    var col = data[i].As<Color>();

                    subarr[subarrindex + 0] = col.R;
                    subarr[subarrindex + 1] = col.G;
                    subarr[subarrindex + 2] = col.B;
                    subarr[subarrindex + 3] = col.A;

                    subarrindex += 4;
                }

                arrayBuffer = subarr.As<ArrayBufferView>();
            }
            else
            {
                throw new NotImplementedException();
            }

            if (glFormat == gl.COMPRESSED_TEXTURE_FORMATS)
                gl.compressedTexSubImage2D(gl.TEXTURE_2D, level, rect.X, rect.Y, rect.Width, rect.Height, glInternalFormat, arrayBuffer.As<Int8Array>());
            else
                gl.texSubImage2D(gl.TEXTURE_2D, level, rect.X, rect.Y, rect.Width, rect.Height, glFormat, glType, arrayBuffer);
            GraphicsExtensions.CheckGLError();
            
            // Restore the bound texture.
            if (prevTexture != glTexture)
            {
                gl.bindTexture(gl.TEXTURE_2D, prevTexture);
                GraphicsExtensions.CheckGLError();
            }
        }

        private void PlatformGetData<T>(int level, int arraySlice, Rectangle rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        private static Texture2D PlatformFromStream(GraphicsDevice graphicsDevice, Stream stream)
        {
            throw new NotImplementedException();
        }

        private void PlatformSaveAsJpeg(Stream stream, int width, int height)
        {
            throw new NotImplementedException();
        }

        private void PlatformSaveAsPng(Stream stream, int width, int height)
        {
            throw new NotImplementedException();
        }

        private void PlatformReload(Stream textureStream)
        {
            throw new NotImplementedException();
        }
    }
}

