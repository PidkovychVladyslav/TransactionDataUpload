using System.Web;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Providers.Abstraction
{
    public interface ICsvTransactionProvider
    {
        CsvTransactions GetCsvUnits(HttpPostedFileBase file);
    }
}
