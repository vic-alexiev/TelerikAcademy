using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookStore.Models
{
    public class BookViewModel
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return b =>
                new BookViewModel
                {
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Author = (b.Author.Firstname +" "+ b.Author.Lastname),
                    Year = b.Year,
                    Price = b.Price,
                    Category = b.Category.Name
                };
            }
        }
    }
}