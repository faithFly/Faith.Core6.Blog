using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar.Repsoitory
{
    [SugarTable("T_Categorize")]
    public class T_CategorizeSugar
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }
        public string CategorizeName { get; set; }
        public string ParentId { get; set; }
        public int Level { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string CreateBy { get; set; }
        public int IsDel { get; set; }
    }
}
