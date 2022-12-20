using Autofac;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.CatgorizeSugarDto;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService.Categorize;
using Faith.Core6.IContainerService;
using Faith.Core6.SqlSugar.Repsoitory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaithCore6Web.Controller.Categorize
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategorizeController : ControllerBase
    {
        /// <summary>
        /// 增加分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultDto<T_CategorizeSugar>> InsertCatgorizeSugarAsync(T_CategorizeSugar dto) {
            try
            {
                using var life = ContainerService.BeginLifetimeScope();
                ICategorizeService service = life.Resolve<ICategorizeService>();
                return await service.InsertCatgorizeSugarAsync(dto);
            }
            catch (UserFriendlyException) { throw; }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultDto<T_CategorizeSugar>> GetCatgorizeSugarAsync(GetCatgorizeDto dto) {
            try
            {
                using var life = ContainerService.BeginLifetimeScope();
                ICategorizeService service = life.Resolve<ICategorizeService>();
                return await service.GetCatgorizeSugarAsync(dto);
            }
            catch (UserFriendlyException) { throw; }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResultDto<T_CategorizeSugar>> DelCatgorizeSugarAsync(string cid) {
            try
            {
                using var life = ContainerService.BeginLifetimeScope();
                ICategorizeService service = life.Resolve<ICategorizeService>();
                return await service.DelCatgorizeSugarAsync(cid);
            }
            catch (UserFriendlyException) { throw; }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultDto<T_CategorizeSugar>> UpdateCatgorizeSugarAsync(UpdataCategorizeDto dto) {
            try
            {
                using var life = ContainerService.BeginLifetimeScope();
                ICategorizeService service = life.Resolve<ICategorizeService>();
                return await service.UpdateCatgorizeSugarAsync(dto);
            }
            catch (UserFriendlyException) { throw; }
            catch (Exception)
            {

                throw new Exception();
            }
        }
       }
}
