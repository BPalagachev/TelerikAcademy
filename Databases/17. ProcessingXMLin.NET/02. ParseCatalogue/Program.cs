using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _02.ParseCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../Catalogue.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (artistsAndAlbums.ContainsKey(node["artist"].InnerText))
                {
                    artistsAndAlbums[node["artist"].InnerText]++;
                }
                else
                {
                    artistsAndAlbums.Add(node["artist"].InnerText, 1);
                }
            }

            foreach (var artist in artistsAndAlbums)
            {
                Console.WriteLine("{0} has {1} albums", artist.Key, artist.Value);
            }
        }
    }
}
