using Autofac;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.IService;
using Faith.Core6.IContainerService;
using Faith.EntityModel.Entity;
using Faith.EntityModel.ViewModel;
using FaithCore6Web.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Net.Http.Headers;

namespace FaithCore6Web.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async ValueTask<bool> InsertUserAsync() {
            try
            {
                using (var life = ContainerService.BeginLifetimeScope())
                {
                    IUserService service = life.Resolve<IUserService>();
                    return await service.InsertUserAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            
        }

      
    }
}
