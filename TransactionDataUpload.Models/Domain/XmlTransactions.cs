using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Models.Domain
{
    [Serializable]
    [XmlRoot("Transactions")]
    [XmlInclude(typeof(TransactionXmlUnit))]
    public class XmlTransactions : IUnit
    {
        [XmlElement("Transaction")]
        public List<TransactionXmlUnit> TransactionXmlUnits { get; set; }
    }
}
