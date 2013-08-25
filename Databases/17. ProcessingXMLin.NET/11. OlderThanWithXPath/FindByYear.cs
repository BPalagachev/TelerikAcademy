using System;
using System.Xml;

namespace _11.OlderThanWithXPath
{
    public class FindByYear
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Catalogue.xml");


            string xPathQuery = string.Format("/Catalogue/Album[year > {0}]",DateTime.Now.Year - 25);

            XmlNodeList albumList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode beerNode in albumList)
            {
                string albumName = beerNode.SelectSingleNode("name").InnerText;
                Console.WriteLine(albumName);
            }
        }
    }
}
