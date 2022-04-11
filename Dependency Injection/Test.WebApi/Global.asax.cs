using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http.Dependencies;
using Test.Model;
using Test.Service;
using Test.Repository;
using Autofac.Integration.WebApi;
using Test.Model.Common;
using Test.Repository.Common;
using Test.Service.Common;

namespace Test.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;


            builder.RegisterType<Employee>().As<IEmployeeModel>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<Salary>().As<ISalaryModel>();
            builder.RegisterType<SalaryRepository>().As<ISalaryRepository>();
            builder.RegisterType<SalaryService>().As<ISalaryService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
        }
    }
}
