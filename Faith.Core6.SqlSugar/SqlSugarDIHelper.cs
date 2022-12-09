using Autofac;
using Faith.Core6.SqlSugar.ColumnAttribute;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar
{
    public static class SqlSugarDIHelper
    {
        private readonly static string ConnectionString = "Server=120.79.81.249;Port=3306;Database=faithdb;Uid=root;Pwd=Xyf12138...;pooling=true;";
        //ConcurrentDictionary 字典是线程安全的字典 可由多个线程同时访问的键/值对的线程安全集合
        private readonly static ConcurrentDictionary<string, ConnectionConfig> ConnectionConfig = new ConcurrentDictionary<string, ConnectionConfig>();
        private static ConnectionConfig GetConnectionConfig(string connString)
        {
            //SqlSugar是通过SqlSugarClient来进行数据库的操作，而创建SqlSugarClient我们需要ConnectionConfig这个类对象
            //GetOrAdd
            //如果该键不存在，则将键/值对添加到 ConcurrentDictionary<TKey,TValue> 中。 如果该键存在，则返回新值或现有值。
           return ConnectionConfig.GetOrAdd(connString, connString =>
            {
                var connConfig = new ConnectionConfig();
                connConfig.ConnectionString = connString;
                connConfig.DbType = DbType.MySql;
                connConfig.IsAutoCloseConnection = true;
                connConfig.LanguageType = LanguageType.English;
                connConfig.ConfigureExternalServices.EntityService = (propertyInfo, columeInfo) =>
                {
                    var attr = propertyInfo.GetCustomAttributes(true);
                    var columnName = propertyInfo.Name;
                    if (attr.Any(it => it is SugarColumn))
                    {
                        return;
                    }
                    if (attr.Any(it => it is IsUnderlineAttribute))
                    {
                        //特性为下划线
                        columnName = propertyInfo.Name.Lowercase().LowercaseAdd_();
                    }
                    columeInfo.DbColumnName = columnName;
                    columeInfo.IsNullable = true;

                    if (propertyInfo.Name == "Id" || columnName == "Guid")
                    {
                        columeInfo.IsPrimarykey = true;
                        columeInfo.IsNullable = false;
                        return;
                    }


                    if (attr.Any(x => x is RequiredAttribute))
                    {
                        columeInfo.IsNullable = false;
                        return;
                    }

                    var stringLength = attr.FirstOrDefault(x => x is StringLengthAttribute);
                    if (stringLength != null)
                    {
                        var stl = stringLength as StringLengthAttribute;
                        columeInfo.Length = stl.MaximumLength;
                        return;
                    }
                };
                // 设置表名
                connConfig.ConfigureExternalServices.EntityNameService = (type, entityInfo) =>
                {
                    var attributes = type.GetCustomAttributes(true);
                    if (attributes.Any(it => it is SugarTable)) return;
                    var tableName = type.Name.Lowercase().LowercaseAdd_();
                    entityInfo.EntityName = tableName;
                };
                return connConfig;
            });
       
        }
        private static SqlSugarClient GetSqlSugarClient()
        {
            var conn = GetConnectionConfig(ConnectionString);
            var client = new SqlSugarClient(conn);
            //client.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //5.0.8.2 获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
            //UtilMethods.GetSqlString(DbType.SqlServer, sql, pars);
            //Console.WriteLine(sql);
            //};
            return client;
        }
        public static IServiceCollection AddSqlSugar(this IServiceCollection services) {
            services.AddScoped<ISqlSugarClient, SqlSugarClient>(service =>
            {
                return GetSqlSugarClient();
            });
            return services;
        }
        public static ContainerBuilder AddSqlSugar(this ContainerBuilder builder) {
            builder.Register(content => GetSqlSugarClient()).As<ISqlSugarClient>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
