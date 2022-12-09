using Autofac;
using Faith.Application.Appliction.Service;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.IContainerService
{
    public class ContainerService
    {
        private static IContainer container = null;
        public static ILifetimeScope BeginLifetimeScope()
        {
            if (container == null)
            {
                RegisterAutoFac();
            }
            return container.BeginLifetimeScope();
        }
        public static void RegisterAutoFac() {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<HttpClientService>().As<IHttpClientService>().InstancePerLifetimeScope();
            builder.RegisterType<CountryNightService>().As<ICountryNightService>().InstancePerLifetimeScope();
            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUserService>().As<ILoginUserService>().InstancePerLifetimeScope();
            builder.AddSqlSugar();
            container = builder.Build();
        }
    }
}
