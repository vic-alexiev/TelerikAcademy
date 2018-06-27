using BasiliskBugTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Bug> Bugs { get; set; }

        public IDbSet<Project> Projects { get; set; }
    }
}
