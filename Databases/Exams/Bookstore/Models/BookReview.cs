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
    
    public partial class BookReview
    {
        public int BookReviewId { get; set; }
        public int BookId { get; set; }
        public Nullable<System.DateTime> BookReviewDate { get; set; }
        public Nullable<int> BookReviewAuthorId { get; set; }
        public string BookReviewContents { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}