namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    /// <summary>
    /// Class Configuration. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{DataModel.DataContext}" />
    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.DataContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //
        protected override void Seed(DataModel.DataContext context)
        {

            context.Roles.AddOrUpdate(p => p.Id,
                new Role { Id = TypeRoles.Admin, Name = "Admin" },
                new Role { Id = TypeRoles.User, Name = "User" }

                );
        }
    }
}
