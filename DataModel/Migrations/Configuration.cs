namespace DataModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.DataContext context)
        {
            var admin = new User { UserName = "Max", Password = "123456" };
            var user = new User { UserName = "Petr", Password = "123456" };
            context.Users.AddOrUpdate(
              p => p.Id,
              admin,
              user,
              new User { UserName = "Vladimir", Password = "123456" }
            );

            context.Roles.AddOrUpdate(p => p.Id,
                new Role { Id = TypeRoles.Admin, Name = "Admin", Users = new List<User> { admin } },
                new Role { Id = TypeRoles.User, Name = "User", Users = new List<User> { user } },
                  new Role { Id = TypeRoles.Admin, Name = "Admin", Users = new List<User> { new User { UserName = "Rowan Miller", Password = "123456" } } }
                );
        }
    }
}
