namespace TransactionDataUpload.Web.App_Start
{
    using Autofac;
    using System.Collections.Generic;
    using Domain.Services.Abstraction.Base;
    using Domain.Services.Implementation;
    using Domain.Factories.Implementation;
    using Autofac.Integration.Mvc;
    using System.Web.Mvc;
    using TransactionDataUpload.Domain.Managers.Implementation;
    using Autofac.Integration.WebApi;
    using System.Reflection;
    using System.Web.Http;
    using TransactionDataUpload.Domain.Providers.Implementation;

    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces();
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