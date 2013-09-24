using System;
using System.Collections.Generic;
using System.Xml;
using Bookstore.Data;

public static class SimpleBookSearcher
{
    public static readonly string XmlFilePath = @"../../simple-query.xml";

    public static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlFilePath);
        string xPathQuery = "/query";

        XmlNodeList queryElements = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode tag in queryElements)
        {
            string title = tag.GetChildText("title");
            string author = tag.GetChildText("author");
            string isbn = tag.GetChildText("isbn");

            IList<Book> queryResult = BookstoreDAL.SearchForBooks(title, author, isbn);
            PrintQueryResult(queryResult);
        }
    }

    public static void PrintQueryResult(IList<Book> queryResult)
    {
        int numerOfBooksFound = queryResult.Count;
        if (numerOfBooksFound == 0)
        {
            Console.WriteLine("Nothing found");
            return;
        }

        Console.WriteLine("{0} books found", numerOfBooksFound);

        foreach (var book in queryResult)
        {
            Console.WriteLine("{0} --> {1}", book.Title, book.Reviews.Count);
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
