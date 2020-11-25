using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Genius
{
    [SuppressUnmanagedCodeSecurity]
    internal static class WinApi
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        public static extern int MciSendString(string strCommand, string strReturn, int iReturnLength, IntPtr hwndCallback);
    }
}
