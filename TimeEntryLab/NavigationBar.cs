using System;
using System.Collections.Generic;

namespace TimeEntryLab
{
    public class NavigationBar
    {
        public int ViewLevel { get; set; }
        public int Selection { get; set; }

        public List<string> ViewHeaders { get; set; } = new List<string>();
        public List<string> UserOptions { get; set; } = new List<string>();

        public NavigationBar()
        {
            ViewLevel = 0;
            Selection = 0;

            ViewHeaders.Add("==== Developer Level ==============================");
            ViewHeaders.Add("==== Client Level =================================");
            ViewHeaders.Add("==== Project Level ================================");
            ViewHeaders.Add("==== Industry Level ===============================");
            ViewHeaders.Add("==== Hours Worked Report ==========================");

            UserOptions.Add("(l)ist of a developer's tasks, view (n)otes from a developer, (c)hange levels, (e)xit");
            UserOptions.Add("(l)ist of projects for client, view (n)otes about a client, (c)hange levels, (e)xit");
            
            UserOptions.Add("(l)ist all tasks for a project, view (n)otes about a project, (a)ll hours worked report, (c)hange levels, (e)xit");
            UserOptions.Add("(l)ist of clients in an industry, view (n)otes about a industry, (c)hange levels, (e)xit");
        }

        internal void DecideNavigation()
        {
            bool isValid = false;

            while (!isValid)
            {
                
                Console.WriteLine(this.ViewHeaders[this.ViewLevel]);
                Console.WriteLine(this.UserOptions[this.ViewLevel]);

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "l":
                        this.Selection = 1;
                        isValid = true;
                        break;
                    case "n":
                        this.Selection = 2;
                        isValid = true;
                        break;
                    case "c":
                        this.Selection = 3;
                        isValid = true;
                        break;
                    case "a":
                        if (this.ViewLevel == 2)
                        {
                            this.Selection = 4;
                            isValid = true;
                            break;
                        }
                        continue;
                    case "e":
                        this.ViewLevel = 5;
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid Selection!\n");
                        break;
                }
            }
        }
    }
}