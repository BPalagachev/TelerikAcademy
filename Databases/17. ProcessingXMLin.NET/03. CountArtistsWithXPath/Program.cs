using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _03.CountArtistsWithXPath
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Catalogue.xml");
            string xPathQuery = "/Catalogue/Album";

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();
            XmlNodeList albumbs = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode albumNode in albumbs)
            {
                string artist = albumNode.SelectSingleNode("artist").InnerText;
                if (artistsAndAlbums.ContainsKey(artist))
                {
                    artistsAndAlbums[artist]++;
                }
                else
                {
                    artistsAndAlbums.Add(artist, 1);
                }
            }

            foreach (var artist in artistsAndAlbums)
            {
                Console.WriteLine("{0} has {1} albums", artist.Key, artist.Value);
            }
        }
    }
}
