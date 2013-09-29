using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
