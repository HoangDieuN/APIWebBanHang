
using APIServices;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    public class ServiceProvider
    {
        public static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            //register web controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //register services
            builder.RegisterAssemblyTypes(typeof(SanPhamApiService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            //autofac container
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}