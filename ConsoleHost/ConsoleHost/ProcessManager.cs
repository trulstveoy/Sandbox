using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleHost
{
    public static class ProcessManager
    {
        public static Process StartProcess(string path)
        {
            var process = Process.Start(path);
            if (process == null) throw new InvalidOperationException(string.Format("Process not found ({0})", path));

            while (process.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }

            return process;
        }
    }
}