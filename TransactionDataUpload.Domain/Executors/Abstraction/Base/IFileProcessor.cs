using System.Web;

namespace TransactionDataUpload.Domain.Executors.Abstraction.Base
{
    public interface IFileProcessor
    {
        bool SupportsFormat(string fileName);
        void Process(HttpPostedFileBase file);
    }
}
