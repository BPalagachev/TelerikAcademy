using System;
using System.Text;
using System.Xml;

namespace _07.TextToXml
{
    public class TextToXml
    {
        static void Main(string[] args)
        {
            TextFileLineEnumerator file = new TextFileLineEnumerator(@"..\..\PeopleInformation.txt");

            string[] personInfo = new string[3];
            int lineCount = 0;
            string fileName = "../../PersonInfo.xml";
            Encoding encoding = Encoding.UTF8;

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("people");

                foreach (var line in file)
                {
                    personInfo[lineCount % 3] = line;
                    if (lineCount % 3 == 0)
                    {
                        WritePerson(writer, personInfo[0], personInfo[1], personInfo[2]);
                    }
                    lineCount++;
                }
            }
        }

        private static void WritePerson(XmlWriter writer, string name, string address, string phone)
        {
            writer.WriteStartElement("person");
            writer.WriteElementString("name", name);
            writer.WriteElementString("address", address);
            writer.WriteElementString("phone", phone);
            writer.WriteEndElement();
        }
    }
}
