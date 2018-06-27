using BasiliskBugTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasiliskBugTracker.WebClient.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IUnitOfWork data)
        {
            this.Data = data;
        }

        public BaseController()
        {
            this.Data = new UnitOfWork();
        }

        protected IUnitOfWork Data { get; set; }
    }
}