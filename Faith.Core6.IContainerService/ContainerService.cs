using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Faith.Application.Appliction.Service;
using Faith.Application.Appliction.Service.Articles;
using Faith.Application.Appliction.Service.Cache;
using Faith.Application.Appliction.Service.Categorize;
using Faith.Application.Contracts.Application.IService;
using Faith.Application.Contracts.Application.IService.Articles;
using Faith.Application.Contracts.Application.IService.Categorize;
using Faith.Core6.SqlSugar;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.AutoMapper;
using Faith.Domain.JWT;
using Faith.Domain.UserSession;
using Microsoft.AspNetCore.Http;
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
            //automapper
            builder.Register<IMapper>(r =>
            {
                var mapperConfiguration = new MapperConfiguration(c =>
                {
                    c.AddProfile(new FaithMapperProfile());//刚刚我们注册的Profile类。
                });
                mapperConfiguration.AssertConfigurationIsValid();
                return new Mapper(mapperConfiguration);
            });
            builder.RegisterType<FaithUserSession>().As<IFaithUserSession>().InstancePerLifetimeScope();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
            //Jwt
            builder.RegisterType<JWTHelper>().InstancePerLifetimeScope();
            //dbcontext
            builder.RegisterType<faithdbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DistributedCacheService>().InstancePerLifetimeScope();
            builder.RegisterType<CategorizeService>().As<ICategorizeService>().InstancePerLifetimeScope();
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
