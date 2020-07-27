using System;
using System.Collections.Generic;

namespace TransactionDataUpload.Data.Entities
{
    public class Transaction : BasicEntity
    {
        public string FileName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ICollection<TransactionData> Data { get; set; }
    }
}
