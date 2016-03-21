using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeEntryLab
{
    class Program
    {
        private static NavigationBar NavigationBar = new NavigationBar();

        static void Main(string[] args)
        {
            bool exit = false;

            Welcome();

            while (!exit)
            {
                //Developer view (should be able to see all developers, see lists of each involvement) 
                if (NavigationBar.ViewLevel == 0)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    HandleDeveloperLevel();
                }

                //Client view (should be able to see all clients, see lists of each involvement)
                if (NavigationBar.ViewLevel == 1)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    HandleClientLevel();

                }

                //Projects view (should be able to see all projects, see lists of each involvement)
                if (NavigationBar.ViewLevel == 2)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    HandleProjectLevel();

                }

                //Industry view (should be able to see all industries, see lists of each involvement
                if (NavigationBar.ViewLevel == 3)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    HandleIndustryLevel();

                }
                //Hours Worked Report
                if (NavigationBar.ViewLevel == 4)
                {
                    DrawLevel();
                    Console.ReadLine();
                    NavigationBar.ViewLevel = 2;
                }
                if (NavigationBar.ViewLevel == 5)
                {
                    exit = true;
                }
            }
        }

        private static void HandleIndustryLevel()
        {
            Console.Clear();
            switch (NavigationBar.Selection)
            {
                case 1:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Industries;

                        foreach (var p in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{p.Id}: {p.Name}");

                            foreach (var t in p.Clients)
                            {
                                Console.WriteLine($"  -{t.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Industries;

                        foreach (var p in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{p.Id}: {p.Name}");

                            foreach (var n in p.IndustryNotes)
                            {
                                Console.WriteLine($"  -{n.Note}, by: {n.Developer.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    ChangeViewLevel();
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
            NavigationBar.Selection = 0;
        }

        private static void HandleProjectLevel()
        {
            Console.Clear();
            switch (NavigationBar.Selection)
            {
                case 1:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Projects;

                        foreach (var p in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{p.Id}: {p.Name}, {p.Client.Name}, {p.StartDate}");

                            foreach (var t in p.Tasks)
                            {
                                Console.WriteLine($"  -{t.Name}\n    start date: {t.StartDate}, Hours worked: {t.HoursWorked}, Developer: {t.Developer.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Projects;

                        foreach (var p in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{p.Id}: {p.Name}, {p.Client.Name}, {p.StartDate}");

                            foreach (var n in p.ProjectNotes)
                            {
                                Console.WriteLine($"  -{n.Note}, by: {n.Developer.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    ChangeViewLevel();
                    break;
                case 4:
                    NavigationBar.ViewLevel = 4;
                    break;
                case 5:
                    break;
            }
            NavigationBar.Selection = 0;
        }

        private static void HandleClientLevel()
        {
            Console.Clear();
            switch (NavigationBar.Selection)
            {
                case 1:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Clients;

                        foreach (var c in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{c.Id}: {c.Name}");

                            foreach (var p in c.Projects)
                            {
                                Console.WriteLine($"  -{p.Name}\n    start date: {p.StartDate}, project: {p.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Clients;

                        foreach (var c in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{c.Id}: {c.Name}");

                            foreach (var n in c.ClientNotes)
                            {
                                Console.WriteLine($"  -{n.Note}, by {n.Developer.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    ChangeViewLevel();
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
            NavigationBar.Selection = 0;
        }

        private static void HandleDeveloperLevel()
        {
            Console.Clear();
            switch (NavigationBar.Selection)
            {
                case 1:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Developers;

                        foreach (var d in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{d.Id}: {d.Name}, {d.Email}, {d.StartDate.Date}");

                            foreach (var t in d.Tasks)
                            {
                                Console.WriteLine($"  -{t.Name}\n    start date: {t.StartDate}, project: {t.Project.Name}, client: {t.Project.Client.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Developers;

                        foreach (var d in query)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{d.Id}: {d.Name}, {d.Email}, {d.StartDate.Date}");

                            foreach (var n in d.ClientNotes)
                            {
                                Console.WriteLine($"  -Client Note:\n   {n.Note}, {n.Client.Name}");
                            }
                            foreach (var n in d.ProjectNotes)
                            {
                                Console.WriteLine($"  -Project Note:\n   {n.Note}, {n.Project.Name}");
                            }
                            foreach (var n in d.IndustryNotes)
                            {
                                Console.WriteLine($"  -Industry Note:\n   {n.Note}, {n.Industry.Name}");
                            }
                        }
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    ChangeViewLevel();
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
            NavigationBar.Selection = 0;
        }

        private static void ChangeViewLevel()
        { 
            Console.Clear();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Change to: (d)evelopers, (c)lients, (p)rojects, (i)ndustries");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "d":
                        NavigationBar.ViewLevel = 0;
                        isValid = true;
                        break;
                    case "c":
                        NavigationBar.ViewLevel = 1;
                        isValid = true;
                        break;
                    case "p":
                        NavigationBar.ViewLevel = 2;
                        isValid = true;
                        break;
                    case "i":
                        NavigationBar.ViewLevel = 3;
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public static void DrawLevel()
        {
            Console.Clear();
            switch (NavigationBar.ViewLevel)
            {
                case 0:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Developers;

                        foreach (var d in query)
                        {
                            Console.WriteLine($"{d.Id}: {d.Name}, {d.Email}, {d.StartDate.Date}");
                        }
                    }
                    break;
                case 1:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Clients;

                        foreach (var c in query)
                        {
                            Console.WriteLine($"{c.Id}: {c.Name}");
                        }
                    }
                    break;
                case 2:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Projects;

                        foreach (var p in query)
                        {
                            Console.WriteLine($"{p.Id}: {p.Name}, {p.Client.Name}, {p.StartDate}");
                        }
                    }
                    break;
                case 3:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Industries;

                        foreach (var i in query)
                        {
                            Console.WriteLine($"{i.Id}: {i.Name}");
                        }
                    }
                    break;
                case 4:
                    using (TimeEntryDB context = new TimeEntryDB())
                    {
                        var query = context.Projects;

                        foreach (var p in query)
                        {
                            int total = 0;

                            foreach (var t in p.Tasks)
                            {
                                total += t.HoursWorked;
                            }
                            Console.WriteLine($"{p.Id}: {p.Name}, {p.Client.Name}, {p.StartDate}\n    Hours Worked: {total}");
                        }
                    }
                    break;
            }
        }

        public static void Welcome()
        {
            Console.WriteLine("Welcome to the Time Entry Lab Demo! >Type anything to continue<");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
