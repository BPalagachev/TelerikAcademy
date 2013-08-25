using System;
using System.Xml;

namespace _05.SongEctracter
{
    public class SongEctracter
    {
        public static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
