using System;
using System.Xml.Serialization;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Models.Domain
{
    public class TransactionXmlUnit : IMappable
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("TransactionDate")]
        public DateTime TransactionDate { get; set; }
        [XmlElement("PaymentDetails")]
        public PaymentDetailsXmlUnit PaymentDetails { get; set; }
        [XmlElement("Status")]
        public string Status { get; set; }
    }

}
