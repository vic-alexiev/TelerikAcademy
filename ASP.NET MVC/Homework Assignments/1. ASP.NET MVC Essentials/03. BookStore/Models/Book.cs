using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public virtual Author Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public virtual Category Category { get; set; }

    }
}