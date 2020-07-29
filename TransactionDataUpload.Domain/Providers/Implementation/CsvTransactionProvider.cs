using System.Web;
using TransactionDataUpload.Domain.Providers.Abstraction;
using TransactionDataUpload.Domain.Providers.Implementation.Base;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Providers.Implementation
{
    public class CsvTransactionProvider : CsvUnitProvider<TransactionCsvUnit>, ICsvTransactionProvider
    {
        public CsvTransactionProvider() : base()
        {
        }

        public CsvTransactions GetCsvUnits(HttpPostedFileBase file)
        {
            var transactionCsvUnits = GetUnitAsync(file);
            return new CsvTransactions { TransactionCsvUnits = transactionCsvUnits };
        }
    }
}
