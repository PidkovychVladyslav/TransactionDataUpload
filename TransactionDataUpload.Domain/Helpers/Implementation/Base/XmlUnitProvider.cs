using System;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Domain.Helpers.Implementation.Base
{
    public abstract class XmlUnitProvider<TUnit> where TUnit : class, IUnit
    {
        protected TUnit GetUnitAsync(HttpPostedFileBase file)
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
            catch (Exception e)
            {
                throw new Exception();
            }

            return null;
        }
    }
}
