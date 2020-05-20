using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamoDb.libs.DynamoDb;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamoDBController : ControllerBase
    {
        private readonly IDynamoDb _dynamoDB;
        private readonly IPutItem _putItem;
        private readonly IGetItem _getItem;

        public DynamoDBController(IDynamoDb dynamoDb, IPutItem putItem, IGetItem getItem) {
            _dynamoDB = dynamoDb;
            _putItem = putItem;
            _getItem = getItem;
        }

        [Route("createtable")]
        public IActionResult CreateDynamoDbTable() 
        {
            _dynamoDB.createDynamoDBTable();

            return Ok();
        }

        [Route("send")]
        public IActionResult Send([FromQuery]int topicId, string reply,string ImageKey, int UserId)
        {
            Guid uuid = Guid.NewGuid();
            _putItem.AddNewEntry(uuid.ToString(), topicId, reply,ImageKey, UserId);
            return Ok();
        }

        [Route("getreply")]
        public async Task<IActionResult> getItems([FromQuery] int? topicId) 
        {
            var response = await _getItem.GetItems(topicId);
            return Ok(response);
        }
    }
}