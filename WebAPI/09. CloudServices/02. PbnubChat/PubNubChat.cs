using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace _02.PubNubChat
{
    public class PubNubChat
    {
        private static string myIp;
        static void Main(string[] args)
        {
            Console.WriteLine("Establishing Connection ... ");
            myIp = GetExternalIp();
            System.Threading.Thread.Sleep(2000);

            Pubnub pubnub = new Pubnub(
                "pub-c-4edf8554-5df2-4ef1-98dc-e52cba494052",               // PUBLISH_KEY
                "sub-c-0fa139cc-04bf-11e3-a5e8-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-ZmUzOTAzNjktYzcxOC00OTcwLWFlZjUtYWVkZWNjMzU3MmNk",   // SECRET_KEY
                "",                                                         // CIPHER_KEY
                true                                                        // SSL_ON?
            );
            string channel = "eide-na-chata";
            
            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe<string>(
                    channel,
                    DisplayReturnMessage,
                    DisplayConnectStatusMessage
                )
            );
            t.Start();

            Console.WriteLine("Connection Established!");
            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Message: ");
                string msg = Console.ReadLine();
                pubnub.Publish<string>(channel, myIp + " : " + msg, DisplayReturnMessage);
            }
        }
                
        static void DisplayReturnMessage(string result)
        {
            var resultArr = JsonConvert.DeserializeObject<IEnumerable<string>>(result);

            Console.WriteLine(resultArr.First());
        }

        static void DisplayConnectStatusMessage(string result)
        {
            //Console.WriteLine(result);
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
