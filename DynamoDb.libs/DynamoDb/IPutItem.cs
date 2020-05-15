using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDb.libs.DynamoDb
{
    public interface IPutItem
    {
        Task AddNewEntry(string chatId, int TopicId, string reply, int UserId);
    }
}
