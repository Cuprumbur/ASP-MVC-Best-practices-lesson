using Autofac;
using Autofac.Integration.Mvc;
using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Data.Repositories;
using OutdorAdvManage.Web.Mappings;
using Store.Service;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace OutdorAdvManage.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();

            // Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(СounterpartyRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //// Services
            builder.RegisterAssemblyTypes(typeof(СounterpartyService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            //
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}