using System.Collections.Generic;
using System.Web.Http;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Domain.Managers.Abstraction;

namespace TransactionDataUpload.Web.Controllers
{
    [RoutePrefix("api/transactions")]
    public class TransactionsApiController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<TransactionData> Get()
        {
            var transactions = _unitOfWork.TransactionDatas.Get();
            return transactions;
        }
    }
}