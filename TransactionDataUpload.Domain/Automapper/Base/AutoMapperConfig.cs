using AutoMapper;
using TransactionDataUpload.Domain.Profiles;

namespace TransactionDataUpload.Domain.Automapper.Base
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {

                #region Profiles
                cfg.AddProfile(new XmlTransactionProfile());
                cfg.AddProfile(new CsvTransactionProfile());
                cfg.AddProfile(new TransactionDataProfile());
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}