using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.WebClient.Models
{
    public class TicketDetailedViewModel : TicketViewModel
    {
        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static new TicketDetailedViewModel FromTicket(Ticket ticket)
        {
            var detailedTicket = new TicketDetailedViewModel
            {
                Id = ticket.Id,
                Author = ticket.Author.UserName,
                Category = ticket.Category.Name,
                CommentsCount = ticket.Comments.Count(),
                Description = ticket.Description,
                Priority = ticket.Priority,
                ScreenshotUrl = ticket.ScreenshotUrl,
                Title = ticket.Title,
                Comments = ticket.Comments.AsQueryable().Select(CommentViewModel.FromComment)
            };

            return detailedTicket;
        }
    }
}