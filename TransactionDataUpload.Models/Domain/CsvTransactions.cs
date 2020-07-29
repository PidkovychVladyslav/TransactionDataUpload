using System.Collections.Generic;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Models.Domain
{
    public class CsvTransactions : IUnit, IMappable
    {
        public IEnumerable<TransactionCsvUnit> TransactionCsvUnits { get; set; }
    }
}
