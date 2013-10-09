using TicketingSystem.WebClient.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using System.Net;
using TicketingSystem.Models;
using System.Web.Caching;

namespace TicketingSystem.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        private const int TopCommentedTicketsCount = 6;

        public ActionResult Index()
        {
            if (HttpContext.Cache["TicketingSystemHomePage"] == null)
            {
                var topTickets = this.Data.GetRepository<Ticket>()
                    .All()
                    .OrderByDescending(t => t.Comments.Count)
                    .Take(TopCommentedTicketsCount)
                    .Select(TicketViewModel.FromTicket);

                HttpContext.Cache.Add(
                    "TicketingSystemHomePage",
                    topTickets.ToList(),
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return View(this.HttpContext.Cache["TicketingSystemHomePage"]);
        }
    }
}