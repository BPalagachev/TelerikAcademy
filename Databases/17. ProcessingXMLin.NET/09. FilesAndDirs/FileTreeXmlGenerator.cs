using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace _09.FilesAndDirs
{
    public class FileTreeXmlGenerator
    {
        static void Main()
        {
            string path = @"..\..\..";
            string mask = "*.exe";


            XmlTextWriter writer = new XmlTextWriter(@"../../FileSystem.xml", Encoding.UTF8);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("FileSystem");

                TraverseDir(writer, path, mask, string.Empty);

                writer.WriteEndDocument();
            }

            
        }

        public static void TraverseDir(XmlWriter writer, string rootPath, string mask, string indentation)
        {
            DirectoryInfo rootInfo = new DirectoryInfo(rootPath);
            //Console.WriteLine(indentation + "Dir: " + rootInfo.Name);
            writer.WriteStartElement("Dir");
            writer.WriteAttributeString("name", rootInfo.Name);

            var allFilesMatched = Directory.EnumerateFiles(rootPath, mask, SearchOption.TopDirectoryOnly);
            foreach (var filePath in allFilesMatched)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                //Console.WriteLine(indentation + "File: " + fileInfo.Name);
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", fileInfo.Name);
                writer.WriteEndElement();
            }

            var allSubdirectories = Directory.EnumerateDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            foreach (var dir in allSubdirectories)
            {
                TraverseDir(writer, dir, mask, indentation + "   ");
            }
            writer.WriteEndElement();
        }
    }


}
