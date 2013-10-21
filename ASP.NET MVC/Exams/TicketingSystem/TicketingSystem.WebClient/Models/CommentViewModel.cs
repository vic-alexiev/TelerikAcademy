using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.WebClient.Models
{
    public class CommentViewModel
    {
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Author = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }
    }
}