using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TransactionDataUpload.Domain.Automapper.Base;
using TransactionDataUpload.Web.App_Start;

namespace TransactionDataUpload.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.ConfigureContainer();
            AutoMapperConfiguration.Init();
        }
    }
}
