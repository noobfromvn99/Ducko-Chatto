using DynamoDB.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace DynamoDb.libs.DynamoDb
{
    public class DynamoTableItem
    {
        public IEnumerable<Item> Items { get; set; }
    }


}