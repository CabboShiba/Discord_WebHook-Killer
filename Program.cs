using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;

namespace Discord_WebhookDeleter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"[{Utils.Time()}] Discord_WebHook Deleter by Cabbo";
            Console.WriteLine($"[{Utils.Time()} Please insert a valid Discord WebHook:");
            Console.Write($"[{Utils.Time()}] ");
            string webhook = Console.ReadLine();
            if (WebhookPatcher(webhook))
            {
                Console.WriteLine($"[{Utils.Time()}] Succesfully deleted your WebHook.");
            }
            else
            {
                Console.WriteLine($"[{Utils.Time()}] Error during deleting process. Your WebHook may be still alive.");
            }
            Utils.Leave();
        }

        public static bool WebhookPatcher(string webhook)
        {
            var req = (HttpWebRequest)WebRequest.Create(webhook);
            req.Method = "DELETE";
            req.KeepAlive = true;
            try
            {
                var responsecheck = (HttpWebResponse)req.GetResponse();
                responsecheck.Close();
                if (responsecheck.StatusCode == HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
