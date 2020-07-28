using System.Web;
using System.Web.Mvc;
using TransactionDataUpload.Domain.Factories.Abstraction;

namespace TransactionDataUpload.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProcessorFactory _fileProcessorFactory;

        public HomeController(IFileProcessorFactory fileProcessorFactory)
        {
            _fileProcessorFactory = fileProcessorFactory;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadFile)
        {
            var fileProcessor = _fileProcessorFactory.GetFileProcessor(uploadFile.FileName);
            fileProcessor.Process(uploadFile);
            return RedirectToAction("Index");
        }
    }
}