﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace ConsoleHost.View
{
    public class HwndControl : HwndHost
    {
        private Process _process;
        private string _path; 

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_THICKFRAME = 0x00040000;
        private const int WS_CHILD = 0x40000000;

        public HwndControl(string path)
        {
            _path = path;
        }

        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            _path = @"..\..\..\TestApp\bin\debug\TestApp.exe";
            if (string.IsNullOrWhiteSpace(_path)) throw new InvalidOperationException("Path cannot be null or whitespace");
            _process = ProcessManager.StartProcess(_path);

            var handle = _process.MainWindowHandle;

            int style = GetWindowLong(handle, GWL_STYLE);
            style = style & ~WS_CAPTION & ~WS_THICKFRAME;
            style |= WS_CHILD;

            SetWindowLong(handle, GWL_STYLE, style);
            SetParent(handle, hwndParent.Handle);

            InvalidateVisual();

            var hwnd = new HandleRef(this, handle);
            return hwnd;
        }

        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            _process.CloseMainWindow();
            _process.WaitForExit(5000);
            if (_process.HasExited == false)
            {
                _process.Kill();
            }

            _process.Close();
            _process.Dispose();
            _process = null;
        }
    }
}
