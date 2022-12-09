using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.EntityModel.Entity
{
    [Table("db_user")]
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public DateTime Birthday { get; set; }
        public string UserPhone { get; set; }
        public int Sex { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateBy { get; set; }
        public int IsDel { get; set; }
    }
}
