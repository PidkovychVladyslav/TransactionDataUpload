using System;
using System.Xml.Serialization;
using TransactionDataUpload.Core.Exceptions;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Models.Domain
{
    public class TransactionXmlUnit : IMappable
    {
        private string id;

        [XmlAttribute("id")]
        public string Id
        {
            get { return id; }
            set
            {
                if (value.Length > 50)
                    throw new ParsingValidationException("Transaction Id length is beigger than 50 characters");
                id = value;
            }
        }
        [XmlElement("TransactionDate")]
        public DateTime TransactionDate { get; set; }
        [XmlElement("PaymentDetails")]
        public PaymentDetailsXmlUnit PaymentDetails { get; set; }
        [XmlElement("Status")]
        public string Status { get; set; }
    }

}
