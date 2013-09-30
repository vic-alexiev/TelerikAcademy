using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieStore.Data
{
    public class MovieStoreContext : DbContext
    {
        public MovieStoreContext()
            : base("MovieStore")
        {
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Actress> Actresses { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Studio> Studios { get; set; }
    }
}