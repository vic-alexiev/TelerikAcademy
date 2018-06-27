using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BasiliskBugTracker.Models;
using BasiliskBugTracker.Data;
using BasiliskBugTracker.WebClient.Controllers;
using BasiliskBugTracker.Repository;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using BasiliskBugTracker.WebClient.Models;
using System.IO;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator, ProjectManager")]
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
            return View(this.Data.GetRepository<Bug>().All().Select(BugViewModel.FromBug));
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

        public ActionResult Create([DataSourceRequest] DataSourceRequest request)
        {
            return PartialView("_AdminCreateBug", new BugViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBugViewModel bug, IEnumerable<HttpPostedFileBase> attachments)
        {
            string currentUserId = User.Identity.GetUserId();

            if (bug != null && ModelState.IsValid && currentUserId != null)
            {
                ApplicationUser currentUser = GetCurrentUserById(currentUserId);
                ApplicationUser userAssignedTo = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == bug.AssignedTo);
                Project project = this.Data.GetRepository<Project>().GetById(int.Parse(this.Request.UrlReferrer.Segments[4]));
                Bug newBug = new Bug()
                {
                    Title = bug.Title,
                    DateDiscovered = DateTime.Now,
                    Description = bug.Description,
                    Owner = currentUser,
                    Priority = bug.Priority,
                    Status = Status.New,
                    Project = project,
                    AssignedTo = userAssignedTo,
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
                return RedirectToAction("Details", "Projects", new { id = project.Id });
            }

            return PartialView("_AdminCreateBug", new BugViewModel());
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
        // [ValidateAntiForgeryToken]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request,
            EditBugViewModel bug)
        {
            if (bug != null && ModelState.IsValid)
            {
                var target = this.Data.GetRepository<Bug>().All().Include(b => b.Project).FirstOrDefault(b => b.Id == bug.Id);
                var assignedTo = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == bug.AssignedTo.Id);
                var project = this.Data.GetRepository<Project>().All().FirstOrDefault(p => p.Id == bug.Project.Id);

                if (target != null)
                {
                    target.Title = bug.Title;
                    target.AssignedTo = assignedTo;
                    target.Description = bug.Description;
                    target.Priority = bug.Priority;
                    target.Status = bug.Status;
                    target.Project = project;
                }

                this.Data.Save();
            }

            return Json(new[] { bug }.ToDataSourceResult(request, ModelState));
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
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug bug = this.Data.GetRepository<Bug>().GetById((int)id);
            bug.Status = Status.Deleted;
            this.Data.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.Data.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult GetProjects()
        {
            var projects = this.Data.GetRepository<Project>().All();

            var projectData =
                from project in projects
                select new ExistingProjectViewModel
                {
                    Id = project.Id,
                    Name = project.Name,
                };

            return Json(projectData, JsonRequestBehavior.AllowGet);
        }

        private ApplicationUser GetCurrentUserById(string currentUserId)
        {
            ApplicationUser currentUser = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == currentUserId);
            return currentUser;
        }
    }
}
