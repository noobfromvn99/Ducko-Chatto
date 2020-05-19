using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoDB.Models
{
    public class Item
    {
        public string ChatId { get; set; }
        public int TopicId { get; set; }
        public string Reply { get; set; }
        public string ImageKey { get; set; }
        public string ReplyOn { get; set; }
        public int UserId { get; set; }

       
    }

}
