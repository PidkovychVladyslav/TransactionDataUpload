using System.Xml.Serialization;
using TransactionDataUpload.Core.Exceptions;
using TransactionDataUpload.Core.Helpers;

namespace TransactionDataUpload.Models.Domain
{
    [XmlType("PaymentDetails")]
    public class PaymentDetailsXmlUnit
    {
        private string currencyCode;

        [XmlElement("Amount")]
        public decimal Amount { get; set; }
        [XmlElement("CurrencyCode")]
        public string CurrencyCode
        {
            get { return currencyCode; }
            set
            {
                if (!IsoCurrencyValidator.CheckCode(value))
                    throw new ParsingValidationException("Unknown ISO Code presented for currency");

                currencyCode = value;
            }
        }
    }
}
