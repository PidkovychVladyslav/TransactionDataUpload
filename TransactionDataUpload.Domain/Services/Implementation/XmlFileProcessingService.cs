using System.Web;
using TransactionDataUpload.Core.Helpers;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Domain.Automapper.Base;
using TransactionDataUpload.Domain.Managers.Abstraction;
using TransactionDataUpload.Domain.Providers.Abstraction;
using TransactionDataUpload.Domain.Services.Abstraction;

namespace TransactionDataUpload.Domain.Services.Implementation
{
    public class XmlFileProcessingService : IXmlFileProcessingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IXmlTransactionProvider _xmlTransactionProvider;

        public XmlFileProcessingService(IUnitOfWork unitOfWork, IXmlTransactionProvider xmlTransactionProvider)
        {
            _unitOfWork = unitOfWork;
            _xmlTransactionProvider = xmlTransactionProvider;
        }

        public void Process(HttpPostedFileBase file)
        {
            var xmlTransactions = _xmlTransactionProvider.GetXmlUnits(file);
            var entityTransactions = xmlTransactions.To<Transaction>();
            entityTransactions.FileName = file.FileName;

            _unitOfWork.Transactions.Create(entityTransactions);
            _unitOfWork.SaveChanges();
        }

        public bool SupportsFormat(string fileName)
        {
            return fileName.ToLower().EndsWith(AppConstants.SupportedFormats.Xml);
        }
    }
}
