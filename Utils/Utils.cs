using System;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Discord_WebhookDeleter
{
    internal class Utils
    {
        public static string Time()
        {
            DateTime time = DateTime.Now;
            return time.ToString();
        }
        public static void Leave()
        {
            Console.WriteLine($"[{Utils.Time()}] Press enter to leave...");
            Console.ReadLine();
            Process.GetCurrentProcess().Kill();
        }
    }
}