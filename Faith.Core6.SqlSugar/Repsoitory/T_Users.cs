using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar.Repsoitory
{
    [SugarTable("T_Users")]
    public class T_Users
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public string UserTag { get; set; }
    }
}
