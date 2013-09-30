namespace MovieStore.Migrations
{
    using MovieStore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieStore.Data.MovieStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MovieStore.Data.MovieStoreContext context)
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

            context.Studios.AddOrUpdate(
                s => s.Name,
                new Studio { Name = "Castle Rock Entertainment", WebSite = "www.lonestar-movie.com" },
                new Studio { Name = "Paramount Pictures", WebSite = "www.paramount.com" },
                new Studio { Name = "Miramax Films", WebSite = "miramax.com" },
                new Studio { Name = "Warner Bros.", WebSite = "www.warnerbros.com" },
                new Studio { Name = "Twentieth Century Fox Film Corporation", WebSite = "www.foxmovies.com" }
                );

            context.Directors.AddOrUpdate(
                d => d.Name,
                new Director { Name = "Frank Darabont", BirthDate = new DateTime(1959, 1, 28) },
                new Director { Name = "Francis Ford Coppola", BirthDate = new DateTime(1939, 4, 7) },
                new Director { Name = "James Cameron", BirthDate = new DateTime(1954, 8, 16) }
                );

            context.Actors.AddOrUpdate(
                a => a.Name,
                new Actor { Name = "Marlon Brando", BirthDate = new DateTime(1924, 4, 3) },
                new Actor { Name = "Tim Robbins", BirthDate = new DateTime(1958, 10, 16) },
                new Actor { Name = "Leonardo DiCaprio", BirthDate = new DateTime(1974, 11, 11) }
                );

            context.Actresses.AddOrUpdate(
                a => a.Name,
                new Actress { Name = "Diane Keaton", BirthDate = new DateTime(1946, 1, 5) },
                new Actress { Name = "Kate Winslet", BirthDate = new DateTime(1975, 10, 5) }
                );

            context.SaveChanges();

            var castleRockEntertainment = context.Studios.FirstOrDefault(c => c.Name == "Castle Rock Entertainment");
            var paramountPictures = context.Studios.FirstOrDefault(c => c.Name == "Paramount Pictures");
            var twentiethCenturyFoxFilmCorporation = context.Studios.FirstOrDefault(c => c.Name == "Twentieth Century Fox Film Corporation");

            var frankDarabont = context.Directors.FirstOrDefault(c => c.Name == "Frank Darabont");
            var francisFordCoppola = context.Directors.FirstOrDefault(c => c.Name == "Francis Ford Coppola");
            var jamesCameron = context.Directors.FirstOrDefault(c => c.Name == "James Cameron");

            var marlonBrando = context.Actors.FirstOrDefault(c => c.Name == "Marlon Brando");
            var timRobbins = context.Actors.FirstOrDefault(c => c.Name == "Tim Robbins");
            var leonardoDiCaprio = context.Actors.FirstOrDefault(c => c.Name == "Leonardo DiCaprio");

            var dianeKeaton = context.Actresses.FirstOrDefault(c => c.Name == "Diane Keaton");
            var kateWinslet = context.Actresses.FirstOrDefault(c => c.Name == "Kate Winslet");

            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    Year = 1994,
                    Director = frankDarabont,
                    Actor = timRobbins,
                    Studio = castleRockEntertainment
                },
                new Movie
                {
                    Title = "Titanic",
                    Year = 1997,
                    Director = jamesCameron,
                    Actor = leonardoDiCaprio,
                    Actress = kateWinslet,
                    Studio = twentiethCenturyFoxFilmCorporation
                },
                new Movie
                {
                    Title = "The Godfather",
                    Year = 1972,
                    Director = francisFordCoppola,
                    Actor = marlonBrando,
                    Actress = dianeKeaton,
                    Studio = paramountPictures
                });
        }
    }
}
