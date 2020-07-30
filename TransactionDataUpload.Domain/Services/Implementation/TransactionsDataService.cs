using System;
using System.Collections.Generic;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Domain.Automapper.Base;
using TransactionDataUpload.Domain.Managers.Abstraction;
using TransactionDataUpload.Domain.Services.Abstraction;
using TransactionDataUpload.Models.Dto;

namespace TransactionDataUpload.Domain.Services.Implementation
{
    public class TransactionsDataService : ITransactionsDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TransactionDataDto> GetByCurrency(string currency)
        {
            var transactionsByCurrency = _unitOfWork.TransactionDatas.GetByCurrency(currency);
            return MappedTransactions(transactionsByCurrency);
        }

        public IEnumerable<TransactionDataDto> GetByDateRange(DateTime startTime, DateTime endTime)
        {
            var transactionsByDateRange = _unitOfWork.TransactionDatas.GetByDateRange(startTime, endTime);
            return MappedTransactions(transactionsByDateRange);
        }

        public IEnumerable<TransactionDataDto> GetByStatus(string status)
        {
            var transactionsByStatus = _unitOfWork.TransactionDatas.GetByStatus(status);
            return MappedTransactions(transactionsByStatus);
        }

        private IEnumerable<TransactionDataDto> MappedTransactions(IEnumerable<TransactionData> transactionDatas)
        {
            return transactionDatas.To<TransactionDataDto>();
        }

    }
}
