using System;

namespace MPNI.Core.Plugins.Api
{
    public static class Logger
    {
        public static void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            Console.WriteLine($"[MPNI] {message}");
        }
    }
}