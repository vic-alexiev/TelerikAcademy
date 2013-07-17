using StudentSystem.Model;
using System.Data.Entity.ModelConfiguration;

namespace StudentSystem.Data
{
    class CourseMappings : EntityTypeConfiguration<Course>
    {
        public CourseMappings()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsUnicode(true);
            this.Property(c => c.Name).HasMaxLength(255);
            this.Property(c => c.Name).IsRequired();

            this.Property(c => c.Description).IsUnicode(true);
            this.Property(c => c.Description).IsMaxLength();
            this.Property(c => c.Description).IsOptional();

            this.Property(c => c.Materials).IsUnicode(true);
            this.Property(c => c.Materials).IsMaxLength();
            this.Property(c => c.Materials).IsOptional();
        }
    }
}
