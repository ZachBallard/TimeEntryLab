using System.Collections.Generic;

namespace TimeEntryLab
{
    class NavigationBar
    {
        public int ViewLevel { get; set; }
        public int Selection { get; set; }

        public List<string> ViewHeaders { get; set; }
        public List<string> UserOptions { get; set; }

        public NavigationBar()
        {
            ViewLevel = 0;
            Selection = 0;

            ViewHeaders.Add("==== Developer Level ==============================");
            ViewHeaders.Add("==== Client Level =================================");
            ViewHeaders.Add("==== Project Level ================================");
            ViewHeaders.Add("==== Hours Worked Report ==========================");

            UserOptions.Add("(a)dd developer, (r)emove developer, list of a developer's (t)asks, list of a developer's (n)otes, (c)hange levels, (e)xit");
            UserOptions.Add("(a)dd a client, (r)emove client, list of (p)rojects for client, add a (n)ew project for a client, (n)otes about client, (c)hange levels, (e)xit");
            UserOptions.Add("(r)emove a project, View all (t)asks for a project, (n)otes about a project, (a)ll hours worked report, (h)ours worked on a project, (c)hange levels, (e)xit");
        }
    }
}