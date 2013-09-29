using BloggingSystem.Models;
using System.Data.Entity;

namespace BloggingSystem.Data
{
    public class BloggingSystemContext : DbContext
    {
        public BloggingSystemContext()
            : base("bloggingSystem")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.AuthCode).IsFixedLength().HasMaxLength(40);
            base.OnModelCreating(modelBuilder);
        }
    }
}
