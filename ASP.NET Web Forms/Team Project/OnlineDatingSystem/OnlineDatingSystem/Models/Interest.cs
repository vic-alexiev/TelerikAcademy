using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineDatingSystem.Models
{
    public class Interest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
