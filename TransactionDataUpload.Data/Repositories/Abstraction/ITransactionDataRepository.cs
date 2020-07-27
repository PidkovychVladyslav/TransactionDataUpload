using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Data.Repositories.Abstraction.Base;

namespace TransactionDataUpload.Data.Repositories.Abstraction
{
    public interface ITransactionDataRepository : IRepository<TransactionData>
    {
    }
}