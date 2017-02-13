﻿using DataModel;
using DataModel.Models;
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
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<User>().HasKey(_ => _.Id);
        //    modelBuilder.Entity<User>().HasMany(t => t.Roles)
        //                              .WithMany(t => t.Users)
        //                                .Map(m =>
        //                                {
        //                                    m.ToTable("CourseInstructor");
        //                                    m.MapLeftKey("CourseID");
        //                                    m.MapRightKey("InstructorID");
        //                                });
           
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
