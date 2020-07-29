using System.Web;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Providers.Abstraction
{
    public interface IXmlTransactionProvider
    {
        XmlTransactions GetXmlUnits(HttpPostedFileBase file);
    }
}
