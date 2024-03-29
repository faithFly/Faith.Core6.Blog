﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faith.EntityModel.Entity;
using Microsoft.Extensions.Logging;

namespace Faith.DbMigrator.Faith.Dbcontext
{
    public partial class faithdbContext : DbContext
    {
        private static ILoggerFactory logger = LoggerFactory.Create(builer => builer.AddConsole());
        public faithdbContext() { }
       
        public faithdbContext(DbContextOptions<faithdbContext> options)
          : base(options)
        {
        }
        public virtual DbSet<T_Users> T_Users { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<T_Log> T_Logs { get; set; }
        public virtual DbSet<T_Article> T_Articles { get; set; }
        public virtual DbSet<T_Categorize> T_Categorize { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=120.79.81.249;port=3306;database=faithdb;uid=root;pwd=Xyf12138.", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql")); optionsBuilder.UseMySql("Server=120.79.81.249;Port=3306;Database=faithdb;Uid=root;Pwd=Xyf12138.;pooling=true;",
                    ServerVersion.Parse("8.0.27-mysql")
                    );
                optionsBuilder.UseLoggerFactory(logger);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
