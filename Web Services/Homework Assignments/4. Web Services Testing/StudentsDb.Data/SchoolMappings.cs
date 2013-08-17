using StudentsDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace StudentsDb.Data
{
    public class SchoolMappings:EntityTypeConfiguration<School>
    {
        public SchoolMappings()
        {
            this.HasKey(s => s.Id);
            
            this.Property(s => s.Id).HasColumnName("SchoolId");

            this.Property(s => s.Location).HasMaxLength(255);
            this.Property(s => s.Location).IsUnicode(true);
            this.Property(s => s.Location).IsRequired();

            this.Property(s => s.Name).HasMaxLength(255);
            this.Property(s => s.Name).IsUnicode(true);
            this.Property(s => s.Name).IsRequired();
        }
    }
}
