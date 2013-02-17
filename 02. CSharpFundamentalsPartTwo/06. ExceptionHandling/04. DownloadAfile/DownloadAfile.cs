// Write a program that downloads a file from Internet
// (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it 
// the current directory. Find in Google how to download files in
// C#. Be sure to catch all exceptions and to free any used 
// resources in the finally block.

using System;
using System.Net;

class DownloadAfile
{
    static void Main()
    {
        string remoteUri = @"http://www.devbg.org/img/";
        string fileName = @"Logo-BASD.jpg";

        // Create a new web client instance
        using (WebClient myWebClient = new WebClient())
        {
            try
            {
                // Download the web resource and save it to the current folder
                myWebClient.DownloadFile(remoteUri, fileName);
            }
            catch (NotSupportedException ns)
            {
                Console.WriteLine(ns.Message);
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
        }


    }
}