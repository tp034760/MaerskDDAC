namespace Maersk_DDAC.Migrations
{
    using Maersk_DDAC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Maersk_DDAC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Maersk_DDAC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Ships.AddOrUpdate(
                 new Ship
                 {
                     ShipID = 1,
                     ShipName = "Titanic",
                     ShipBay = 100
                 }
                 );

            context.SaveChanges();

        }
    }
}
