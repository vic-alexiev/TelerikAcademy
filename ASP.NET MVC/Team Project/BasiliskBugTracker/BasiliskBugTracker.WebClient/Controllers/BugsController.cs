using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasiliskBugTracker.Models;
using BasiliskBugTracker.Data;
using BasiliskBugTracker.Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BasiliskBugTracker.WebClient.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace BasiliskBugTracker.WebClient.Controllers
{
    [Authorize]
    public class BugsController : BaseController
    {
        public BugsController()
            : base()
        {
        }

        public BugsController(IUnitOfWork data)
            : base(data)
        {
        }

        // GET: /Bugs/
        public ActionResult Index()
        {
            return View(this.Data.GetRepository<Bug>().All()
                .Where(b => b.Status != Status.Deleted)
                .Select(BugViewModel.FromBug));
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var bugs = this.Data.GetRepository<Bug>().All()
                .Where(b => b.Status != Status.Deleted)
                .Select(BugViewModel.FromBug);

            return Json(bugs.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // GET: /Bugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bug bug = this.Data.GetRepository<Bug>().GetById((int)id);

            if (bug == null)
            {
                return HttpNotFound();
            }

            return View(bug);
        }

        // GET: /Bugs/Create
        public ActionResult Create([DataSourceRequest] DataSourceRequest request)
        {
            return PartialView("_CreateBug", new BugViewModel());
        }

        public JsonResult GetProjects()
        {
            var projects = this.Data.GetRepository<Project>().All();

            var projectData =
                from project in projects
                select new ExistingProjectViewModel
                {
                    Id = project.Id,
                    Name = project.Name
                };

            return Json(projectData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBugViewModel bug, IEnumerable<HttpPostedFileBase> attachments)
        {
            if (bug != null && ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();

                ApplicationUser currentUser = GetCurrentUserById(currentUserId);
                Project project = this.Data.GetRepository<Project>().GetById(bug.Project);
                Bug newBug = new Bug()
                {
                    Title = bug.Title,
                    DateDiscovered = DateTime.Now,
                    Description = bug.Description,
                    Owner = currentUser,
                    Project = project,
                    AssignedTo = project.Manager,
                    Priority = bug.Priority,
                    Status = Status.New
                };

                this.Data.GetRepository<Bug>().Add(newBug);

                // The Name of the Upload component is "attachments"
                if (attachments != null)
                {
                    foreach (var file in attachments)
                    {
                        string contentType = file.ContentType;

                        if (contentType.StartsWith("application/octet-stream") && file.FileName.EndsWith(".zip") ||
                            contentType.StartsWith("application/x-zip-compressed") ||
                            contentType.StartsWith("application/zip") ||
                            contentType.StartsWith("multipart/x-zip"))
                        {
                            var physicalPath = Path.Combine(
                               Server.MapPath("~/Attachments"),
                                Guid.NewGuid().ToString() + ".zip");

                            file.SaveAs(physicalPath);

                            var attachment = new Attachment
                            {
                                Bug = newBug,
                                PhysicalPath = physicalPath,
                            };

                            this.Data.GetRepository<Attachment>().Add(attachment);
                        }
                    }
                }

                this.Data.Save();
                return RedirectToAction("Index");
            }

            return PartialView("_CreateBug", new BugViewModel());
        }

        private ApplicationUser GetCurrentUserById(string userId)
        {
            ApplicationUser currentUser = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == userId);
            return currentUser;
        }

        // GET: /Bugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bug bug = this.Data.GetRepository<Bug>().GetById((int)id);

            if (bug == null)
            {
                return HttpNotFound();
            }

            return View(bug);
        }

        // POST: /Bugs/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bug bug)
        {
            if (bug != null && ModelState.IsValid)
            {
                this.Data.GetRepository<Bug>().Update(bug);
                this.Data.Save();
                return RedirectToAction("Index");
            }
            return View(bug);
        }

        // GET: /Bugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bug bug = this.Data.GetRepository<Bug>().GetById((int)id);

            if (bug == null)
            {
                return HttpNotFound();
            }

            return View(bug);
        }

        // POST: /Bugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug bug = this.Data.GetRepository<Bug>().GetById((int)id);
            this.Data.GetRepository<Bug>().Delete(bug);
            this.Data.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.Data.Dispose();
            base.Dispose(disposing);
        }
    }
}
