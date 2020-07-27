using System.Data.Entity;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Data.Repositories.Abstraction;
using TransactionDataUpload.Data.Repositories.Implementation.Base;

namespace TransactionDataUpload.Data.Repositories.Implementation
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }
    }
}