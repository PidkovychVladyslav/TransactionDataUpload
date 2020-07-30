using System.Web;
using TransactionDataUpload.Core.Helpers;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Domain.Automapper.Base;
using TransactionDataUpload.Domain.Managers.Abstraction;
using TransactionDataUpload.Domain.Providers.Abstraction;
using TransactionDataUpload.Domain.Services.Abstraction;

namespace TransactionDataUpload.Domain.Services.Implementation
{
    public class CsvFileProcessingService : ICsvFileProcessingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICsvTransactionProvider _csvTransactionProvider;

        public CsvFileProcessingService(IUnitOfWork unitOfWork, ICsvTransactionProvider csvTransactionProvider)
        {
            _unitOfWork = unitOfWork;
            _csvTransactionProvider = csvTransactionProvider;
        }

        public void Process(HttpPostedFileBase file)
        {
            var csvTransactions = _csvTransactionProvider.GetCsvUnits(file);
            var entityTransactions = csvTransactions.To<Transaction>();
            entityTransactions.FileName = file.FileName;

            _unitOfWork.Transactions.Create(entityTransactions);
            _unitOfWork.SaveChanges();
        }

        public bool SupportsFormat(string fileName)
        {
            return fileName.ToLower().EndsWith(AppConstants.SupportedFormats.Csv);
        }
    }
}
