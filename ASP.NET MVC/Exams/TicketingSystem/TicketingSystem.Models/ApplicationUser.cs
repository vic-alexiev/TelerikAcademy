using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        private const int DefaultPoints = 10;

        public ApplicationUser()
            : base()
        {
            Init();
        }

        public ApplicationUser(string userName)
            : base(userName)
        {
            Init();
        }

        public int Points { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        private void Init()
        {
            this.Points = DefaultPoints;
            this.Tickets = new HashSet<Ticket>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
