using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;
using OnlineDatingSystem.Data;
using OnlineDatingSystem.Models;

namespace OnlineDatingSystem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
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
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role { Name = "Administrator" },
                new Role { Name = "Registered user" }
                );

            context.Reasons.AddOrUpdate(
                r => r.Name,
                new Reason { Name = "Friendship" },
                new Reason { Name = "Marriage" },
                new Reason { Name = "One-night sex" },
                new Reason { Name = "Serious relationship" },
                new Reason { Name = "Correspondence" }
                );

            context.Interests.AddOrUpdate(
                i => i.Name,
                new Interest { Name = "Sport" },
                new Interest { Name = "Travelling" },
                new Interest { Name = "Reading" },
                new Interest { Name = "Music" },
                new Interest { Name = "Computers" },
                new Interest { Name = "Shopping" },
                new Interest { Name = "Cinema" },
                new Interest { Name = "History" }
                );

            context.EducationTypes.AddOrUpdate(
                e => e.Name,
                new EducationType { Name = "High school" },
                new EducationType { Name = "University" }
                );

            context.Countries.AddOrUpdate(
                c => c.Name,
                new Country { Name = "Bulgaria" },
                new Country { Name = "USA" },
                new Country { Name = "Canada" },
                new Country { Name = "UK" }
                );

            context.SaveChanges();
           
            context.Cities.AddOrUpdate(
                c => c.Name,
                new City { Name = "Sofia", Country = context.Countries.FirstOrDefault(c => c.Name == "Bulgaria") },
                new City { Name = "Plovdiv", Country = context.Countries.FirstOrDefault(c => c.Name == "Bulgaria") },
                new City { Name = "Varna", Country = context.Countries.FirstOrDefault(c => c.Name == "Bulgaria") },
                new City { Name = "Bourgas", Country = context.Countries.FirstOrDefault(c => c.Name == "Bulgaria") },
                
                new City { Name = "New York", Country = context.Countries.FirstOrDefault(c => c.Name == "USA") },
                new City { Name = "San Francisco", Country = context.Countries.FirstOrDefault(c => c.Name == "USA") },
                new City { Name = "Los Angeles", Country = context.Countries.FirstOrDefault(c => c.Name == "USA") },
                new City { Name = "Chicago", Country = context.Countries.FirstOrDefault(c => c.Name == "USA") },
                
                new City { Name = "Toronto", Country = context.Countries.FirstOrDefault(c => c.Name == "Canada") },
                new City { Name = "Montreal", Country = context.Countries.FirstOrDefault(c => c.Name == "Canada") },
                new City { Name = "Ottawa", Country = context.Countries.FirstOrDefault(c => c.Name == "Canada") },
                new City { Name = "Vancouver", Country = context.Countries.FirstOrDefault(c => c.Name == "Canada") },
                
                new City { Name = "London", Country = context.Countries.FirstOrDefault(c => c.Name == "UK") },
                new City { Name = "Bristol", Country = context.Countries.FirstOrDefault(c => c.Name == "UK") },
                new City { Name = "Liverpool", Country = context.Countries.FirstOrDefault(c => c.Name == "UK") },
                new City { Name = "Manchester", Country = context.Countries.FirstOrDefault(c => c.Name == "UK") }
                );
        }
    }
}
