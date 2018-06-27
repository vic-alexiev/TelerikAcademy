using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Models
{
    public class ApplicationUser : User
    {
        public ApplicationUser()
        {
            this.ProjectsContributingTo = new HashSet<Project>();
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsDeleted { get; set; }

        [InverseProperty("Contributors")]
        public virtual ICollection<Project> ProjectsContributingTo { get; set; }

        [InverseProperty("Manager")]
        public virtual ICollection<Project> ProjectsManaging { get; set; }
    }
}
