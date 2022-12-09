using Autofac;
using Autofac.Extensions.DependencyInjection;
using Faith.Application.Appliction.Service;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.IContainerService;
using Faith.Core6.SqlSugar;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.Excel;
using Faith.Domain.JWT;
using Faith.Domain.Shared.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SqlSugar;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(new[] { "http://*:12138" });
var config = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddHttpClient();

#region Jwt
//注入jwt帮助类
builder.Services.AddSingleton(new JWTHelper(config));
//注册服务
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, //是否验证Issuer
        ValidIssuer = builder.Configuration["Jwt:Issuer"], //发行人Issuer
        ValidateAudience = true, //是否验证Audience
        ValidAudience = builder.Configuration["Jwt:Audience"], //订阅人Audience
        ValidateIssuerSigningKey = true, //是否验证SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
        ValidateLifetime = true, //是否验证失效时间
        ClockSkew = TimeSpan.FromMinutes(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
        RequireExpirationTime = true,
    };
});
#endregion

#region ef core
string connectionString = config["DefaultConnection"];
//var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<faithdbContext>(opt =>
{
     opt.UseMySql(connectionString,ServerVersion.Parse("5.7-mysql"));
});
#endregion
 
#region 跨域
builder.Services.AddCors(option =>
    option.AddPolicy("localhost", policy =>
    policy.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin())
);
#endregion

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var apiName = "faith.Core";
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = $"{apiName}接口文档-NetCore6.0"
    });
    s.OrderActionsBy(x => x.RelativePath);
    s.IncludeXmlComments("FaithCore.xml", true);
    s.DocInclusionPredicate((docName, description) => true);
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 在下方输入Bearer {token} 即可，注意两者之间有空格",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });
    //认证方式，此方式为全局添加
    s.AddSecurityRequirement(new OpenApiSecurityRequirement 
    {
        { 
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference(){
                       Id = "Bearer",
                       Type = ReferenceType.SecurityScheme
                 }
        }, Array.Empty<string>() }
    });
});
#endregion

#region sql suglar
/*builder.Services.AddScoped<ISqlSugarClient, SqlSugarClient>(opt =>
{
    return new SqlSugarClient(new List<ConnectionConfig>() {
       new ConnectionConfig(){
           ConfigId=DBEnum.默认数据库,
           ConnectionString=connectionString,
           DbType=DbType.MySql,
           IsAutoCloseConnection=true
       }
    });
});*/
builder.Services.AddSqlSugar();
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{apiName} v1");
    s.RoutePrefix = "";
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
