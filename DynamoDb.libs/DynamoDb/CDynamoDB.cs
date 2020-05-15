using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DynamoDb.libs.DynamoDb
{
    public class CDynamoDB : IDynamoDb
    {
        private readonly IAmazonDynamoDB _client;

        public CDynamoDB(IAmazonDynamoDB client) 
        {
            _client = client;
        }

        public void createDynamoDBTable() 
        {
            try
            {
                CreateTempTable();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }



        private void CreateTempTable()
        {
            Console.WriteLine("Creating table");

            var request = new CreateTableRequest
            {
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName = "Id",
                        AttributeType = "N"
                    }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = "HASH"
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 5,
                    WriteCapacityUnits = 5
                },
                TableName = "testTemp"
            };

            var response = _client.CreateTableAsync(request);

            waitUntileTableRead("testTemp");
        }

        private void waitUntileTableRead(string table)
        {
            string status = null;

            do
            {
                Thread.Sleep(5000);
                try
                {
                    var res = _client.DescribeTableAsync(new DescribeTableRequest
                    {
                        TableName = "testTemp"

                    });

                    status = res.Result.Table.TableStatus;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while (status != "ACTIVE");
            {
                Console.WriteLine("Success");
            }
        }
    }
}
