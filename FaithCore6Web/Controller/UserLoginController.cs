using Autofac;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.IContainerService;
using Faith.EntityModel.Entity;
using FaithCore6Web.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaithCore6Web.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly ILoginUserService _loginUserService;
        public UserLoginController(ILoginUserService loginUserService) { 
        this._loginUserService = loginUserService;
        }
        [HttpPost]
        public async Task<ResultDto<User>> GetLoginUser(UserLoginDto userLogin)
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
    }
}
