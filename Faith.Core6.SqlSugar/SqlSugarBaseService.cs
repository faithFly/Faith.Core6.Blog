using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar
{
    public class SqlSugarBaseService<T> : ISqlSugarBaseService<T> where T : class, new()
    {
        private readonly ISqlSugarClient _Client;

        public SqlSugarBaseService(ISqlSugarClient sqlSugarClient)
        {
            this._Client = sqlSugarClient;
        }
        public async Task<List<T>> GetList(Expression<Func<T,bool>> query)
        {
            return await _Client.Queryable<T>().Where(query).ToListAsync();
        }

    }
}
