using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Domain.Providers.Implementation.Base
{
    public abstract class CsvUnitProvider<TUnit> where TUnit : class, IUnit
    {
        protected IEnumerable<TUnit> GetUnitAsync(HttpPostedFileBase file)
        {
            try
            {
                using (var reader = new StreamReader(file.InputStream))
                {
                    var csv = new CsvReader(reader, 
                        new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ",", MissingFieldFound = null, HasHeaderRecord = false, BadDataFound = null});

                    var units = new List<TUnit>();
                    while (csv.Read())
                    {
                        TUnit unit = csv.GetRecord<TUnit>();
                        units.Add(unit);
                    }

                    return units;
                }
            }
            catch (TypeConverterException ex)
            {
                throw new Exception();
            }
        }
    }
}
