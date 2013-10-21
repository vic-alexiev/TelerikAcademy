//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.BookReviews = new HashSet<BookReview>();
            this.Authors = new HashSet<Author>();
        }
    
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookISBN { get; set; }
        public Nullable<decimal> BookPrice { get; set; }
        public string BookWebSite { get; set; }
    
        public virtual ICollection<BookReview> BookReviews { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}