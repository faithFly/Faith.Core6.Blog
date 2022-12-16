using Autofac;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.Article;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService.Articles;
using Faith.Core6.IContainerService;
using Faith.EntityModel.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaithCore6Web.Controller.Articles
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        [HttpPost]
        public async Task<ResultDto<T_Article>> InsertArticleAsync(InsertArticlesDto dto) {
            try
            {
                using (var life = ContainerService.BeginLifetimeScope()) {
                    IArticlesService service = life.Resolve<IArticlesService>();
                    return await service.InsertArticlesAsync(dto);
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
    }
}
