namespace BasiliskBugTracker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BasiliskBugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public sealed class Configuration : DbMigrationsConfiguration<BasiliskBugTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BasiliskBugTracker.Data.ApplicationDbContext context)
        {
            if (context.Users.Count() > 0)
            {
                return;
            }

            var administrator = new Role { Name = "Administrator" };
            var projectManager = new Role { Name = "ProjectManager" };
            var developer = new Role { Name = "Developer" };

            context.Roles.AddOrUpdate(
                r => r.Name,
                administrator,
                projectManager,
                developer
                );

            var nancy = new ApplicationUser() { UserName = "nancy", Email = "davolio@gmail.com", Phone = "2065559857", Name = "Nancy Davolio", IsDeleted = false };
            var andrew = new ApplicationUser() { UserName = "andrew", Email = "andrew.fuller@yahoo.com", Phone = "2065559482", Name = "Andrew Fuller", IsDeleted = false };
            var janet = new ApplicationUser() { UserName = "janet", Email = "jleverling@yahoo.co.uk", Phone = "2065553412", Name = "Janet Leverling", IsDeleted = false };
            var steven = new ApplicationUser() { UserName = "steven", Email = "stbuchanan@microsoft.com", Phone = "715554848", Name = "Steven Buchanan", IsDeleted = false };

            var identityManager = new AuthenticationIdentityManager(new IdentityStore(context));

            identityManager.Users.CreateLocalUser(nancy, "123456");
            identityManager.Users.CreateLocalUser(andrew, "123456");
            identityManager.Users.CreateLocalUser(janet, "123456");
            identityManager.Users.CreateLocalUser(steven, "123456");

            context.SaveChanges();

            context.UserRoles.Add(new UserRole { RoleId = administrator.Id, UserId = nancy.Id });
            context.UserRoles.Add(new UserRole { RoleId = projectManager.Id, UserId = nancy.Id });
            context.UserRoles.Add(new UserRole { RoleId = projectManager.Id, UserId = janet.Id });
            context.UserRoles.Add(new UserRole { RoleId = projectManager.Id, UserId = andrew.Id });

            context.Projects.AddOrUpdate(
                p => p.Name,
                new Project() { Name = "Accounting System", Description = "Accounting System Description", Manager = nancy },
                new Project() { Name = "Administrative Module", Description = "Administrative Module Description", Manager = nancy },
                new Project() { Name = "Dev Tools", Description = "Dev Tools Description", Manager = nancy },
                new Project() { Name = "Company Web Site", Description = "Company Web Site Description", Manager = andrew },
                new Project() { Name = "Kendo", Description = "Kendo Description", Manager = janet },
                new Project() { Name = "Installers", Description = "Installers Description", Manager = andrew },
                new Project() { Name = "UI Framework", Description = "UI Framework Description", Manager = andrew }
                );

            context.SaveChanges();

            var projects = context.Projects.ToList();
            var users = context.Users.ToList();

            nancy.ProjectsContributingTo.Add(projects[0]);
            nancy.ProjectsContributingTo.Add(projects[1]);
            nancy.ProjectsContributingTo.Add(projects[2]);

            andrew.ProjectsContributingTo.Add(projects[3]);
            andrew.ProjectsContributingTo.Add(projects[4]);
            andrew.ProjectsContributingTo.Add(projects[5]);
            andrew.ProjectsContributingTo.Add(projects[6]);

            steven.ProjectsContributingTo.Add(projects[0]);
            steven.ProjectsContributingTo.Add(projects[1]);
            steven.ProjectsContributingTo.Add(projects[2]);
            steven.ProjectsContributingTo.Add(projects[3]);
            steven.ProjectsContributingTo.Add(projects[4]);
            steven.ProjectsContributingTo.Add(projects[5]);

            janet.ProjectsContributingTo.Add(projects[0]);
            janet.ProjectsContributingTo.Add(projects[1]);
            janet.ProjectsContributingTo.Add(projects[2]);
            janet.ProjectsContributingTo.Add(projects[3]);
            janet.ProjectsContributingTo.Add(projects[4]);
            janet.ProjectsContributingTo.Add(projects[5]);
            janet.ProjectsContributingTo.Add(projects[6]);

            context.SaveChanges();

            context.Bugs.AddOrUpdate(
                p => p.Description,
                new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Project = projects[0], Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." },
                new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "Cannot update accounts table.", Project = projects[1], Owner = users[0], Priority = Priority.Low, Status = Status.Closed, Title = "Cannot update accounts table." },
                new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "Missing currency field.", Project = projects[2], Owner = users[2], Priority = Priority.Low, Status = Status.New, Title = "Missing currency field." },
                new Bug() { AssignedTo = users[3], DateDiscovered = DateTime.Now, Description = "Grid does not sort in descending order.", Project = projects[3], Owner = users[3], Priority = Priority.Critical, Status = Status.Fixed, Title = "Grid does not sort in descending order." },
                new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Installer for the accounting system crashes.", Project = projects[4], Owner = users[3], Priority = Priority.High, Status = Status.InProgress, Title = "Installer for the accounting system crashes." },
                new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "File upload does not work.", Project = projects[5], Owner = users[1], Priority = Priority.Normal, Status = Status.New, Title = "File upload does not work." },
                new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "Label for user name is missing.", Project = projects[1], Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Label for user name is missing." },
                new Bug() { AssignedTo = users[3], DateDiscovered = DateTime.Now, Description = "Cannot update events table.", Project = projects[2], Owner = users[3], Priority = Priority.Critical, Status = Status.Closed, Title = "Cannot update events table." },
                new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Grid cannot be sorted.", Project = projects[3], Owner = users[2], Priority = Priority.Low, Status = Status.New, Title = "Grid cannot be sorted." },
                new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "Dropdown countries doesn't get filled.", Project = projects[4], Owner = users[3], Priority = Priority.Critical, Status = Status.Fixed, Title = "Dropdown countries doesn't get filled." },
                new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "User admin doesn't have sufficient permissions.", Project = projects[5], Owner = users[1], Priority = Priority.Normal, Status = Status.InProgress, Title = "User admin doesn't have sufficient permissions." },
                new Bug() { AssignedTo = users[3], DateDiscovered = DateTime.Now, Description = "When project is clicked, details don't load.", Project = projects[6], Owner = users[2], Priority = Priority.Normal, Status = Status.New, Title = "When project is clicked, details don't load." },
                new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Registration form does not open.", Project = projects[6], Owner = users[0], Priority = Priority.Low, Status = Status.New, Title = "Registration form does not open." },
                new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "Cannot update orders table.", Project = projects[2], Owner = users[3], Priority = Priority.Low, Status = Status.Closed, Title = "Cannot update orders table." },
                new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "Missing total field.", Project = projects[3], Owner = users[2], Priority = Priority.Low, Status = Status.New, Title = "Missing total field." },
                new Bug() { AssignedTo = users[3], DateDiscovered = DateTime.Now, Description = "Grid missing sort icon.", Project = projects[2], Owner = users[1], Priority = Priority.Critical, Status = Status.Fixed, Title = "Grid missing sort icon." },
                new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Installer crashes.", Project = projects[1], Owner = users[0], Priority = Priority.High, Status = Status.InProgress, Title = "Installer crashes." },
                new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "File upload crashes for more than one file.", Project = projects[4], Owner = users[3], Priority = Priority.Normal, Status = Status.New, Title = "File upload crashes for more than one file." },
                new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "Label for user title is missing.", Project = projects[3], Owner = users[2], Priority = Priority.Low, Status = Status.New, Title = "Label for user title is missing." },
                new Bug() { AssignedTo = users[3], DateDiscovered = DateTime.Now, Description = "Cannot update employees table.", Project = projects[2], Owner = users[1], Priority = Priority.Critical, Status = Status.Closed, Title = "Cannot update employees table." },
                new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "List view doesn't sort after page refreshes.", Project = projects[0], Owner = users[0], Priority = Priority.Low, Status = Status.New, Title = "List view doesn't sort after page refreshes." },
                new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "Dropdown cities doesn't get filled.", Project = projects[0], Owner = users[2], Priority = Priority.Critical, Status = Status.Fixed, Title = "Dropdown cities doesn't get filled." },
                new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "User manager doesn't have sufficient permissions.", Project = projects[4], Owner = users[3], Priority = Priority.Normal, Status = Status.InProgress, Title = "User manager doesn't have sufficient permissions." },
                new Bug() { AssignedTo = users[3], DateDiscovered = DateTime.Now, Description = "When project is opened, details button doesn't show.", Project = projects[6], Owner = users[0], Priority = Priority.Normal, Status = Status.New, Title = "When project is opened, details button doesn't show." }
                );
        }
    }
}
