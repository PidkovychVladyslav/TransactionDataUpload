using System;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using TransactionDataUpload.Core.Exceptions;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Domain.Providers.Implementation.Base
{
    public abstract class XmlUnitProvider<TUnit> where TUnit : class, IUnit
    {
        protected TUnit GetUnit(HttpPostedFileBase file)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(TUnit));
                using (var stream = file.InputStream)
                {
                    using (var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true }))
                    {
                        var request = xmlSerializer.Deserialize(reader);
                        if (request is TUnit unit)
                        {
                            return (TUnit)request;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ParsingValidationException($"{ex.Message} - {ex.InnerException?.Message}");
            }

            return null;
        }
    }
}
