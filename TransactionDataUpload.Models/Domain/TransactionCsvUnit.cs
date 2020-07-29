using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Models.Domain
{
    public class TransactionCsvUnit : IUnit, IMappable
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string TransactionDate { get; set; }
        public string Status { get; set; }
    }

}
