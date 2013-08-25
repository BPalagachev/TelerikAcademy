using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace _01.Catalogue
{
    public class Catalogue
    {
        public static void Main()
        {
            string filename = @"../../Catalogue.xml";
            Encoding encoding = Encoding.UTF8;

            using (XmlTextWriter writer = new XmlTextWriter(filename, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("Catalogue");

                WriteAlbum(writer, "Rodopa", "Pevcheska Trupa Rodopa", "1997", "Self produced", "2500", new string[][]
                {
                    new string[]  {"aaa", "bbb"},
                    new string[]  {"ccc", "ddd"},
                    new string[]  {"eee", "fff"}
                });

                writer.WriteEndDocument();
            }
        }



        private static void WriteSong(XmlWriter writer, string title, string duration)
        {
            writer.WriteStartElement("song");
            writer.WriteElementString("title", title);
            writer.WriteElementString("duration", duration);
            writer.WriteEndElement();
        }

        private static void WriteAlbum(XmlWriter writer,
            string name,
            string artist,
            string year,
            string producer,
            string price,
            string[][] ListOfSongs)
        {
            writer.WriteStartElement("Album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteElementString("year", year);
            writer.WriteElementString("producer", producer);
            writer.WriteElementString("price", price);

            foreach (var song in ListOfSongs)
            {
                WriteSong(writer, song[0], song[1]);
            }

            writer.WriteEndElement();
        }


    }
}
