using System.Net;
using System.Web;
using System.Web.Mvc;
using TransactionDataUpload.Core.Exceptions;
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
            try
            {
                var fileProcessor = _fileProcessorFactory.GetFileProcessor(uploadFile.FileName);
                fileProcessor.Process(uploadFile);

                return new HttpStatusCodeResult(HttpStatusCode.OK, "File upload processed successfully!");
            }
            catch (UnknownFormatException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (ParsingValidationException ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}