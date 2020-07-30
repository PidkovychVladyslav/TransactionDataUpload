using System;
using System.Collections.Generic;
using TransactionDataUpload.Models.Dto;

namespace TransactionDataUpload.Domain.Services.Abstraction
{
    public interface ITransactionsDataService
    {
        IEnumerable<TransactionDataDto> GetByCurrency(string currency);
        IEnumerable<TransactionDataDto> GetByDateRange(DateTime startTime, DateTime endTime);
        IEnumerable<TransactionDataDto> GetByStatus(string status);
    }
}
