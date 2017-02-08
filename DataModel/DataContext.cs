using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    }
}
