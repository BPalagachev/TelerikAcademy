using System;
using System.Linq;
using System.Text;
using System.Xml;


namespace _08.CreateAlbums
{
    public class AlbumCreater
    {
        public static void Main()
        {
            string fileName = "../../albums.xml";
            Encoding encoding = Encoding.UTF8;
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                bool isInAlbum = false;
                using (XmlReader reader = XmlReader.Create("../../Catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "Album"))
                        {
                            isInAlbum = !isInAlbum;

                            if (isInAlbum)
                            {
                                writer.WriteStartElement("Album");
                            }
                            else
                            {
                                writer.WriteEndElement();
                            }
                        }
                        if (isInAlbum)
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "name")
                            {
                                writer.WriteElementString("name", reader.ReadInnerXml());
                            }
                        }
                    }
                }

                writer.WriteEndDocument();

            }
        }


    }
}
