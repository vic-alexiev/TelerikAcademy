using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Models;
using TicketingSystem.WebClient.Models;

namespace TicketingSystem.WebClient.Controllers
{
    public class TicketsController : BaseController
    {
        const int PageSize = 5;

        // Tickets/List/5
        [Authorize]
        public ActionResult List(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);

            var ticketsOnPage = GetAllTickets().Skip((pageNumber - 1) * PageSize).Take(PageSize);
            ViewBag.Pages = Math.Ceiling((double)GetAllTickets().Count() / PageSize);

            return View(ticketsOnPage);
        }

        // GET: /Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = this.Data.GetRepository<Ticket>().GetById(id.Value);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            var detailedTicket = TicketDetailedViewModel.FromTicket(ticket);

            return View(detailedTicket);
        }

        // GET: /Tickets/Create
        [Authorize]
        public ActionResult Create()
        {
            var newTicket = new CreateTicketViewModel();
            newTicket.Priority = Priority.Medium;
            return View(newTicket);
        }

        // POST: /Tickets/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewTicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                string userName = User.Identity.GetUserName();
                var currentUser = this.Data.GetRepository<ApplicationUser>()
                    .All()
                    .FirstOrDefault(u => u.Id == userId);

                if (currentUser != null)
                {
                    var category = this.Data.GetRepository<Category>().GetById(ticket.Category);
                    if (category != null)
                    {
                        var newTicket = new Ticket
                        {
                            Author = currentUser,
                            Category = category,
                            Description = ticket.Description,
                            Priority = ticket.Priority,
                            ScreenshotUrl = ticket.ScreenshotUrl,
                            Title = ticket.Title
                        };
                        this.Data.GetRepository<Ticket>().Add(newTicket);
                        currentUser.Points++;
                        this.Data.Save();
                        return RedirectToAction("List");
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, GetModelStateErrors());
            }
        }

        public JsonResult GetCategories()
        {
            var categories = this.Data.GetRepository<Category>().All();

            var categoryData = categories.Select(CategoryViewModel.FromCategory);

            return Json(categoryData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoriesData()
        {
            var result = this.Data.GetRepository<Category>()
                .All()
                .Select(c => new
                {
                    CategoryName = c.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllTickets().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(int ticketId, CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var ticket = this.Data.GetRepository<Ticket>().GetById(ticketId);
                if (ticket != null)
                {
                    string userId = User.Identity.GetUserId();
                    string userName = User.Identity.GetUserName();
                    var currentUser = this.Data.GetRepository<ApplicationUser>()
                        .All()
                        .FirstOrDefault(u => u.Id == userId);
                    if (currentUser != null)
                    {
                        var newComment = new Comment
                        {
                            Author = currentUser,
                            Ticket = ticket,
                            Content = comment.Content
                        };

                        this.Data.GetRepository<Comment>().Add(newComment);
                        this.Data.Save();

                        var returnComment = new CommentViewModel
                        {
                            Author = userName,
                            Content = comment.Content
                        };

                        return PartialView("_Comment", returnComment);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, GetModelStateErrors());
            }
        }

        public ActionResult Search(SubmitSearchModel submitSearchModel)
        {
            var searchCategory = submitSearchModel.Category;
            var tickets = this.Data.GetRepository<Ticket>().All();

            if (searchCategory != "All")
            {
                tickets = tickets.Where(t => t.Category.Name == searchCategory);
            }

            var result = tickets.Select(TicketViewModel.FromTicket);

            return View(result);
        }

        private IQueryable<TicketViewModel> GetAllTickets()
        {
            var allTickets = this.Data.GetRepository<Ticket>()
                .All()
                .Select(TicketViewModel.FromTicket)
                .OrderBy(t => t.Id);

            return allTickets;
        }

        private string GetModelStateErrors()
        {
            return string.Join(
                ", ",
                ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
        }
    }
}