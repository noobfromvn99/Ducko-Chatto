using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RandomChat.Data
{
    public class LocationApi
    {
        private const string ApiBaseUri = APIStrings.IPSTACKURI;

        public static HttpClient InitializeClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
