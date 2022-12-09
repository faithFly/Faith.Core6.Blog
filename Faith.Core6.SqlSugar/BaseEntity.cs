using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar
{
    public class BaseEntity
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public string Id { get; set; }
    }
}
