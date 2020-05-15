using DynamoDb.libs.DynamoDb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public class ChatManger
    {
        private HttpClient client;
        public ChatManger()
        {
            client = DynomoDBAPI.InitializeClient();
        }

        public async void CreateTestTable() 
        {
            var response = await client.GetAsync("api/DynamoDB/createtable");
            if (!response.IsSuccessStatusCode)
                throw new Exception();
        }

        public async Task<DynamoTableItem> GetReply(int? TopicId)
        {
            var response = await client.GetAsync($"api/DynamoDB/getreply?TopicId={TopicId}");

            if (!response.IsSuccessStatusCode)
                throw new ItemNotFoundExcpetion("Status Failed");

            var result = response.Content.ReadAsStringAsync().Result;

            var DynamoTableItem = JsonConvert.DeserializeObject<DynamoTableItem>(result);

            return DynamoTableItem;
        }

    }
}
