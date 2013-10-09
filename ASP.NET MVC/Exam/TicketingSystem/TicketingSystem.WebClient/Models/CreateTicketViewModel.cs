using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TicketingSystem.Models;
using TicketingSystem.WebClient.Models.CustomAttributes;

namespace TicketingSystem.WebClient.Models
{
    public class CreateTicketViewModel
    {
        [Required]
        [DoesNotContainTheWordBug(ErrorMessage = "The title should not contain the word 'bug'.")]
        public string Title { get; set; }

        public CategoryViewModel Category { get; set; }

        public string Description { get; set; }

        [UIHint("Priority")]
        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }
    }
}