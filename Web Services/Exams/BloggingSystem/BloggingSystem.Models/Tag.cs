using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BloggingSystem.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }
    }
}
