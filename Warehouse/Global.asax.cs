using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Warehouse.Models;

namespace Warehouse
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Store global errors

        //private ApplicationDbContext _db = new ApplicationDbContext();

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    GlobalErrorsModels error = new GlobalErrorsModels();

        //    Exception exception = Server.GetLastError();

        //    error.Description = exception.ToString();

        //    //Save global error
        //    _db.GlobalErrorsModels.Add(error);
        //    _db.SaveChanges();

        //     Server.ClearError();

        //    Response.Redirect("~/GlobalErrors/Index");
        //}
    }
}
