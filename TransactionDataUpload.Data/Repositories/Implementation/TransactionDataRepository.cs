using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Data.Repositories.Abstraction;
using TransactionDataUpload.Data.Repositories.Implementation.Base;

namespace TransactionDataUpload.Data.Repositories.Implementation
{
    public class TransactionDataRepository : Repository<TransactionData>, ITransactionDataRepository
    {
        public TransactionDataRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TransactionData> GetByCurrency(string currency)
        {
            return Set.Where(td => td.CurrencyCode == currency);
        }

        public IEnumerable<TransactionData> GetByDateRange(DateTime startTime, DateTime endTime)
        {
            return Set.Where(td => td.TransactionDate >= startTime && td.TransactionDate <= endTime);
        }

        public IEnumerable<TransactionData> GetByStatus(string status)
        {
            return Set.Where(td => td.Status.ToString() == status);
        }
    }
}
