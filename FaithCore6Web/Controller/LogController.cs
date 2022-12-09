using Autofac;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.IContainerService;
using Faith.EntityModel.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaithCore6Web.Controller
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        public async Task<ResultDto<T_Log>> GetLogListAsync()
        {
            using (var life = ContainerService.BeginLifetimeScope())
            {
                ILogService service = life.Resolve<ILogService>();
                return await service.GetLogListAsync();
            }
        }
    }
}
