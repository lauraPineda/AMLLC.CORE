using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using AMLLC.CORE.DATAMANAGER;

namespace AMLLC.CORE.WEBAPI
{
    public class IocConfig
    {
        public static void Configure()
        {

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType < EntityFrameworkProductRepository> ().AsImplementedInterfaces().InstancePerApiRequest().InstancePerHttpRequest();

            builder.RegisterType<UserRequestRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            builder.RegisterType<CompanyRequestRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            builder.RegisterType<ClientRequestRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            builder.RegisterType<ProyectRequestRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            builder.RegisterType<LocationRequestRepository>().AsImplementedInterfaces().InstancePerApiRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}