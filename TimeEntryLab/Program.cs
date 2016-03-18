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
                    NavigationBar.HandleSelection();
                }

                //Client view (should be able to see all clients, see lists of each involvement)
                if (NavigationBar.ViewLevel == 1)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    NavigationBar.HandleSelection();
                }

                //Projects view (should be able to see all projects, see lists of each involvement)
                if (NavigationBar.ViewLevel == 2)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    NavigationBar.HandleSelection();
                }

                //Industry view (should be able to see all industries, see lists of each involvement
                if (NavigationBar.ViewLevel == 3)
                {
                    DrawLevel();
                    NavigationBar.DecideNavigation();
                    NavigationBar.HandleSelection();
                }
                //Hours Worked Report
                if (NavigationBar.ViewLevel == 4)
                {
                    DrawLevel();
                    Console.WriteLine(">Type anything to continue<");
                    Console.ReadLine();
                    NavigationBar.ViewLevel = 2;
                }
                if (NavigationBar.ViewLevel == 5)
                {
                    exit = true;
                }
            }
        }

        public static void DrawLevel()
        {
            throw new NotImplementedException();
        }

        public static void Welcome()
        {
            throw new NotImplementedException();
        }
    }
}
