namespace Axure.Migrations
{
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
            context.Users.AddOrUpdate(x => x.Id,
                 new User { Id = 1, UserName = "Admin", Role = "user", Password = "pass", Status = false }
                 );
            context.Users.AddOrUpdate(x => x.Id,
                 new User { Id = 1, UserName = "Admin2", Role = "user", Password = "pass", Status = false }
                 );
        }
    }
}
