using System;
using System.Collections.Generic;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Data.Repositories.Abstraction.Base;

namespace TransactionDataUpload.Data.Repositories.Abstraction
{
    public interface ITransactionDataRepository : IRepository<TransactionData>
    {
        IEnumerable<TransactionData> GetByCurrency(string currency);
        IEnumerable<TransactionData> GetByDateRange(DateTime startTime, DateTime endTime);
        IEnumerable<TransactionData> GetByStatus(string status);
    }
}