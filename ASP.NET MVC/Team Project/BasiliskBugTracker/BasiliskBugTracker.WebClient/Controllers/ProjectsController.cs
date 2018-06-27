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
using BasiliskBugTracker.WebClient.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BasiliskBugTracker.WebClient.Areas.Administration.Models;

namespace BasiliskBugTracker.WebClient.Controllers
{
    [Authorize]
    public class ProjectsController : BaseController
    {
        public ProjectsController()
            : base()
        {
        }

        public ProjectsController(IUnitOfWork data)
            : base(data)
        {
        }

        // GET: /Projects/
        public ActionResult Index()
        {
            return View(this.Data.GetRepository<Project>()
                .All()
                .Include(p => p.Bugs)
                .Include(p => p.Contributors)
                .Include(p => p.Manager)
                .Where(p => p.IsDeleted == false)
                .Select(ProjectViewModelEx.CreateFromProject));
        }

        public ActionResult Contributors_Read([DataSourceRequest] DataSourceRequest request, int projectId)
        {
            var contributors = this.Data.GetRepository<Project>()
                .GetById(projectId)
                .Contributors.AsQueryable()
                .Where(c => c.IsDeleted == false)
                .Select(UserViewModel.FromUser)
                .ToList();

            return Json(contributors.ToDataSourceResult(request));
        }
        // GET: /Projects/Details/5
        public ActionResult Bugs_Read([DataSourceRequest] DataSourceRequest request, int projectId)
        {
            var contributors = this.Data.GetRepository<Project>().GetById(projectId)
                .Bugs.AsQueryable()
                .Where(b => b.Status != Status.Deleted)
                .Select(BugViewModel.FromBug);
            return Json(contributors.ToDataSourceResult(request));
        }

        protected override void Dispose(bool disposing)
        {
            this.Data.Dispose();
            base.Dispose(disposing);
        }
    }
}
