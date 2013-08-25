using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using IronMQ;
using IronMQ.Data;

namespace _01.IronMq
{
    public class IronMqChat
    {
        static void Main()
        {
            var clinetIp = GetExternalIp();
            Console.WriteLine("Chat started: ");

            Client client = new Client("520e7fec817b1b0005000005", "C8_eykCSwKlddFkkHw7r5G0fWiM");
            var queue = client.Queue("testQueue");

            while (true)
            {
                Message message = queue.Get();
                if (message != null)
                {
                    Console.WriteLine(message.Body);
                }
                Thread.Sleep(100);
                while (Console.KeyAvailable)
                {
                    string msg = Console.ReadLine();
                    queue.Push(string.Format("{0} : {1}", clinetIp, msg));
                }
            }                
        }

        private static string GetExternalIp()
        {
            try
            {
                WebRequest myRequest = WebRequest.Create("http://network-tools.com");
                using (WebResponse res = myRequest.GetResponse())
                {
                    using (Stream s = res.GetResponseStream())
                    using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    {
                        string html = sr.ReadToEnd();
                        Regex regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                        string ipString = regex.Match(html).Value;
                        return ipString;
                    }
                }
            }
            catch (Exception ex)
            {
                return "No IP";
            }
        }
    }
}
