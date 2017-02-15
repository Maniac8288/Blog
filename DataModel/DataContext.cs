using DataModel;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    public class DataContext:DbContext
    { 
        public DataContext() 
        : base("DefaultConnection")
    { }

        
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                Property(p => p.LastVisit)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<User>().
                  Property(p => p.Datebirth)
                  .HasColumnType("datetime2")
                  .HasPrecision(0)
                  .IsRequired();
        }
  

    }
}
