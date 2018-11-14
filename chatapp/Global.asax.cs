using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace chatapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Application_Start()
        {
            SqlDependency.Start(constr);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_End()
        {
            SqlDependency.Stop(constr);
        }
        protected void Session_Start()
        {
            var notifyDate = Session["Last"] != null ? Convert.ToDateTime(Session["Last"]).Date : DateTime.Now.Date;
            Notification nc = new Notification();
            nc.StudentRegister(notifyDate);
            Session["Last"] = DateTime.Now.Date;
        }
    }
}
