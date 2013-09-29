using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Administration.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Administration/Books/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var context = new BookStoreDbContext();

            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Title.Contains(searchString) ||
                    b.Author.Lastname.Contains(searchString))
                    .Select(BookViewModel.FromBook);

            ViewBag.Success = true;
            ViewBag.SearchString = searchString;

            return View(books);
        }
    }
}