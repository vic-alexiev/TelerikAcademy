namespace TicketingSystem.Data.Migrations
{
    using TicketingSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TicketingSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketingSystem.Data.ApplicationDbContext context)
        {
            if (context.Users.Count() > 0)
            {
                return;
            }

            Random randomGenerator = new Random();

            string[] comments = new string[] 
            {
                "Yeah, the same here.",
                "This one hasn't been resolved yet.",
                "I've just happened on it.",
                "When will this be fixed.",
                "Nobody has answered this yet.",
                "Currently fixed. Download the new release."
            };

            var administrator = new Role { Name = "Administrator" };
            var registered = new Role { Name = "Registered" };

            context.Roles.AddOrUpdate(
                r => r.Name,
                administrator,
                registered
                );

            var nancy = new ApplicationUser() { UserName = "nancy" };
            var andrew = new ApplicationUser() { UserName = "andrew" };
            var janet = new ApplicationUser() { UserName = "janet" };
            var steven = new ApplicationUser() { UserName = "steven" };

            var identityManager = new AuthenticationIdentityManager(new IdentityStore(context));

            identityManager.Users.CreateLocalUser(nancy, "123456");
            identityManager.Users.CreateLocalUser(andrew, "123456");
            identityManager.Users.CreateLocalUser(janet, "123456");
            identityManager.Users.CreateLocalUser(steven, "123456");

            context.SaveChanges();

            context.UserRoles.Add(new UserRole { RoleId = administrator.Id, UserId = nancy.Id });
            context.UserRoles.Add(new UserRole { RoleId = registered.Id, UserId = nancy.Id });
            context.UserRoles.Add(new UserRole { RoleId = registered.Id, UserId = janet.Id });
            context.UserRoles.Add(new UserRole { RoleId = registered.Id, UserId = andrew.Id });

            context.Categories.AddOrUpdate(
                p => p.Name,
                new Category() { Name = "Accounting System" },
                new Category() { Name = "Administrative Module" },
                new Category() { Name = "Dev Tools" },
                new Category() { Name = "Company Web Site" },
                new Category() { Name = "Kendo" },
                new Category() { Name = "Installers" },
                new Category() { Name = "UI Framework" }
                );

            context.SaveChanges();

            var users = context.Users.ToList();
            var categories = context.Categories.ToList();

            context.Tickets.AddOrUpdate(
                t => t.Title,
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[0], Description = "Login form does not open.", Category = categories[0], Priority = Priority.Low, Title = "Login form does not open." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[1], Description = "Cannot update accounts table.", Category = categories[1], Priority = Priority.Low, Title = "Cannot update accounts table." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[2], Description = "Missing currency field.", Category = categories[2], Priority = Priority.Low, Title = "Missing currency field." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[3], Description = "Grid does not sort in descending order.", Category = categories[3], Priority = Priority.High, Title = "Grid does not sort in descending order." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[0], Description = "Installer for the accounting system crashes.", Category = categories[4], Priority = Priority.High, Title = "Installer for the accounting system crashes." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[1], Description = "File upload does not work.", Category = categories[5], Priority = Priority.Medium, Title = "File upload does not work." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[2], Description = "Label for user name is missing.", Category = categories[1], Priority = Priority.Low, Title = "Label for user name is missing." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[3], Description = "Cannot update events table.", Category = categories[2], Priority = Priority.Medium, Title = "Cannot update events table." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[0], Description = "Grid cannot be sorted.", Category = categories[3], Priority = Priority.Low, Title = "Grid cannot be sorted." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[1], Description = "Dropdown countries doesn't get filled.", Category = categories[4], Priority = Priority.High, Title = "Dropdown countries doesn't get filled." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[2], Description = "User admin doesn't have sufficient permissions.", Category = categories[5], Priority = Priority.Medium, Title = "User admin doesn't have sufficient permissions." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[3], Description = "When project is clicked, details don't load.", Category = categories[6], Priority = Priority.Medium, Title = "When project is clicked, details don't load." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[0], Description = "Registration form does not open.", Category = categories[6], Priority = Priority.Low, Title = "Registration form does not open." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[1], Description = "Cannot update orders table.", Category = categories[2], Priority = Priority.Low, Title = "Cannot update orders table." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[2], Description = "Missing total field.", Category = categories[3], Priority = Priority.Low, Title = "Missing total field." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[3], Description = "Grid missing sort icon.", Category = categories[2], Priority = Priority.High, Title = "Grid missing sort icon." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[0], Description = "Installer crashes.", Category = categories[1], Priority = Priority.High, Title = "Installer crashes." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[1], Description = "File upload crashes for more than one file.", Category = categories[4], Priority = Priority.High, Title = "File upload crashes for more than one file." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[2], Description = "Label for user title is missing.", Category = categories[3], Priority = Priority.Low, Title = "Label for user title is missing." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[3], Description = "Cannot update employees table.", Category = categories[2], Priority = Priority.High, Title = "Cannot update employees table." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[0], Description = "List view doesn't sort after page refreshes.", Category = categories[0], Priority = Priority.Low, Title = "List view doesn't sort after page refreshes." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[1], Description = "Dropdown cities doesn't get filled.", Category = categories[0], Priority = Priority.High, Title = "Dropdown cities doesn't get filled." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[2], Description = "User manager doesn't have sufficient permissions.", Category = categories[4], Priority = Priority.Medium, Title = "User manager doesn't have sufficient permissions." },
                new Ticket() { ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif", Author = users[3], Description = "When project is opened, details button doesn't show.", Category = categories[6], Priority = Priority.Medium, Title = "When project is opened, details button doesn't show." }
                );

            context.SaveChanges();

            var tickets = context.Tickets.ToList();

            foreach (var ticket in tickets)
            {
                int commentsCount = randomGenerator.Next(15);
                for (int i = 0; i < commentsCount; i++)
                {
                    var comment = new Comment { Ticket = ticket, Author = users[randomGenerator.Next(4)], Content = comments[randomGenerator.Next(6)] };
                    context.Comments.Add(comment);
                }
            }

            context.SaveChanges();
        }
    }
}
