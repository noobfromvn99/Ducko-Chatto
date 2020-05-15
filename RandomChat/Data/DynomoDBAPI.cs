using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RandomChat
{
    public class DynomoDBAPI
    {
        private const string ApiBaseUri = "https://getzkd18g3.execute-api.us-east-1.amazonaws.com/Prod/";

        public static HttpClient InitializeClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
