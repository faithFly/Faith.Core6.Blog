using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Faith.EntityModel.Entity
{
    [Table("db_userLog")]
    public partial class UserLog
    {
        [Key]
        [Required, MaxLength(50)]
        public string Id { get; set; } = null!;
        [Required, MaxLength(500)]
        public string? Arr01 { get; set; }
        [Required, MaxLength(500)]
        public string? Arr02 { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
