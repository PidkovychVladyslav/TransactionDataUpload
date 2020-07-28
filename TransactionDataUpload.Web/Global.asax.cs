using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TransactionDataUpload.Web.App_Start;

namespace TransactionDataUpload.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacConfig.ConfigureContainer();
        }
    }
}
