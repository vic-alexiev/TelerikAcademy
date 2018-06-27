using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        public string PhysicalPath { get; set; }

        public virtual Bug Bug { get; set; }
    }
}
