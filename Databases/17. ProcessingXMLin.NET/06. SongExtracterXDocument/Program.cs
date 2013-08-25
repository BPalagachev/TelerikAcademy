using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06.SongExtracterXDocument
{
    public class Program
    {
        public static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../Catalogue.xml");
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value
                };

            foreach (var song in songs)
            {
                Console.WriteLine("{0}", song.Title);
            }
        }
    }
}
