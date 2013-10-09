using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
