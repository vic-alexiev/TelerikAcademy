using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.WebClient.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public Priority Priority { get; set; }

        public string PriorityName
        {
            get
            {
                return Enum.GetName(typeof(Priority), this.Priority);
            }
        }

        public int CommentsCount { get; set; }

        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Priority = ticket.Priority,
                    CommentsCount = ticket.Comments.Count()
                };
            }
        }
    }
}