namespace TransactionDataUpload.Domain.Executors.Implementation
{
    using Abstraction;
    using System.Web;
    using TransactionDataUpload.Domain.Helpers.Abstraction;

    public class XmlProcessor : IXmlProcessor
    {
        private readonly IXmlTransactionProvider _xmlTransactionProvider;

        public XmlProcessor(IXmlTransactionProvider xmlTransactionProvider)
        {
            _xmlTransactionProvider = xmlTransactionProvider;
        }

        public void Process(HttpPostedFileBase file)
        {
            var transactions = _xmlTransactionProvider.GetXmlUnits(file);
        }

        public bool SupportsFormat(string fileName)
        {
            return fileName.ToLower().EndsWith(".xml");
        }
    }
}
