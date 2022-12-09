using Autofac;
using Faith.Application.Contracts.Application.Dto;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        [HttpPost]
        public async Task<ResultDto<User>> GetLoginUser(UserLoginDto userLogin)
        {
            try
            {
                using (var life = ContainerService.BeginLifetimeScope())
                {
                    ILoginUserService service = life.Resolve<ILoginUserService>();
                    return await service.GetLoginUser(userLogin);
                }
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
                using (var life = ContainerService.BeginLifetimeScope())
                {
                    ILoginUserService service = life.Resolve<ILoginUserService>();
                    return await service.RegistUserAsync(user);
                }
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
