using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace VisualCSharp
{
    static class Constants
    {
        public const string SCRIPT = "Javascript";
    }

    static class win32
    {
        [DllImport("kernel32.dll")]
        public static extern bool SetDllDirectory(string lpPathName);

        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        public extern static IntPtr LoadLibrary(string librayName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi)]
        public extern static IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        public extern static bool FreeLibrary(int hModule);
    }

    class Script
    {
       
    }
}
