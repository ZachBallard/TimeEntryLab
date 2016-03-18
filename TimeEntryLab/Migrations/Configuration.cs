using System.Collections.Generic;

namespace TimeEntryLab.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeEntryLab.TimeEntryDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TimeEntryLab.TimeEntryDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Seed Tree plan
            //Create 5 developers
            //
            var zach = new Developer()
            {
                Email = "zach@test.com",
                Name = "Zach Ballard",
                StartDate = new DateTime(2015, 3, 1),
            };

            context.Developers.AddOrUpdate(
                d => d.Name,
                zach,
                new Developer() { Email = "different@test.com", Name = "Daniel Pollock", StartDate = new DateTime(2015, 1, 1) }
                );

        }
    }
}
