// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using static WebHelper;
using static Retyped.dom;
using static Retyped.es5;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class IndexBuffer
    {
		internal WebGLBuffer ibo;

        private void PlatformConstruct(IndexElementSize indexElementSize, int indexCount)
        {
            GenerateIfRequired();
        }

        private void PlatformGraphicsDeviceResetting()
        {
            ibo = null;
        }

        /// <summary>
        /// If the IBO does not exist, create it.
        /// </summary>
        void GenerateIfRequired()
        {
            if (ibo == null)
            {
                var sizeInBytes = IndexCount * (this.IndexElementSize == IndexElementSize.SixteenBits ? 2 : 4);

                ibo = gl.createBuffer();
                GraphicsExtensions.CheckGLError();
                gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, ibo);
                GraphicsExtensions.CheckGLError();
                gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Int16Array(0), _isDynamic ? gl.STREAM_DRAW : gl.STATIC_DRAW);
                GraphicsExtensions.CheckGLError();
            }
        }

        private void PlatformGetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount) where T : struct
        {
            // Buffers are write-only on OpenGL ES 1.1 and 2.0.  See the GL_OES_mapbuffer extension for more information.
            // http://www.khronos.org/registry/gles/extensions/OES/OES_mapbuffer.txt
            throw new NotSupportedException("Index buffers are write-only on OpenGL ES platforms");
        }

        private void PlatformSetDataInternal<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct
        {
            BufferData(offsetInBytes, data, startIndex, elementCount, options);
        }

        private void BufferData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct
        {
            GenerateIfRequired();
            
            var elementSizeInByte = (IndexElementSize == IndexElementSize.SixteenBits ? 2 : 4);
            var bufferSize = IndexCount * elementSizeInByte;
            
            gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, ibo);
            GraphicsExtensions.CheckGLError();
            
            if (options == SetDataOptions.Discard)
            {
                // By assigning NULL data to the buffer this gives a hint
                // to the device to discard the previous content.
                gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Int16Array(0), _isDynamic ? gl.STREAM_DRAW : gl.STATIC_DRAW);
                GraphicsExtensions.CheckGLError();
            }
            
            if (elementSizeInByte == 2)
            {
                var arr = new Uint16Array((uint)elementCount);
                for (uint i = 0; i < elementCount; i++)
                    arr[i] = data[i + startIndex].As<ushort>();
                gl.bufferSubData(gl.ELEMENT_ARRAY_BUFFER, offsetInBytes, arr);
            }
            else
            {
                var arr = new Uint32Array((uint)elementCount);
                for (uint i = 0; i < elementCount; i++)
                    arr[i] = data[i + startIndex].As<uint>();
                gl.bufferSubData(gl.ELEMENT_ARRAY_BUFFER, offsetInBytes, arr);
            }
            GraphicsExtensions.CheckGLError();
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
                GraphicsDevice.DisposeBuffer(ibo);
            base.Dispose(disposing);
        }
	}
}
