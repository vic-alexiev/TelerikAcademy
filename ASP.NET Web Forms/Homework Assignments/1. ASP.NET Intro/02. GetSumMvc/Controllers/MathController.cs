using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.GetSumMvc.Controllers
{
    public class MathController : Controller
    {
        //
        // GET: /Math/Sum?a=7&b=9
        public ActionResult Sum(int a, int b)
        {
            long sum = a + b;
            ViewBag.Sum = sum.ToString();

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
