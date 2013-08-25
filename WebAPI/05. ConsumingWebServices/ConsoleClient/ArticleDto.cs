using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleClient
{
    [JsonObject]
    public class ArticleDto
    {
        [JsonProperty(PropertyName="author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "publish_date")]
        public DateTime? PublishDate { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine("Article Title: {0}", this.Title);
            Console.WriteLine("Article Author: {0}", this.Author);
            Console.WriteLine("Article PublishDate: {0}", this.PublishDate);
            Console.WriteLine("Article Source: {0}", this.Source);
            Console.WriteLine("Article Url: {0}", this.Url);
            Console.WriteLine("Article Summary: {0}", this.Summary);
        }
    }

    [JsonObject]
    public class ArticleListDto
    {
        [JsonProperty(PropertyName = "articles")]
        public IEnumerable<ArticleDto> Articles { get; set; }
    }
}




//"author":"Michael Maloney",
//"publish_date":"Tue, 05 Oct 2010 11:30:00 +0100",
//"source":"television",
//"source_url":"http:\/\/www.tvsquad.com\/rss.xml",
//"summary":"<p>Filed under: <ahref=\"http:\/\/www.tvsquad.com\/category\/features\/\" ..... ",
//"title":"RACHEL MCADAMS DATING MICHAEL SHEEN? (Showbiz Spy)",
//"url":"http:\/\/news.feedzilla.com\/en_us\/stories\/15583098?q=michael&client_source=api&format=json"