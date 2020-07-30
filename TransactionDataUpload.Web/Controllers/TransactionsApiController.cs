using System;
using System.Collections.Generic;
using System.Web.Http;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Domain.Services.Abstraction;
using TransactionDataUpload.Models.Dto;

namespace TransactionDataUpload.Web.Controllers
{
    [RoutePrefix("api/transactions")]
    public class TransactionsApiController : ApiController
    {
        private readonly ITransactionsDataService _transactionsDataService;

        public TransactionsApiController(ITransactionsDataService transactionsDataService)
        {
            _transactionsDataService = transactionsDataService;
        }

        //Sample: api/transactions/getbycurrency?currency=usd
        [HttpGet]
        [Route("getbycurrency")]
        public IEnumerable<TransactionDataDto> GetByCurrency(string currency)
        {
            var transactions = _transactionsDataService.GetByCurrency(currency);
            return transactions;
        }

        //Sample: api/transactions/getbydaterange?startTime=2019-01-01&endTime=2020-01-01
        [HttpGet]
        [Route("getbydaterange")]
        public IEnumerable<TransactionDataDto> GetByDateRange(DateTime startTime, DateTime endTime)
        {
            var transactions = _transactionsDataService.GetByDateRange(startTime, endTime);
            return transactions;
        }

        //Sample: api/transactions/getbystatus?status=r
        [HttpGet]
        [Route("getbystatus")]
        public IEnumerable<TransactionDataDto> GetByStatus(string status)
        {
            var transactions = _transactionsDataService.GetByStatus(status);
            return transactions;
        }
    }
}