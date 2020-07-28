namespace TransactionDataUpload.Domain.Executors.Implementation
{
    using Abstraction;
    using System;
    using System.Web;

    public class CsvProcessor : ICsvProcessor
    {
        public void Process(HttpPostedFileBase file)
        {
            throw new NotImplementedException();
        }

        public bool SupportsFormat(string fileName)
        {
            return fileName.ToLower().EndsWith(".csv");
        }
    }
}
