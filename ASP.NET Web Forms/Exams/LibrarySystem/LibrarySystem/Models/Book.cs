using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public virtual Category Category { get; set; }
    }
}