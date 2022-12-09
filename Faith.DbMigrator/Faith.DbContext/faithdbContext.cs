using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faith.EntityModel.Entity;

namespace Faith.DbMigrator.Faith.Dbcontext
{
    public partial class faithdbContext : DbContext
    {
        public faithdbContext() { }
       
        public faithdbContext(DbContextOptions<faithdbContext> options)
          : base(options)
        {
        }
        public virtual DbSet<T_Users> T_Users { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<T_Log> T_Logs { get; set; }
        public virtual DbSet<T_Article> T_Articles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=120.79.81.249;Port=3306;Database=faithdb;Uid=root;Pwd=Xyf12138...;pooling=true;",
                    ServerVersion.Parse("5.7-mysql")
                    );
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
