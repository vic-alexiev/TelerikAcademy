using StudentSystem.Model;
using System.Data.Entity.ModelConfiguration;

namespace StudentSystem.Data
{
    public class HomeworkMappings : EntityTypeConfiguration<Homework>
    {
        public HomeworkMappings()
        {
            this.HasKey(h => h.Id);

            this.Property(h => h.Content).IsUnicode(true);
            this.Property(h => h.Content).IsMaxLength();
            this.Property(h => h.Content).IsRequired();

            this.Property(h => h.TimeSent).IsOptional();
        }
    }
}
