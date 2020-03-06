namespace Axure.Migrations
{
    using Axure.Models;
    using Axure.Models.Module_Stock;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Axure.Models.AxureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Axure.Models.AxureContext context)
        {
            /*context.Users.AddOrUpdate(x => x.Id,
                 new User { Id = 1, UserName = "User", Role = "user", Password = "pass", Status = false },
                 new User { Id = 2, UserName = "Admin", Role = "admin", Password = "pass", Status = false }
                 );       */
        }
    }
}
