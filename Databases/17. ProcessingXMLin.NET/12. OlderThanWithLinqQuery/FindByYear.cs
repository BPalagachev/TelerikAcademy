using System;
using System.Linq;
using System.Xml.Linq;


namespace _12.OlderThanWithLinqQuery
{
    public class FindByYear
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../Catalogue.xml");
            var albums =
                from album in xmlDoc.Descendants("Album")
                where int.Parse(album.Element("year").Value) < 2000
                select new
                {
                    Name = album.Element("name").Value
                };


            foreach (var album in albums)
            {
                Console.WriteLine(album.Name);
            }
        }
    }
}
