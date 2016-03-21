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

            //Create 5 developers
            var zach = new Developer()
            {
                Email = "zach@test.com",
                Name = "Zach Ballard",
                StartDate = new DateTime(2015, 2, 2),
            };

            var daniel = new Developer()
            {
                Email = "daniel@test.com",
                Name = "Daniel Pollock",
                StartDate = new DateTime(2015, 1, 1),
            };

            var frank = new Developer()
            {
                Email = "stackoffraggle@test.com",
                Name = "Frank Fragglestack",
                StartDate = new DateTime(2015, 3, 3),
            };

            var kitty = new Developer()
            {
                Email = "meowmoew@test.com",
                Name = "Kitty Mcmeow",
                StartDate = new DateTime(2015, 4, 4)
            };

            var richard = new Developer()
            {
                Email = "cashaplenty@test.com",
                Name = "Richard Goldsmith",
                StartDate = new DateTime(2015, 5, 5)
            };

            //Make 3 Industries
            var information = new Industry() { Name = "Information" };
            var perfume = new Industry() { Name = "Perfume" };
            var videoGames = new Industry() { Name = "Video Games" };

            //Make 3 clients
            var smartStuff = new Client() { Name = "Smartstuff Inc.", Industry = information };
            var coolGames = new Client() { Name = "Cool Games", Industry = videoGames };
            var vanitySmell = new Client() { Name = "Vanity Smell", Industry = perfume };

            //make projects for each client
            var website = new Project() { Name = "New Website", Client = smartStuff, StartDate = new DateTime(2015, 6, 6) };
            var videogame = new Project() { Name = "Roguelike", Client = coolGames, StartDate = new DateTime(2015, 7, 7) };
            var website2 = new Project() { Name = "New Website", Client = vanitySmell, StartDate = new DateTime(2015, 8, 8) };

            //two new tasks for each project
            var websitetask = new Task() { Name = "Create main page", HoursWorked = 12, StartDate = new DateTime(2015, 9, 9), Developer = daniel, Project = website };
            var websitetask2 = new Task() { Name = "Create user dashboard", HoursWorked = 24, StartDate = new DateTime(2015, 9, 9), Developer = zach, Project = website };
            var videogametask = new Task() { Name = "Make roguelike", HoursWorked = 34, StartDate = new DateTime(2015, 9, 9), Developer = kitty, Project = videogame };
            var videogametask2 = new Task() { Name = "Map generation", HoursWorked = 46, StartDate = new DateTime(2015, 9, 9), Developer = frank, Project = videogame, ParentTask = videogametask };
            var website2task = new Task() { Name = "Create main page", HoursWorked = 12, StartDate = new DateTime(2015, 9, 9), Developer = daniel, Project = website2 };
            var website2task2 = new Task() { Name = "Product listing", HoursWorked = 10, StartDate = new DateTime(2015, 9, 9), Developer = richard, Project = website2 };

            //create a few notes on client, industry, and a project
            var videogamenote = new ProjectNotes() { Note = "Map generation is hard! @#$%#@", Project = videogame, Developer = frank };
            var vanitysmellnote = new ClientNotes() { Note = "These guys are paying us too much :D", Client = vanitySmell, Developer = richard };
            var informationnote = new IndustryNotes() { Note = "This is a broad industry...", Industry = information, Developer = kitty };

            frank.ProjectNotes.Add(videogamenote);
            richard.ClientNotes.Add(vanitysmellnote);
            kitty.IndustryNotes.Add(informationnote);

            //add needed values to created data
            context.Developers.AddOrUpdate(
                d => d.Name,
                zach,
                daniel,
                frank,
                kitty,
                richard
                );
            context.Clients.AddOrUpdate(
                c => c.Name,
                smartStuff,
                coolGames,
                vanitySmell
                );
            context.Industries.AddOrUpdate(
                i => i.Name,
                information,
                videoGames,
                perfume);
            context.Projects.AddOrUpdate(
                p => p.Name,
                website,
                website2,
                videogame
                );
            context.Tasks.AddOrUpdate(
                t => t.Name,
                website2task,
                website2task,
                website2task2,
                websitetask2,
                videogametask,
                videogametask2
                );
        }
    }
}
