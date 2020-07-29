using System.Web;

namespace TransactionDataUpload.Domain.Services.Abstraction.Base
{
    public interface IFileProcessingService
    {
        bool SupportsFormat(string fileName);
        void Process(HttpPostedFileBase file);
    }
}
