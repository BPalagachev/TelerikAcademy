using System;
using System.IO;
using System.Xml.Linq;


namespace _09.FilesAndDirXDocument
{
    class FileTreeXmlGenerator
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..";
            string mask = "*.exe";
            XElement booksXml = new XElement("FileSystem");

            TraverseDir(booksXml, path, mask, string.Empty);

            System.Console.WriteLine(booksXml);
            booksXml.Save("../../filesystem.xml");  
        }

        public static void TraverseDir(XElement parrentDocument, string rootPath, string mask, string indentation)
        {
            DirectoryInfo rootInfo = new DirectoryInfo(rootPath);
            //Console.WriteLine(indentation + "Dir: " + rootInfo.Name);
            parrentDocument.SetAttributeValue("name", rootInfo.Name);

            var allFilesMatched = Directory.EnumerateFiles(rootPath, mask, SearchOption.TopDirectoryOnly);
            foreach (var filePath in allFilesMatched)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                //Console.WriteLine(indentation + "File: " + fileInfo.Name);
                parrentDocument.Add( new XElement("file", fileInfo.Name));
            }

            var allSubdirectories = Directory.EnumerateDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            foreach (var dir in allSubdirectories)
            {
                XElement subdir = new XElement("Dir");
                parrentDocument.Add(subdir);
                TraverseDir(subdir, dir, mask, indentation + "   ");
            }
        }
    }
}
