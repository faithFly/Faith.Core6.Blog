using Faith.Application.Contracts.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace FaithCore6Web.Filter
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UserFriendlyException ex)
            {
                context.Result = new ContentResult
                {
                    StatusCode = ex.Code,
                    Content = ex.Message
                };
            }
            //如果异常没有被处理
            if (context.ExceptionHandled == false)
            {
                //定义返回信息
                ResultDto<object> res = new ResultDto<object>();
                res.ResultMsg = "发生错误请联系管理员";
                res.ResultCode = 500;
                _logger.LogError(context.HttpContext.Request.Path, context.Exception);
                context.Result = new ContentResult
                {
                    StatusCode = 500,
                    ContentType = "application/json;charset=utf-8",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            context.ExceptionHandled = true;
        }
    }
}
