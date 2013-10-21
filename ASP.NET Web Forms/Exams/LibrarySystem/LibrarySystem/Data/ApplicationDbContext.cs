using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    // You can inherit the base IdentityContext and add your application custom DbSets
    public class ApplicationDbContext : IdentityDbContext<User, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("LibrarySystem")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(x => x.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(x => x.Author).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(x => x.Isbn).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(x => x.WebSite).HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(x => x.Description).HasMaxLength(3000);

            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}