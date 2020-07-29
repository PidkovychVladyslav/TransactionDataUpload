using TransactionDataUpload.Data;
using TransactionDataUpload.Data.Repositories.Abstraction;
using TransactionDataUpload.Data.Repositories.Implementation;
using TransactionDataUpload.Domain.Managers.Abstraction;

namespace TransactionDataUpload.Domain.Managers.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private DataContext _context;
        private ITransactionRepository _transactionRepository;
        private ITransactionDataRepository _transactionDataRepository;  

        #endregion

        #region Properties

        public ITransactionRepository Transactions => _transactionRepository ?? (_transactionRepository = new TransactionRepository(_context));
        public ITransactionDataRepository TransactionDatas => _transactionDataRepository ?? (_transactionDataRepository = new TransactionDataRepository(_context));

        #endregion

        #region Constructors

        public UnitOfWork()
        {
            _context = new DataContext();
        }

        #endregion

        #region Interface Members

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
            _context = null;
        }

        public void SetAutoDetectChanges(bool state)
        {
            _context.Configuration.AutoDetectChangesEnabled = state;
        }

        #endregion

    }
}
