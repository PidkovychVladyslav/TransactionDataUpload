using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Reflection;
using System.Web.Http;
using TransactionDataUpload.Domain.Managers.Implementation;
using TransactionDataUpload.Domain.Factories.Implementation;
using TransactionDataUpload.Domain.Providers.Implementation;
using TransactionDataUpload.Domain.Services.Abstraction.Base;
using TransactionDataUpload.Domain.Services.Implementation;

namespace TransactionDataUpload.Web.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces();
            builder.RegisterType<TransactionsDataService>().AsImplementedInterfaces();
            builder.RegisterType<FileProcessorFactory>().AsImplementedInterfaces();
            builder.RegisterType<CsvFileProcessingService>().AsImplementedInterfaces();
            builder.RegisterType<XmlFileProcessingService>().AsImplementedInterfaces();
            builder.RegisterType<CsvTransactionProvider>().AsImplementedInterfaces();
            builder.RegisterType<XmlTransactionProvider>().AsImplementedInterfaces();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var allDependencies = scope.Resolve<IEnumerable<IFileProcessingService>>();
            }

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}