﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDb.libs.DynamoDb
{
    public interface IGetItem
    {
        Task<DynamoTableItem> GetItems(int? id);
    }
}
