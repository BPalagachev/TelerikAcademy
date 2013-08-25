using Music.DataTransferObjects;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Music.Clients
{
    public class JsonClient<T>
    {
        private readonly HttpClient Client;

        public JsonClient(string baseAddress)
        {
            Client = new HttpClient { BaseAddress = new Uri(baseAddress) };
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
            var response = Client.PutAsJsonAsync(resource, value).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public void Post(string resource, T value)
        {
            var response = Client.PostAsJsonAsync(resource, value).Result;
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
