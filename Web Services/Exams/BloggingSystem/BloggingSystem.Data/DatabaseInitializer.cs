using System.Data.Entity;

namespace BloggingSystem.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<BloggingSystemContext>
    {
        protected override void Seed(BloggingSystemContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Users_Username UNIQUE(Username)");
            context.Database.ExecuteSqlCommand("ALTER TABLE Users ADD CONSTRAINT uc_Users_DisplayName UNIQUE(DisplayName)");
        }
    }
}
