using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Library.Models;
using Library.Data;
using System.Text;

namespace Library.Services.Controllers
{
    public class BooksController : ApiController
    {
        private LibraryDbContext db = new LibraryDbContext();

        // GET api/Books
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        // GET api/Books/5
        public Book GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                var errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.NotFound,
                    string.Format("Book with id={0} doesn't exist.", id));
                throw new HttpResponseException(errorResponse);
            }

            return book;
        }

        // PUT api/Books/5
        public HttpResponseMessage PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.GetModelStateErrors());
                return errorResponse;
            }

            if (id != book.Id)
            {
                var errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    string.Format("Id mismatch error: id={0}, book.Id={1}", id, book.Id));
                return errorResponse;
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    var errorResponse = Request.CreateErrorResponse(
                        HttpStatusCode.NotFound,
                        string.Format("No book with id={0} was found.", id));
                    return errorResponse;
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.OK, "Book updated successfully.");
        }

        // POST api/Books
        public HttpResponseMessage PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.GetModelStateErrors());
                return errorResponse;
            }

            db.Books.Add(book);
            db.SaveChanges();

            return Request.CreateErrorResponse(HttpStatusCode.OK, "Book added successfully.");
        }

        // DELETE api/Books/5
        public HttpResponseMessage DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                var errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.NotFound,
                    string.Format("No book with id={0} was found.", id));
                return errorResponse;
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Request.CreateErrorResponse(HttpStatusCode.OK, "Book deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }

        private string GetModelStateErrors()
        {
            return string.Join(
                ", ",
                ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
        }
    }
}