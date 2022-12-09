using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.IService;
using Faith.EntityModel.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service
{
    public class CountryNightService : ICountryNightService
    {
        private readonly IHttpClientService _httpClientService;
        public CountryNightService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ResultDto<UserCheckDto>> TvUserCheckAsync(string phoneNum)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNum))
                {
                    throw new Exception("手机号码不能为空！");
                }
                string dateNow = DateTime.Now.ToString("yyyyMMddHHmmss");
                string sign = _httpClientService.GetSignString(phoneNum,dateNow);
                string url = _httpClientService.GetUrlString(phoneNum, sign, dateNow);
                var result = await _httpClientService.PostAsyncJson(url,"1");
                //将返回的转成实体类
                var resObj = JsonConvert.DeserializeObject<UserCheckDto>(result);
                return new ResultDto<UserCheckDto>
                {
                    ResultObj = resObj,
                    ResultCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResultDto<UserCheckDto>
                {
                    ResultCode = 500,
                    ResultMsg = ex.Message
                };
            }
         }

        public async Task<ResultDto<UserCheckDto>> getActivityByVillage(getActivityByVillageDto dto) {
            string url = $"https://scdreamtheaterdev.jinlanzuan.com/tv/getActivityByVillage?page={dto.page}&pageSize={dto.pageSize}&villageId={dto.villageId}";
            var result = await _httpClientService.PostAsyncJson(url, "1");
            return new ResultDto<UserCheckDto>();
        }
    }
}
