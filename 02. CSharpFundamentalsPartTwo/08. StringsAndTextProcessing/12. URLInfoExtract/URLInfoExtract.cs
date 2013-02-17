// Write a program that parses an URL address given in the format:
// [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. 
// For example from the URL http://www.devbg.org/forum/index.php the 
// following information should be extracted:
//        [protocol] = "http"
//        [server] = "www.devbg.org"
//        [resource] = "/forum/index.php"

using System;

class URLInfoExtract
{
    static void Main(string[] args)
    {
        string url = "http://www.devbg.org/forum/index.php";

        string protokol = url.Substring(0, url.IndexOf("//"));
        string server = url.Substring(protokol.Length+2, url.IndexOf("/", protokol.Length+2) -2- protokol.Length);
        string resource = url.Substring(server.Length+protokol.Length+2);
        Console.WriteLine("[protokol] = \"{0}\"", protokol);
        Console.WriteLine("[server] = \"{0}\"", server);
        Console.WriteLine("[resource] = \"{0}\"", resource);

    }
}