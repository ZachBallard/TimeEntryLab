using System.Collections;
using System.Collections.Generic;

namespace TimeEntryLab
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TimeEntryDB : DbContext
    {
        // Your context has been configured to use a 'TimeEntryDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TimeEntryLab.TimeEntryDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TimeEntryDB' 
        // connection string in the application configuration file.
        public TimeEntryDB()
            : base("name=TimeEntryDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Developer> MyEntities { get; set; }
    }
    
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
 
        public virtual ICollection<Project> Projects { get; set; }
        public virtual Industry Industry { get; set; }
    }

    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int HoursWorked { get; set; }

        public virtual ICollection<Task> SubTasks { get; set; }
        public virtual Developer Developer { get; set; }
        public virtual Project Project { get; set; }
        public virtual Task ParentTask { get; set; }
    }
}