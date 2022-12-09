using Faith.Application.Contracts.Application.IService;
using Faith.Core6.SqlSugar.Repsoitory;
using Faith.DbMigrator.Faith.Dbcontext;
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service
{
    public class UserService : IUserService
    {
        private readonly ISqlSugarClient _client;

        public UserService(ISqlSugarClient client)
        {
            _client = client;
        }

        public async Task<List<T_Users>> GetUsersAsync()
        {
            try
            {
                return await _client.Queryable<T_Users>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async ValueTask<bool> InsertUserAsync() {
            T_Users users = new T_Users();
            users.UserName = "acid";
            users.UserPassWord = "xu3.1415926";
            users.UserTag = "gg boy!";
            return await _client.Insertable(users).ExecuteCommandAsync() > 0 ? true : false;
        }

    }
}
