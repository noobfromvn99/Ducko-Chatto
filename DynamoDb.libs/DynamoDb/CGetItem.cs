using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DynamoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDb.libs.DynamoDb
{
    public class CGetItem : IGetItem
    {
        private readonly IAmazonDynamoDB _client;

        public CGetItem(IAmazonDynamoDB client) 
        {
            _client = client;
        }

        public async Task<DynamoTableItem> GetItems(int? id)
        {
            var queryRequest = RequestBuilder(id);

            var result = await ScanAsync(queryRequest);

            return new DynamoTableItem
            {
                Items = result.Items.Select(Map).ToList()
            };
        }

        private Item Map(Dictionary<string, AttributeValue> result)
        {
            return new Item
            {
                ChatId = result["ChatId"].S,
                TopicId = Convert.ToInt32(result["TopicId"].N),
                Reply = result["Reply"].S,
                ReplyOn = result["ReplyOn"].S,
                UserId = Convert.ToInt32(result["UserId"].N)
            };
        }
        

        private async Task<ScanResponse> ScanAsync(ScanRequest queryRequest)
        {
            var response = await _client.ScanAsync(queryRequest);

            return response;
        }

        private ScanRequest RequestBuilder(int? TopicId)
        {
            if (TopicId.HasValue == false) 
            {
                return new ScanRequest
                {
                    TableName = "Ducko"
                };
            }


            return new ScanRequest
            {
                TableName = "Ducko",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {
                    ":v_TopicId", new AttributeValue { N = TopicId.ToString() }
                    }
                },
                FilterExpression = "TopicId = :v_TopicId",
                ProjectionExpression = "ChatId, TopicId , Reply, ReplyOn, UserId"
            };
        }
    }
}
