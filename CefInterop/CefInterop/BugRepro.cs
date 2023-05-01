using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CefInterop
{
    internal class BugRepro
    {
        public static UnmanagedDelegates.InitializeCef LoadInteropFunction()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var lib = Libdl.dlopen(Path.Combine(dir, "CefInteropStackUnwinding.so"),
                Libdl.RTLD_NOW);
            if (lib == IntPtr.Zero)
                throw new Exception("Failed to open lib");
            var func = Libdl.dlsym(lib, "InitializeCef");
            if (func == IntPtr.Zero)
                throw new Exception("Failed to open func");
            var del = Marshal.GetDelegateForFunctionPointer<UnmanagedDelegates.InitializeCef>(func);
            return del;
        }
        public static void ThrowAndCatchNullRef()
        {
            string foo = null;
            try
            {
                Console.WriteLine("About to catch a null ref exception!");
                Console.WriteLine(foo.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Successfully try/caught null ref!");
        }
    }
}
