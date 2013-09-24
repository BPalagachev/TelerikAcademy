using System;
using System.Collections.Generic;
using System.Xml;

public static class ComplexImporter
{
    public static readonly string XmlFilePath = @"../../complex-books.xml";

    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlFilePath);
        string xPathQuery = "/catalog/book";

        XmlNodeList bookmarkElements = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookmarkElement in bookmarkElements)
        {
            XmlNodeList authorNodes = bookmarkElement.SelectNodes("authors/author");
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

            var allReviews  = ReadReviews(bookmarkElement.SelectNodes("reviews/review"));
            BookstoreDAL.AddComplexBooks(authors, title, isbn, price, webSite, allReviews);
        }
    }

    public static IList<Tuple<string, string, string>> ReadReviews(XmlNodeList reviewNodes)
    {
            IList<Tuple<string, string, string>> reviews = new List<Tuple<string, string, string>>();
            foreach (XmlNode item in reviewNodes)
            {
                string text = item.InnerText.Trim();

                string authorName = null;
                if (item.Attributes["author"] != null)
                {
                    authorName = item.Attributes["author"].InnerText.Trim();
                }

                string date = null;
                if (item.Attributes["date"] != null)
                {
                    date = item.Attributes["date"].InnerText.Trim();
                }

                var newReview = new Tuple<string, string, string>(text, authorName, date);
                reviews.Add(newReview);
            }

            return reviews;
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
