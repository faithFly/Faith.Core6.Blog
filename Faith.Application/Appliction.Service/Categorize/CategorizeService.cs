using AutoMapper;
using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.CatgorizeSugarDto;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService.Categorize;
using Faith.Core6.SqlSugar.Repsoitory;
using Faith.Domain.ExpressionHelper;
using Faith.Domain.UserSession;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service.Categorize
{
    public class CategorizeService : ICategorizeService
    {
        private readonly ISqlSugarClient _Client;
        private readonly IFaithUserSession _userSession;
        private readonly IMapper _mapper;

        public CategorizeService(ISqlSugarClient client, 
            IFaithUserSession userSession,
            IMapper mapper
            )
        {
            _Client = client;
            _userSession = userSession;
            _mapper = mapper;
        }
        public async Task<ResultDto<T_CategorizeSugar>> InsertCatgorizeSugarAsync(T_CategorizeSugar dto) {
            try
            {
                dto.Id = Guid.NewGuid().ToString();
                dto.CreateBy = _userSession.GetCurrentUserName();
                dto.CreateTime = DateTime.Now;
                dto.UpdateBy = _userSession.GetCurrentUserName();
                dto.UpdateTime = DateTime.Now;
                var flag = await _Client.Insertable(dto).ExecuteCommandAsync() > 0 ? true : false;
                if (flag)
                {
                    return new ResultDto<T_CategorizeSugar> { ResultCode = 200 };
                }
                else
                {
                    throw new UserFriendlyException(404, "插入出错!");
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
        public async Task<ResultDto<T_CategorizeSugar>> GetCatgorizeSugarAsync(GetCatgorizeDto dto) {
            try
            {
                RefAsync<int> total = 0;
                Expression<Func<T_CategorizeSugar, bool>> query = x => x.IsDel == 0;
                if (!string.IsNullOrEmpty(dto.catgorizeName))
                {
                    query = query.And(x => x.CategorizeName.Contains(dto.catgorizeName));
                }
                var cateList = await _Client.Queryable<T_CategorizeSugar>().Where(query)
                    .OrderByDescending(x => x.CreateTime)
                    .ToPageListAsync(dto.pageIndex, dto.pageSize, total);
                return new ResultDto<T_CategorizeSugar>
                {
                    ResultCode = 200,
                    ResultSum = total,
                    ResultData = cateList
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public async Task<ResultDto<T_CategorizeSugar>> DelCatgorizeSugarAsync(string cid) {
            try
            {
                if (string.IsNullOrEmpty(cid))
                {
                    throw new UserFriendlyException(404, "id不能为空!");
                }
                var catObj =await _Client.Queryable<T_CategorizeSugar>().Where(x => x.IsDel == 0)
                    .SingleAsync() ?? throw new UserFriendlyException(404,"没有这条记录！");
                catObj.IsDel = 1;
                var flag = await _Client.Updateable(catObj).ExecuteCommandAsync() > 0 ? true : false;
                if (flag)
                {
                    return new ResultDto<T_CategorizeSugar> { ResultCode = 200, ResultMsg = "删除成功！" };
                }
                else
                {
                    throw new UserFriendlyException(400, "系统繁忙！");
                }
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
            
        }
        public async Task<ResultDto<T_CategorizeSugar>> UpdateCatgorizeSugarAsync(UpdataCategorizeDto dto) {
            try
            {
                var catObj =await _Client.Queryable<T_CategorizeSugar>().Where(x => x.IsDel == 0)
                    .SingleAsync() ?? throw new UserFriendlyException(404, "没有查到该条记录！");
                catObj.CategorizeName = dto.CategorizeName;
                catObj.ParentId = dto.ParentId;
                catObj.Level = dto.Level;
                var flag = await _Client.Updateable(catObj).ExecuteCommandAsync() > 0 ? true : false;
                if (flag)
                {
                    return new ResultDto<T_CategorizeSugar> { ResultCode = 200 };
                }
                else
                {
                    throw new UserFriendlyException(400, "系统繁忙");
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
