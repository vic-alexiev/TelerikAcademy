using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Models
{
    public class Bug
    {
        public Bug()
        {
            this.Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateDiscovered { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ApplicationUser AssignedTo { get; set; }

        public string Description { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
