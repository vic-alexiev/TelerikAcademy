using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsModel
{
    public class Log
    {
        [Key(), Column("LogId")]
        public int Id { get; set; }

        [Column("LogDate")]
        public DateTime Date { get; set; }

        [Column("QueryXml")]
        public string QueryXml { get; set; }
    }
}
