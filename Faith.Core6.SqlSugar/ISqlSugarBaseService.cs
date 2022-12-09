using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar
{
    public interface ISqlSugarBaseService<T> where T : class
    {
        Task<List<T>> GetList(Expression<Func<T, bool>> query);
    }
}
