using Faith.Application.Contracts.Application.Dto;
using Faith.EntityModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService
{
    public interface ICountryNightService
    {
        Task<ResultDto<UserCheckDto>> TvUserCheckAsync(string phoneNum);
        Task<ResultDto<UserCheckDto>> getActivityByVillage(getActivityByVillageDto dto);
    }
}
