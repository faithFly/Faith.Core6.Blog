using Autofac;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.IContainerService;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.ExpressionHelper;
using Faith.EntityModel.Entity;
using Faith.EntityModel.ViewModel;
using FaithCore6Web.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FaithCore6Web.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly ILoginUserService _loginUserService;
        public readonly  faithdbContext _faithdbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserLoginController(ILoginUserService loginUserService,faithdbContext faithdbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._loginUserService = loginUserService;
            _faithdbContext = faithdbContext;
            _httpContextAccessor = httpContextAccessor; 
        }
        [HttpPost]
        public async Task<ResultDto<User>> GetLoginUser([FromBody]UserLoginDto userLogin)
        {
            try
            {
               return await _loginUserService.GetLoginUser(userLogin);
            }
            catch (UserFriendlyException) {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        
        [HttpPost]
        public async Task<ResultDto<User>> RegistUserAsync([FromBody] User user) {
            try
            {
                return await _loginUserService.RegistUserAsync(user);
            }
            catch (UserFriendlyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<string> HelloUserAsync(string? name) {
            string ipaddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            UserLog log = new UserLog();
            log.Id = Guid.NewGuid().ToString();
            log.Arr02 = ipaddress;
            log.Arr01 = name;
            log.CreateTime = DateTime.Now;
            _faithdbContext.UserLog.Add(log);
            _faithdbContext.SaveChanges();
            return name + "你是傻逼";
        }
        [HttpGet]
        public async Task<List<UserLog>> GetList() {
           IQueryable<UserLog> log = _faithdbContext.UserLog;
           var sql =log.ToQueryString();
            await Console.Out.WriteLineAsync("this is a sql:"
                +sql);
            return await log.ToListAsync();
        }
    
    }
}
