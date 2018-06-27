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
using BasiliskBugTracker.WebClient.Controllers;
using BasiliskBugTracker.WebClient.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BasiliskBugTracker.WebClient.Areas.Administration.Models;
using System.Collections;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator, ProjectManager")]
    public class ProjectsController : BaseController
    {
        // GET: /Administration/Projects/
        public ActionResult Index()
        {
            var projects = this.Data.GetRepository<Project>().All()
                .Include(p => p.Bugs)
                .Include(p => p.Contributors)
                .Where(p => p.IsDeleted == false)
                .Select(ProjectViewModel.FromProject);
            return View(projects.OrderByDescending(p => p.BugsCount));
        }

        // GET: /Administration/Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = this.Data.GetRepository<Project>().All().Include(p => p.Bugs).FirstOrDefault(p => p.Id == id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }

            IQueryable<BugViewModel> bugs = project.Bugs.AsQueryable().Select(BugViewModel.FromBug).OrderBy(b => b.Status);
            ViewBag.ProjectName = project.Name;
            ViewBag.ProjectId = project.Id;
            return View(bugs);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IQueryable<BugViewModel> bugs = GetBugsByProjectId(id);

            return Json(bugs.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private IQueryable<BugViewModel> GetBugsByProjectId(int? id)
        {
            IQueryable<BugViewModel> bugs = this.Data.GetRepository<Bug>().All()
                .Where(b => b.Project.Id == id && b.Status != Status.Deleted)
                .Select(BugViewModel.FromBug);
            return bugs;
        }
        // GET: /Administration/Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administration/Projects/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProjectViewModel project)
        {
            if (project != null && ModelState.IsValid)
            {
                var contributors = new List<ApplicationUser>();

                if (project.Contributors != null)
                {
                    foreach (var userId in project.Contributors)
                    {
                        var contributor = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == userId);
                        contributors.Add(contributor);
                    }
                }

                var manager = this.Data.GetRepository<ApplicationUser>().All()
                    .FirstOrDefault(u => u.Id == project.Manager);

                var newProject = new Project()
                {
                    Name = project.Name,
                    Description = project.Description,
                    Manager = manager,
                    Contributors = contributors
                };

                this.Data.GetRepository<Project>().Add(newProject);
                this.Data.Save();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: /Administration/Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = this.Data.GetRepository<Project>()
                .All()
                .Include(p => p.Contributors)
                .FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return HttpNotFound();
            }

            var projectToEdit = ProjectViewModel.ConvertFrom(project);
            ViewBag.ProjectContributors = projectToEdit.Contributors.ToList();

            return View(projectToEdit);
        }

        // POST: /Administration/Projects/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                var currentProject = this.Data.GetRepository<Project>().All().FirstOrDefault(p => p.Id == project.Id);
                currentProject.Name = project.Name;
                currentProject.Description = project.Description;

                var oldManager = currentProject.Manager;
                oldManager.ProjectsManaging.Remove(currentProject);

                int contributorsCount = currentProject.Contributors.Count;

                for (int i = 0; i < contributorsCount; i++)
                {
                    var contributor = currentProject.Contributors.ElementAt(i);
                    contributor.ProjectsContributingTo.Remove(currentProject);
                }

                this.Data.Save();

                var newManager = this.Data.GetRepository<ApplicationUser>().All()
                    .FirstOrDefault(u => u.Id == project.Manager);
                currentProject.Manager = newManager;

                var contributors = new List<ApplicationUser>();

                if (project.Contributors != null)
                {
                    foreach (var userId in project.Contributors)
                    {
                        var contributor = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == userId);
                        contributors.Add(contributor);
                    }
                }

                currentProject.Contributors = contributors.ToList();
                this.Data.GetRepository<Project>().Update(currentProject);
                this.Data.Save();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: /Administration/Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = this.Data.GetRepository<Project>().GetById(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Administration/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var project = this.Data.GetRepository<Project>().All().FirstOrDefault(p => p.Id == id);
            if (project != null)
            {
                project.IsDeleted = true;
                this.Data.GetRepository<Project>().Update(project);
                this.Data.Save();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }

        public ActionResult GetProjectContributors()
        {
            var projectId = int.Parse(this.Request.UrlReferrer.Segments[4]);
            var projectUsers = this.Data.GetRepository<Project>()
                .GetById(projectId)
                .Contributors
                .Where(c => c.IsDeleted == false)
                .ToList();

            var contributors =
                from u in projectUsers
                select new UserInProjectViewModel
                {
                    Id = u.Id,
                    Name = u.Name
                };

            return Json(contributors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectManagers()
        {
            var projectManagers = this.Data.GetRepository<ApplicationUser>()
                .All()
                .Where(u => u.Roles.Any(r => r.Role.Name == "ProjectManager") && u.IsDeleted == false)
                .ToList();

            var managers =
                from u in projectManagers
                select new UserInProjectViewModel
                {
                    Id = u.Id,
                    Name = u.Name
                };

            return Json(managers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsers()
        {
            var users = this.Data.GetRepository<ApplicationUser>().All()
                .Where(u => u.IsDeleted == false)
                .ToList();

            var contributors =
                from u in users
                select new UserInProjectViewModel
                {
                    Id = u.Id,
                    Name = u.Name
                };

            return Json(contributors, JsonRequestBehavior.AllowGet);
        }
    }
}
