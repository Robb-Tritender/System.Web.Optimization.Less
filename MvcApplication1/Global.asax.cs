﻿using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcApplication1.DynamicFiles;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // chain the custom bootstrap theme virtual path provider in HTTP runtime
            HostingEnvironment.RegisterVirtualPathProvider(new DynamicFileVirtualPathProvider());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }

        protected void Application_PreRequestHandlerExecute()
        {
            Thread.CurrentThread.CurrentCulture = DynamicFileVirtualPathProvider.CurrentCulture;
        }
    }
}