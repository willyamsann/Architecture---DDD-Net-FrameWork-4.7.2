using Arquitetura.Application.Modules.ProductManagement.Interfaces;
using Arquitetura.Application.Modules.ProductManagement.Services;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Repositories;
using Arquitetura.Domain.Modules.ProductManagement.Interfaces.Services;
using Arquitetura.Domain.Modules.ProductManagement.Services;
using Arquitetura.Infra.Data.Modules.ProductManagement.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Arquitetura.Service.Api
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
            AutoMapperWebConfiguration.Configure();

            var container = new Container();

            container.Register<IProductAppService, ProductAppService>(Lifestyle.Singleton);
            container.Register<IProductService, ProductService>(Lifestyle.Singleton);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration); //web api          
            container.Verify();

            //DependencyResolver.SetResolver(
            //new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container); //web api

        }

    }
}
