namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
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

            context.Courses.AddOrUpdate(
                new Course { Name = "C#", Description = "Learn basic part of programming", Materials = "Introduction to C# " },
                new Course { Name = "JavaScript", Description = "Learn basic part of JavaScript", Materials = "JavaScript for Dummies" },
                new Course { Name = "C# 2", Description = "Learn advanced part of programming", Materials = "Introduction to C#" }
                );

            context.Homeworks.AddOrUpdate(
                new Homework { Content = "Entity Framework Code First" },
                new Homework { Content = "Entity Framework" },
                new Homework { Content = "Transact-SQL" }
                );
        }
    }
}
