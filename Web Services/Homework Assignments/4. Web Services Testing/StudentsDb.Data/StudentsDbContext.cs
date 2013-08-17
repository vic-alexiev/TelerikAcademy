using StudentsDb.Models;
using System.Data.Entity;

namespace StudentsDb.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext()
            : base("StudentsDb")
        {
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SchoolMappings());
            modelBuilder.Configurations.Add(new StudentMappings());
            modelBuilder.Configurations.Add(new MarkMappings());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
