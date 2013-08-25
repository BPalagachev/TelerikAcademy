using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;

namespace ConsoleClient
{
    public class Program
    {
        private static readonly string MediaType = "application/json";
        private static readonly string RootUrl = "http://api.feedzilla.com/v1/articles/";
        private static readonly HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            var title = ReadUserInput("Enter Title Filter");
            var url = ReadUserInput("Enter Url Filter");

            var articles = GetArticles(title, url);

            Console.WriteLine("{0} article found", articles.Count());
            foreach (var article in articles)
            {
                article.DisplayInfo();
            }
        }

        private static string ReadUserInput(string message)
        {
            Console.Write("{0}: ", message);
            var userInput = Console.ReadLine();
            return userInput;
        }

        ///search.json?q=Michael
        private static IEnumerable<ArticleDto> GetArticles(string titleFilter, string urlFilter)
        {
            string searchStr = string.Format("search.json?q={0}", titleFilter);

            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(RootUrl + searchStr);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            request.Method = HttpMethod.Get;

            HttpResponseMessage respone = Client.SendAsync(request).Result;

            var articlesJson = respone.Content.ReadAsStringAsync().Result;
            var articles = JsonConvert.DeserializeObject<ArticleListDto>(articlesJson).Articles;

            if (!string.IsNullOrEmpty(urlFilter))
            {
                articles = articles.Where(x => x.Url.Contains(urlFilter));
            }

            return articles;
        }
    }
}
