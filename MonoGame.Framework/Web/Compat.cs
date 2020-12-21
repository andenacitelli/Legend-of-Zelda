// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Microsoft.Xna.Framework
{
    public class IntPtr
    {
        public static IntPtr Zero;
    }

    public class ResourceManager
    {
        public object GetObject(string name)
        {
            throw new System.Exception();
        }
    }

    public static class Interlocked
    {
        public static int Increment(ref int val)
        {
            val = val + 1;
            return val;
        }
    }

    public interface IServiceProvider
    {
        object GetService(System.Type serviceType);
    }
}

namespace System
{
    class PlatformNotSupportedException : Exception
    {
        public PlatformNotSupportedException(string message)
        {
            
        }
    }

    static class GC
    {
        public static void SuppressFinalize(object obj)
        {
            
        }
    }

    static class Buffer
    {
        public static void BlockCopy(Array src, int srcOffset, Array dst, int dstOffset, int count)
        {
            for (int i = 0; i < count; i++)
                dst[dstOffset + i] = src[srcOffset + i];
        }
    }

    class WeakReference
    {
        public bool IsAlive => true;

        public object Target { get; set; }

        public WeakReference(object target)
        {
            Target = target;
        }
    }
}

namespace System.Reflection
{
    class TargetInvocationException : System.Exception
    {
        
    }
}

namespace System.IO
{
    static class Path
    {
        public static char DirectorySeparatorChar => '/';
        
        public static string Combine(string a, string b)
        {
            return (a.TrimEnd('/') + "/" + b.TrimStart('/')).TrimStart('/');
        }

        public static string GetFileNameWithoutExtension(string s)
        {
            return s;
        }

        public static bool IsPathRooted(string s)
        {
            return false;
        }
    }

    class FileNotFoundException : Exception
    {
        public FileNotFoundException(string name, Exception ex)
        {
            
        }
    }
}

namespace System.Collections.Concurrent
{
    class ConcurrentQueue<T> : Queue<T>
    {
        public bool TryDequeue(out T val)
        {
            val = Dequeue();
            return true;
        }
    }
}
