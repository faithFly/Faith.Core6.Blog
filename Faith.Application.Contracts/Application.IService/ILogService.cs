using Faith.Application.Contracts.Application.Dto;
using Faith.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService
{
    public interface ILogService
    {
        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        Task<ResultDto<T_Log>> GetLogListAsync(int pageSize,int pageIndex);
    }
}
