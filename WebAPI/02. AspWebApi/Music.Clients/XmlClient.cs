using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Music.Clients
{
    public class XmlClient<T>
    {
        private readonly HttpClient Client;


        public XmlClient(string baseAddress)
        {
            Client = new HttpClient { BaseAddress = new Uri(baseAddress) };
            Client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
        }

        public IEnumerable<T> Get(string resource)
        {
            HttpResponseMessage response = Client.GetAsync(resource).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<T> products = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                return products;
            }
            else
            {
                throw new InvalidOperationException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void Put(string resource, T value)
        {
            var response = Client.PutAsXmlAsync(resource, value).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void Post(string resource, T value)
        {
            var response = Client.PostAsXmlAsync(resource, value).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void DeleteAlbum(string resource)
        {
            var response = Client.DeleteAsync(resource).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}
