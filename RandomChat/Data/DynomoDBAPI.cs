using RandomChat.Data;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RandomChat
{
    public class DynomoDBAPI
    {
        private const string ApiBaseUri = APIStrings.DYNAMODBURI;

        public static HttpClient InitializeClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
