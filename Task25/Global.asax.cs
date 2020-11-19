﻿using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Task25.BLL.Infrustructure;
using Task25.Infrustructure;

namespace Task25
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule regDIForBLL = new NinjectRegistrationsBLL("Task25");
            NinjectModule regDIForWEB= new NinjectRegistrations();
            var kernel = new StandardKernel(regDIForWEB, regDIForBLL);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));


            kernel.Unbind<ModelValidatorProvider>();


        }
    }
}
