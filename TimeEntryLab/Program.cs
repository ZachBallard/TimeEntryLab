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
        static readonly NavigationBar NavigationBar = new NavigationBar();

        static void Main(string[] args)
        {
            bool exit = false;
           
            var allDevelopers = new List<Developer>();

            Welcome();

            while (!exit)
            {
                //Developer view (should be able to see all developers, see lists of each involvement) 
                if (NavigationBar.ViewLevel == 0)
                {
                    drawDevelopers(allDevelopers);
                    DecideNavigation();
                }

                //Client view (should be able to see all clients, see lists of each involvement)
                if (NavigationBar.ViewLevel == 1)
                {
                    drawClients(allDevelopers);
                    DecideNavigation();
                }

                //Projects view (should be able to see all projects, see lists of each involvement)
                if (NavigationBar.ViewLevel == 2)
                {
                    drawProjects(allDevelopers);
                    DecideNavigation();

                }

                //Hours Worked Report (print out a report on all hours in tasks)
                if (NavigationBar.ViewLevel == 3)
                {
                    drawReport(allDevelopers);
                    DecideNavigation();
                }

                if (NavigationBar.ViewLevel == 4)
                {
                    exit = true;
                }
            }
        }

        public static void DecideNavigation()
        {

        }

        public static void drawReport(List<Developer> allDevelopers)
        {
            throw new NotImplementedException();
        }

        public static void drawProjects(List<Developer> allDevelopers)
        {
            throw new NotImplementedException();
        }

        public static void drawClients(List<Developer> allDevelopers)
        {
            throw new NotImplementedException();
        }

        public static void drawDevelopers(List<Developer> allDevelopers)
        {
            throw new NotImplementedException();
        }

        public static void Welcome()
        {
            throw new NotImplementedException();
        }
    }
}
