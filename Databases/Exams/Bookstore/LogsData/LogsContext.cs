using LogsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsData
{
    class LogsContext : DbContext
    {
        public LogsContext()
            : base("Logs")
        {
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LogMappings());
            base.OnModelCreating(modelBuilder);
        }
    }
}
