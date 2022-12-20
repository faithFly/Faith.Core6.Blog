using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.CatgorizeSugarDto;
using Faith.Core6.SqlSugar.Repsoitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService.Categorize
{
    public interface ICategorizeService
    {
        Task<ResultDto<T_CategorizeSugar>> InsertCatgorizeSugarAsync(T_CategorizeSugar dto);
        Task<ResultDto<T_CategorizeSugar>> GetCatgorizeSugarAsync(GetCatgorizeDto dto);
        Task<ResultDto<T_CategorizeSugar>> DelCatgorizeSugarAsync(string cid);
        Task<ResultDto<T_CategorizeSugar>> UpdateCatgorizeSugarAsync(UpdataCategorizeDto dto);




    }
}
