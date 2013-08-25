using System;
using System.Collections.Generic;
using System.Xml;

namespace _04.PriceComparer
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
                string priceStr = albumNode.SelectSingleNode("price").InnerText;
                decimal price = decimal.Parse(priceStr);
                if (price < 100)
                {
                    Console.WriteLine("{0}, price {1}", albumNode.Name, price);
                }
            }

        }
    }
}
