using BasiliskBugTracker.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasiliskBugTracker.WebClient.Models;
using BasiliskBugTracker.Repository;

namespace BasiliskBugTracker.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            : base()
        {
        }

        public HomeController(IUnitOfWork data)
            : base(data)
        {
        }
        public ActionResult Index()
        {
            var projects = this.Data.GetRepository<Project>().All().Include(p => p.Bugs);

            var chartData =
                from project in projects
                select new ChartViewModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    Bugs =
                    from bug in project.Bugs
                    group bug by bug.Status into bugGroup
                    select new BugGroupViewModel
                    {
                        Status = bugGroup.Key,
                        Count = bugGroup.Count()
                    }
                };

            return View(chartData);
        }
    }
}