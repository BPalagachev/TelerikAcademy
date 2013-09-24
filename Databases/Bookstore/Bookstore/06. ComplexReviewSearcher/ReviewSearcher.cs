using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using System.Data.Entity;
using _07.SearchLog.Migrations;

public static class ReviewSearcher
{
    public static readonly string XmlFilePath = @"../../reviews-queries.xml";

    public static void Main()
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<SearchLogContext, Configuration>());

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlFilePath);
        string xPathQuery = "/review-queries/query";
        XmlSimpleWriter exporter = new XmlSimpleWriter(@"../../reviews-search-results.xml", Encoding.UTF8);

        // Open RootElement
        exporter.InitializeReader("search-results");

        // dbContext for task 7 - please note that this connection generate large 
        // ammount of queries rather then the search query itself
        using (var logContext = new SearchLogContext())
        {
            XmlNodeList queryElements = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode tag in queryElements)
            {
                var attr = tag.Attributes["type"];

                exporter.OpenTag("result-set");
                if (attr != null && attr.InnerText == "by-period")
                {
                    string startDate = tag.GetChildText("start-date");
                    string endDate = tag.GetChildText("end-date");
                    if (startDate == null || endDate == null)
                    {
                        throw new ArgumentException("start-date and end-date tags are manadatory for by-date queries");
                    }

                    var result = BookstoreDAL.ConductByDateQuery(startDate, endDate);
                    WriteResultToXml(result, exporter);
                    WriteLog(logContext, tag.OuterXml);
                }
                else if (attr != null && attr.InnerText == "by-author")
                {
                    string authorName = tag.GetChildText("author-name");
                    if (authorName == null)
                    {
                        throw new ArgumentException("author-name tag is manadatory for by-author queries");
                    }

                    var result = BookstoreDAL.ConductByAuthorQuery(authorName);
                    WriteLog(logContext, tag.OuterXml);
                    WriteResultToXml(result, exporter);
                }
                else
                {
                    throw new ArgumentException("Unknow Query Format");
                }

                exporter.CloseTag(); // Closing result-set
            }

            logContext.SaveChanges();
        }

        exporter.CloseReader();
    }

    private static void WriteLog(SearchLogContext logContext, string queryXml)
    {
        var newLog = new SearchLog()
        {
            EntryDate = DateTime.Now,
            XmlQuery = queryXml
        };
        logContext.SearchLogs.Add(newLog);
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

    public static void WriteResultToXml(IList<QueryResult> result, XmlSimpleWriter exporter)
    {
        foreach (var res in result)
        {
            exporter.OpenTag("review");
            exporter.AddSimpleTag("date", res.Date.ToString("d-MMM-yyyy"));
            if (res.Content != null)
            {
                exporter.AddSimpleTag("content", res.Content);
            }
            exporter.OpenTag("book");
            if (res.BookTitle != null)
            {
                exporter.AddSimpleTag("title", res.BookTitle);
            }
            if (res.BookUrl != null)
            {
                exporter.AddSimpleTag("url", res.BookUrl);
            }

            if (res.BookAuthors.Count() > 0)
            {
                exporter.AddSimpleTag("authors", string.Join(", ", res.BookAuthors));
            }
            exporter.CloseTag();
            exporter.CloseTag();
        }
    }

}
