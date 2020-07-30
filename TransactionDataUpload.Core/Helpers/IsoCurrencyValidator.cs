using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TransactionDataUpload.Core.Helpers
{
    public static class IsoCurrencyValidator
    {
        private static readonly IEnumerable<string> currencySymbols;
        static IsoCurrencyValidator()
        {
            currencySymbols = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                .Select(x => (new RegionInfo(x.LCID)).ISOCurrencySymbol);
        }
        public static bool CheckCode(string currencyCode)
        {
            return currencySymbols.Contains(currencyCode);
        }
    }
}
