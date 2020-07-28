namespace TransactionDataUpload.Web.App_Start
{
    using Autofac;
    using System.Collections.Generic;
    using Domain.Executors.Abstraction.Base;
    using Domain.Executors.Implementation;
    using Domain.Factories.Implementation;
    using Domain.Helpers.Implementation;
    using Autofac.Integration.Mvc;
    using System.Web.Mvc;

    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<FileProcessorFactory>().AsImplementedInterfaces();
            builder.RegisterType<CsvProcessor>().AsImplementedInterfaces();
            builder.RegisterType<XmlProcessor>().AsImplementedInterfaces();
            builder.RegisterType<XmlTransactionProvider>().AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            using (var scope = container.BeginLifetimeScope())
            {
                var allDependencies = scope.Resolve<IEnumerable<IFileProcessor>>();
            }
        }
    }
}