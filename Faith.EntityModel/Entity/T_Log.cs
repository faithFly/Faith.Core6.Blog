using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.EntityModel.Entity
{
    [Table("T_Logs")]
    public class T_Log
    {
        [Key]
        public string Id { get; set; }
        public string LogMessage { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
    }
}
