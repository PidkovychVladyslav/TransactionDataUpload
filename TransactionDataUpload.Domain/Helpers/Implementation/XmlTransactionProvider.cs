using System.Web;
using TransactionDataUpload.Domain.Helpers.Abstraction;
using TransactionDataUpload.Domain.Helpers.Implementation.Base;
using TransactionDataUpload.Models.Domain;

namespace TransactionDataUpload.Domain.Helpers.Implementation
{
    public class XmlTransactionProvider : XmlUnitProvider<XmlTransactions>, IXmlTransactionProvider
    {
        public XmlTransactionProvider() : base()
        {
        }

        public XmlTransactions GetXmlUnits(HttpPostedFileBase file)
        {
            var transactionXmlUnits = GetUnitAsync(file);
            return transactionXmlUnits;
        }
    }
}
