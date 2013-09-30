using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public Nullable<int> Year { get; set; }

        public Nullable<int> DirectorId { get; set; }

        public Nullable<int> ActorId { get; set; }

        public Nullable<int> ActressId { get; set; }

        public Nullable<int> StudioId { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Actress Actress { get; set; }

        public virtual Director Director { get; set; }

        public virtual Studio Studio { get; set; }
    }
}