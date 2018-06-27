using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineDatingSystem.Models
{
    // You can add profile data for the user by adding more properties to your User class, 
    // please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public ApplicationUser()
            : base()
        {
            this.Interests = new HashSet<Interest>();
            this.VotedFor = new HashSet<ApplicationUser>();
            this.Voters = new HashSet<ApplicationUser>();
            this.Messages = new HashSet<Message>();
        }

        [Required(ErrorMessage="Required Field"), 
        MaxLength(length:50, ErrorMessage="Max lenght 50")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual Country Country { get; set; }

        public virtual City City { get; set; }

        public string Sex { get; set; }

        public string LookingFor { get; set; }

        public virtual EducationType Education { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual ICollection<ApplicationUser> VotedFor { get; set; }

        public virtual ICollection<ApplicationUser> Voters { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}