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
        private readonly ILogService _logService;
        public LogController(ILogService _logService) { 
        this._logService = _logService;
        }
        [HttpGet]
        public async Task<ResultDto<T_Log>> GetLogListAsync(int pageSize,int pageIndex)
        {
           return await _logService.GetLogListAsync(pageSize,pageIndex);
        }
        //这里之后要做分库分表使用sqlsugar

    }
}
