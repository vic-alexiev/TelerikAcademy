using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketingSystem.WebClient.Models
{
    public class NewTicketViewModel : CreateTicketViewModel
    {
        public new int Category { get; set; }
    }
}