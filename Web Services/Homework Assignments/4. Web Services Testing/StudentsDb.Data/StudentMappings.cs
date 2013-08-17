using StudentsDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace StudentsDb.Data
{
    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasColumnName("StudentId");

            this.Property(s => s.FirstName).HasMaxLength(255);
            this.Property(s => s.FirstName).IsUnicode(true);
            this.Property(s => s.FirstName).IsRequired();
                               
            this.Property(s => s.LastName).HasMaxLength(255);
            this.Property(s => s.LastName).IsUnicode(true);
            this.Property(s => s.LastName).IsRequired();

            this.Property(s => s.Age).IsOptional();
            this.Property(s => s.Grade).IsRequired();
        }
    }
}
