using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        //
        // GET: /Authors/
        public ActionResult Index()
        {
            var context = new BookStoreDbContext();
            var authors = context.Authors.Include(c => c.Books);
            return View(authors);
        }
	}
}