using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Models
{
    public class Project
    {
        public Project()
        {
            this.Bugs = new HashSet<Bug>();
            this.Contributors = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }

        public virtual ApplicationUser Manager { get; set; }

        public virtual ICollection<ApplicationUser> Contributors { get; set; }
    }
}
