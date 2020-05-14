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

        public DynamoDBController(IDynamoDb dynamoDb) {
            _dynamoDB = dynamoDb;
        }

        [Route("createtable")]
        public IActionResult CreateDynamoDbTable() 
        {
            _dynamoDB.createDynamoDBTable();

            return Ok();
        }
    }
}