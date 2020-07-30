using System.Web;
using TransactionDataUpload.Domain.Providers.Abstraction;
using TransactionDataUpload.Domain.Providers.Implementation.Base;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Providers.Implementation
{
    public class XmlTransactionProvider : XmlUnitProvider<XmlTransactions>, IXmlTransactionProvider
    {
        public XmlTransactions GetXmlUnits(HttpPostedFileBase file)
        {
            var transactionXmlUnits = GetUnit(file);
            return transactionXmlUnits;
        }
    }
}
