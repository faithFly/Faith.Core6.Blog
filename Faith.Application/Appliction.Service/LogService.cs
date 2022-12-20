using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.IService;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.UserSession;
using Faith.EntityModel.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service
{
    public class LogService : ILogService
    {
        private readonly faithdbContext _client;
        private readonly IFaithUserSession _userSession;

        public LogService(faithdbContext client,IFaithUserSession userSession)
        {
            _client = client;
            _userSession = userSession;
        }
        public async Task<ResultDto<T_Log>> GetLogListAsync(int pageSize, int pageIndex) {
            var userName = _userSession.GetCurrentUserName();
            var list = await _client.T_Logs.OrderByDescending(x=>x.CreateTime)
                .Skip((pageIndex-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new ResultDto<T_Log>
            {
                ResultCode = 200,
                ResultData = list
            };
        }
    }
}
