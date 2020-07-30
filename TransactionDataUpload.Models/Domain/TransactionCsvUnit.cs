using CsvHelper.Configuration;
using System;
using TransactionDataUpload.Core.Exceptions;
using TransactionDataUpload.Core.Helpers;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Models.Domain
{
    public class TransactionCsvUnit : IUnit, IMappable
    {
        private string currencyCode;
        
        public string Id { get; set; }
        public decimal Amount { get; set; }
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
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }

    public sealed class TransactionCsvUnitMap : ClassMap<TransactionCsvUnit>
    {
        public TransactionCsvUnitMap()
        {
            Map(m => m.Id).Validate(m => m.Length < 50);
            Map(m => m.Amount);
            Map(m => m.CurrencyCode);
            Map(m => m.TransactionDate).TypeConverterOption.Format(AppConstants.CsvDateFormat);
            Map(m => m.Status);
    }
    }

}
