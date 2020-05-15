using DynamoDb.libs.DynamoDb;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public class ChatManger
    {
        private HttpClient client;
        private readonly static ChatManger _instance = new ChatManger();

        public static ChatManger getInstance()
        {
            return _instance;
        }
        private ChatManger()
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

        public async Task<bool> Send(int? TopicId, string content, int? UserId)
        {
            var response = await client.GetAsync($"api/DynamoDB/send?TopicId={TopicId}&reply={content}&UserId={UserId}");

            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

    }
}
