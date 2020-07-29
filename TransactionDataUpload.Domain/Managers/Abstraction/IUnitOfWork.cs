using System;
using TransactionDataUpload.Data.Repositories.Abstraction;

namespace TransactionDataUpload.Domain.Managers.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        ITransactionRepository Transactions { get; }
        ITransactionDataRepository TransactionDatas { get; }
        int SaveChanges();
        void SetAutoDetectChanges(bool state);
    }
}
