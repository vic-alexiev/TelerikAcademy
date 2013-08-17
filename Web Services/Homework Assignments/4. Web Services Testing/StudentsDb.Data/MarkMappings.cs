using StudentsDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace StudentsDb.Data
{
    public class MarkMappings : EntityTypeConfiguration<Mark>
    {
        public MarkMappings()
        {
            this.HasKey(m => m.Id);
            this.Property(m => m.Id).HasColumnName("MarkId");

            this.Property(m => m.Subject).HasMaxLength(255);
            this.Property(m => m.Subject).IsUnicode(true);
            this.Property(m => m.Subject).IsRequired();

            this.Property(m => m.Value).IsRequired();
        }
    }
}
