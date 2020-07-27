using System;

namespace TransactionDataUpload.Data.Entities
{
    public class TransactionData : BasicEntity
    {
        public int TransactionId { get; set; }
        public string Identificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
