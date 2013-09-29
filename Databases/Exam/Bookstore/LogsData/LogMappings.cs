using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using LogsModel;

namespace LogsData
{
    internal class LogMappings : EntityTypeConfiguration<Log>
    {
        public LogMappings()
        {
            this.HasKey(l => l.Id);
            this.Property(l => l.QueryXml).IsUnicode(true);
            this.Property(c => c.QueryXml).HasMaxLength(300);
        }
    }
}
