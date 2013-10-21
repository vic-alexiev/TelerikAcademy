using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
