using System.Xml.Serialization;

namespace TransactionDataUpload.Models.Domain
{
    [XmlType("PaymentDetails")]
    public class PaymentDetailsXmlUnit
    {
        [XmlElement("Amount")]
        public decimal Amount { get; set; }
        [XmlElement("CurrencyCode")]
        public string CurrencyCode { get; set; }
    }
}
