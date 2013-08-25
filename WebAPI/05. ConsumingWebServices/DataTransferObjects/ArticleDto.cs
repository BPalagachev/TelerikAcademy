using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class ArticleDto
    {
        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string Source { get; set; }

        public string Summary { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}


//"author":"Michael Maloney",
//"publish_date":"Tue, 05 Oct 2010 11:30:00 +0100",
//"source":"television",
//"source_url":"http:\/\/www.tvsquad.com\/rss.xml",
//"summary":"<p>Filed under: <ahref=\"http:\/\/www.tvsquad.com\/category\/features\/\" ..... ",
//"title":"RACHEL MCADAMS DATING MICHAEL SHEEN? (Showbiz Spy)",
//"url":"http:\/\/news.feedzilla.com\/en_us\/stories\/15583098?q=michael&client_source=api&format=json"