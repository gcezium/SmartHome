using Cezium.SmartHome.UI.Models.DB;
using Microsoft.AspNet.Identity;
using NLog;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cezium.SmartHome.UI
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            var hybridLifestyle = Lifestyle.CreateHybrid(
                () => HttpContext.Current != null,
                container.Options.DefaultScopedLifestyle,
                new ExecutionContextScopeLifestyle());

            string dbConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

            container.Register(() => new ApplicationDbContext(dbConnectionString), hybridLifestyle);
            container.Register<ILogger>(() => LogManager.GetCurrentClassLogger(), hybridLifestyle);
            container.Register<IIdentityMessageService, EmailService>(Lifestyle.Scoped);
            
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration, Assembly.GetExecutingAssembly());

            UseOwinContextInjector(app, container);
            
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver
                = new SimpleInjectorWebApiDependencyResolver(container);
        }


        private static void UseOwinContextInjector(IAppBuilder app, Container container)
        {
            app.Use(async (context, next) =>
            {
                using (var scope = container.BeginExecutionContextScope())
                {
                    await next.Invoke();
                }
            });
        }
    }
}