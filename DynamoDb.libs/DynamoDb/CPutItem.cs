using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDb.libs.DynamoDb
{
    public class CPutItem : IPutItem
    {
        private readonly IAmazonDynamoDB _dynamoClient;

        public CPutItem(IAmazonDynamoDB client) 
        {
            _dynamoClient = client;
        }
        public async Task AddNewEntry(string ChatId, int TopicId,string reply,string ImageKey, int UserId) 
        {
            var queryRequest = RequestBuilder(ChatId, TopicId, reply, ImageKey, UserId);

            await PutItemAsync(queryRequest);
        }

        private async Task PutItemAsync(PutItemRequest queryRequest)
        {
            await _dynamoClient.PutItemAsync(queryRequest);
        }

        private PutItemRequest RequestBuilder(string chatId, int TopicId, string reply, string ImageKey, int UserId)
        {
            var item = new Dictionary<string, AttributeValue>
            {
                {"ChatId", new AttributeValue{S = chatId.ToString()} },
                {"TopicId", new AttributeValue { N = TopicId.ToString()} },
                {"Reply", new AttributeValue{S = reply} },
                {"ImageKey", new AttributeValue{ S = ImageKey} },
                {"ReplyOn", new AttributeValue{ S = DateTime.Now.ToString()} },
                {"UserId", new AttributeValue{N = UserId.ToString()} }
            };

            return new PutItemRequest {
                TableName = "Ducko",
                Item = item
            };

        }
    }
}
