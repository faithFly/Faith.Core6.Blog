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
//ע��jwt������
builder.Services.AddSingleton(new JWTHelper(config));
//ע�����
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, //�Ƿ���֤Issuer
        ValidIssuer = builder.Configuration["Jwt:Issuer"], //������Issuer
        ValidateAudience = true, //�Ƿ���֤Audience
        ValidAudience = builder.Configuration["Jwt:Audience"], //������Audience
        ValidateIssuerSigningKey = true, //�Ƿ���֤SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
        ValidateLifetime = true, //�Ƿ���֤ʧЧʱ��
        ClockSkew = TimeSpan.FromMinutes(30), //����ʱ���ݴ�ֵ�������������ʱ�䲻ͬ�����⣨�룩
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
 
#region ����
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
        Title = $"{apiName}�ӿ��ĵ�-NetCore6.0"
    });
    s.OrderActionsBy(x => x.RelativePath);
    s.IncludeXmlComments("FaithCore.xml", true);
    s.DocInclusionPredicate((docName, description) => true);
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ���·�����Bearer {token} ���ɣ�ע������֮���пո�",
        Name = "Authorization",//jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
        Type = SecuritySchemeType.ApiKey
    });
    //��֤��ʽ���˷�ʽΪȫ������
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
           ConfigId=DBEnum.Ĭ�����ݿ�,
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