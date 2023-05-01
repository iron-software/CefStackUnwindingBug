using System;
using System.Runtime.InteropServices;

namespace CefInterop
{
    [System.Reflection.Obfuscation(Exclude = true, ApplyToMembers = true)]
    public static class Libdl
    {
        private const string LIB_NAME = "libdl";

        public const int RTLD_NOW = 0x002;

        [DllImport(LIB_NAME, SetLastError = true)]
        public static extern IntPtr dlopen(string fileName, int flags);

        [DllImport(LIB_NAME, SetLastError = true)]
        public static extern IntPtr dlsym(IntPtr handle, string name);

        [DllImport(LIB_NAME, SetLastError = true)]
        public static extern int dlclose(IntPtr handle);

        [DllImport(LIB_NAME, SetLastError = true)]
        public static extern IntPtr dlerror();
    }

    internal class UnmanagedDelegates
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal delegate int InitializeCef();
    }
}