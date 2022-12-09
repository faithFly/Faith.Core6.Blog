using Faith.Core6.SqlSugar.Repsoitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService
{
    public interface IUserService
    {
        Task<List<T_Users>> GetUsersAsync();
        ValueTask<bool> InsertUserAsync();
    }
}
