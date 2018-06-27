using BasiliskBugTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.WebClient.Tests.Controllers
{
    public static class DataHelper
    {
        public static Project[] GetProjectData()
        {
            var administrator = new Role { Id = "1", Name = "Administrator" };
            var projectManager = new Role { Id = "2", Name = "ProjectManager" };
            var developer = new Role { Id = "3", Name = "Developer" };

            var nancy = new ApplicationUser() { Id = "1", UserName = "nancy", Email = "davolio@gmail.com", Phone = "2065559857", Name = "Nancy Davolio", IsDeleted = false };
            var andrew = new ApplicationUser() { Id = "2", UserName = "andrew", Email = "andrew.fuller@yahoo.com", Phone = "2065559482", Name = "Andrew Fuller", IsDeleted = false };
            var janet = new ApplicationUser() { Id = "3", UserName = "janet", Email = "jleverling@yahoo.co.uk", Phone = "2065553412", Name = "Janet Leverling", IsDeleted = false };
            var steven = new ApplicationUser() { Id = "4", UserName = "steven", Email = "stbuchanan@microsoft.com", Phone = "715554848", Name = "Steven Buchanan", IsDeleted = false };
            var users = new ApplicationUser[] { nancy, andrew, janet, steven };

            var userRole1 = new UserRole { Role = administrator, RoleId = administrator.Id, User = nancy, UserId = nancy.Id };
            var userRole2 = new UserRole { Role = projectManager, RoleId = projectManager.Id, User = nancy, UserId = nancy.Id };
            var userRole3 = new UserRole { Role = projectManager, RoleId = projectManager.Id, User = janet, UserId = janet.Id };
            var userRole4 = new UserRole { Role = projectManager, RoleId = projectManager.Id, User = andrew, UserId = andrew.Id };
            var userRole5 = new UserRole { Role = developer, RoleId = developer.Id, User = steven, UserId = steven.Id };
            var userRole6 = new UserRole { Role = developer, RoleId = developer.Id, User = nancy, UserId = nancy.Id };
            var userRole7 = new UserRole { Role = developer, RoleId = developer.Id, User = andrew, UserId = andrew.Id };

            nancy.Roles = new List<UserRole>() { userRole1, userRole2, userRole6 };
            andrew.Roles = new List<UserRole>() { userRole4, userRole7 };
            janet.Roles = new List<UserRole>() { userRole3 };
            steven.Roles = new List<UserRole>() { userRole5 };

            var project1 = new Project() { Name = "Accounting System", Description = "Accounting System Description", Manager = nancy, Id = 1, IsDeleted = false };
            var project2 = new Project() { Name = "Administrative Module", Description = "Administrative Module Description", Manager = nancy, Id = 2, IsDeleted = false };
            var project3 = new Project() { Name = "Dev Tools", Description = "Dev Tools Description", Manager = nancy, Id = 3, IsDeleted = false };
            var project4 = new Project() { Name = "Company Web Site", Description = "Company Web Site Description", Manager = andrew, Id = 4, IsDeleted = false };
            var project5 = new Project() { Name = "Kendo", Description = "Kendo Description", Manager = janet, Id = 5, IsDeleted = false };
            var project6 = new Project() { Name = "Installers", Description = "Installers Description", Manager = andrew, Id = 6, IsDeleted = false };
            var project7 = new Project() { Name = "UI Framework", Description = "UI Framework Description", Manager = andrew, Id = 7, IsDeleted = false };
            var projects = new Project[] { project1, project2, project3, project4, project5, project6, project7 };

            project1.Contributors.Add(nancy);
            project1.Contributors.Add(andrew);
            project1.Contributors.Add(janet);

            project2.Contributors.Add(steven);
            project2.Contributors.Add(janet);
            project2.Contributors.Add(andrew);

            var bug1 = new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." };
            var bug2 = new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." };
            var bug3 = new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." };

            project1.Bugs.Add(bug1);
            project2.Bugs.Add(bug2);
            project3.Bugs.Add(bug3);
            project4.Bugs.Add(bug1);
            project5.Bugs.Add(bug2);
            project6.Bugs.Add(bug3);
            project7.Bugs.Add(bug1);

            return projects;
        }

        public static List<Bug> GetBugData()
        {
            var nancy = new ApplicationUser() { UserName = "nancy", Email = "davolio@gmail.com", Phone = "2065559857", Name = "Nancy Davolio", IsDeleted = false };
            var andrew = new ApplicationUser() { UserName = "andrew", Email = "andrew.fuller@yahoo.com", Phone = "2065559482", Name = "Andrew Fuller", IsDeleted = false };
            var janet = new ApplicationUser() { UserName = "janet", Email = "jleverling@yahoo.co.uk", Phone = "2065553412", Name = "Janet Leverling", IsDeleted = false };
            var steven = new ApplicationUser() { UserName = "steven", Email = "stbuchanan@microsoft.com", Phone = "715554848", Name = "Steven Buchanan", IsDeleted = false };
            var users = new ApplicationUser[] { nancy, andrew, janet, steven };


            var project1 = new Project() { Name = "Accounting System", Description = "Accounting System Description", Manager = nancy };
            var project2 = new Project() { Name = "Administrative Module", Description = "Administrative Module Description", Manager = nancy };
            var project3 = new Project() { Name = "Dev Tools", Description = "Dev Tools Description", Manager = nancy };
            var project4 = new Project() { Name = "Company Web Site", Description = "Company Web Site Description", Manager = andrew };
            var project5 = new Project() { Name = "Kendo", Description = "Kendo Description", Manager = janet };
            var project6 = new Project() { Name = "Installers", Description = "Installers Description", Manager = andrew };
            var project7 = new Project() { Name = "UI Framework", Description = "UI Framework Description", Manager = andrew };
            var projects = new Project[] { project1, project2, project3, project4, project5, project6, project7 };

            var bug1 = new Bug() { AssignedTo = users[0], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Project = projects[0], Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." };
            var bug2 = new Bug() { AssignedTo = users[1], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Project = projects[2], Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." };
            var bug3 = new Bug() { AssignedTo = users[2], DateDiscovered = DateTime.Now, Description = "Login form does not open.", Project = projects[0], Owner = users[1], Priority = Priority.Low, Status = Status.New, Title = "Login form does not open." };
            var bugsList = new List<Bug>();

            bugsList.Add(bug1);
            bugsList.Add(bug2);
            bugsList.Add(bug3);

            return bugsList;
        }
    }
}
