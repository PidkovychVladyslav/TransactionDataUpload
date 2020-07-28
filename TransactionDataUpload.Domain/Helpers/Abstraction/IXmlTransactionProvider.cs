using System.Web;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Helpers.Abstraction
{
    public interface IXmlTransactionProvider
    {
        XmlTransactions GetXmlUnits(HttpPostedFileBase file);
    }
}
