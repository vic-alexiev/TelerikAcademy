using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            var context = new BookStoreDbContext();
            var categories = context.Categories.Include(c => c.Books);
            return View(categories);
        }
    }
}