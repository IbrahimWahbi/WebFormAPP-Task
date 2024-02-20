using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Unity;
using WebFormAPP.Models;
using WebFormAPP.Services;
namespace WebFormAPP
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            IUnityContainer container = new UnityContainer();
            container.RegisterType<UnitOfWork, UnitOfWork>();
            container.RegisterType<IEmployeesService, EmployeesService>();
            container.RegisterType<IDepartmentsService, DepartmentsService>();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            
        }
    }
}