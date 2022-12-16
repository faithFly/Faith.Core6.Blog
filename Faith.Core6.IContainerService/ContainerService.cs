using Autofac;
using Faith.Application.Appliction.Service;
using Faith.Application.Appliction.Service.Articles;
using Faith.Application.Appliction.Service.Cache;
using Faith.Application.Contracts.Application.IService;
using Faith.Application.Contracts.Application.IService.Articles;
using Faith.Core6.SqlSugar;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.JWT;
using Microsoft.Extensions.Configuration;
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
            builder.RegisterType<ConfigurationManager>().As<IConfiguration>().InstancePerLifetimeScope();
            //Jwt
            builder.RegisterType<JWTHelper>().InstancePerLifetimeScope();
            //dbcontext
            builder.RegisterType<faithdbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DistributedCacheService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<HttpClientService>().As<IHttpClientService>().InstancePerLifetimeScope();
            builder.RegisterType<CountryNightService>().As<ICountryNightService>().InstancePerLifetimeScope();
            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUserService>().As<ILoginUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ArticlesService>().As<IArticlesService>().InstancePerLifetimeScope();

            builder.AddSqlSugar();

            container = builder.Build();
        }
    }
}
