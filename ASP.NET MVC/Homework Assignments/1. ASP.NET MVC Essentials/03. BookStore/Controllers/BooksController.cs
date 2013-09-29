using BookStore.Data;
using BookStore.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        public ActionResult Index()
        {
            var context = new BookStoreDbContext();
            var books = context.Books.Include(b => b.Author).Include(b => b.Category).Select(BookViewModel.FromBook);
            return View(books);
        }
    }
}