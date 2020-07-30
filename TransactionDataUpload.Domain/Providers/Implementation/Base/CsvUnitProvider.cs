using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using TransactionDataUpload.Core.Exceptions;
using TransactionDataUpload.Core.Helpers;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Domain.Providers.Implementation.Base
{
    public abstract class CsvUnitProvider<TUnit, TUnitMap> where TUnit : class, IUnit where TUnitMap : ClassMap
    {
        protected IEnumerable<TUnit> GetUnit(HttpPostedFileBase file)
        {
            try
            {
                using (var reader = new StreamReader(file.InputStream))
                {
                    var csv = new CsvReader(reader, 
                        new CsvConfiguration(CultureInfo.CurrentCulture)
                        { Delimiter = AppConstants.CsvDelimiterCharacter, MissingFieldFound = null,
                            HasHeaderRecord = false, BadDataFound = null, CultureInfo = CultureInfo.InvariantCulture
                        });
                    csv.Configuration.RegisterClassMap<TUnitMap>();

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
                throw new ParsingValidationException($"Parse error on Row: {ex.ReadingContext.RawRow} Field Index {ex.ReadingContext.CurrentIndex} - {ex.Message}");
            }
        }
    }
}
