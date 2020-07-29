using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionDataUpload.Domain.Factories.Abstraction;
using TransactionDataUpload.Domain.Managers.Abstraction;

namespace TransactionDataUpload.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileProcessorFactory _fileProcessorFactory;

        public HomeController(IUnitOfWork unitOfWork, IFileProcessorFactory fileProcessorFactory)
        {
            _unitOfWork = unitOfWork;
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