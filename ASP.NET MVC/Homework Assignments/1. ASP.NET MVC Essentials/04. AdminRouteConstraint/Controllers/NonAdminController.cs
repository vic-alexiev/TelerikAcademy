using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteConstraint.Controllers
{
    public class NonAdminController : Controller
    {
        //
        // GET: /NonAdmin/

        public ActionResult Index()
        {
            return View();
        }

    }
}
