using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using OnlineDatingSystem.Models;

namespace OnlineDatingSystem.Data
{
    // You can inherit the base IdentityContext and add your application custom DbSets
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("OnlineDatingSystem")
        {
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<EducationType> EducationTypes { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Reason> Reasons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Phone).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Description).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.BirthDate).IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Sex).IsRequired().IsFixedLength().HasMaxLength(1);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.LookingFor).IsRequired().IsFixedLength().HasMaxLength(1);

            modelBuilder.Entity<Message>().Property(x => x.Content).IsRequired().HasMaxLength(250);

            base.OnModelCreating(modelBuilder);
        }
    }
}