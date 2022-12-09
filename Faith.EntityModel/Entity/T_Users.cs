using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.EntityModel.Entity
{
    [Table("T_Users")]
    public class T_Users
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string UserPassWord { get; set; }
        public string UserTag { get; set; }
    }
}
