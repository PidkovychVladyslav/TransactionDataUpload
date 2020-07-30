using System.Web;
using TransactionDataUpload.Domain.Providers.Abstraction;
using TransactionDataUpload.Domain.Providers.Implementation.Base;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Providers.Implementation
{
    public class CsvTransactionProvider : CsvUnitProvider<TransactionCsvUnit, TransactionCsvUnitMap>, ICsvTransactionProvider
    {
        public CsvTransactions GetCsvUnits(HttpPostedFileBase file)
        {
            var transactionCsvUnits = GetUnit(file);
            return new CsvTransactions { TransactionCsvUnits = transactionCsvUnits };
        }
    }
}
