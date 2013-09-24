using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

public static class SimpleImporter
{
    public static readonly string XmlFilePath = @"../../simple-books.xml";

    public static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlFilePath);
        string xPathQuery = "/catalog/book";

        XmlNodeList bookmarkElements = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookmarkElement in bookmarkElements)
        {
            XmlNodeList authorNodes = bookmarkElement.SelectNodes("author");
            if (authorNodes.Count == 0)
            {
                throw new ArgumentException("Each book should have at least one author");
            }

            IList<string> authors = new List<string>();
            foreach (XmlNode author in authorNodes)
            {
                authors.Add(author.InnerText);
            }

            string title = bookmarkElement.GetChildText("title");
            if (title == null)
            {
                throw new ArgumentException("Each book should have title");
            }

            string isbn = bookmarkElement.GetChildText("isbn");
            string price = bookmarkElement.GetChildText("price");
            string webSite = bookmarkElement.GetChildText("web-site");

            BookstoreDAL.AddBook(authors, title, isbn, price, webSite);
        }
    }

    public static string GetChildText(this XmlNode element, string tagName)
    {
        var childText = element.SelectSingleNode(tagName);

        if (childText == null)
        {
            return null;
        }

        return childText.InnerText.Trim();
    }
}
