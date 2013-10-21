using LibrarySystem.Data;
using LibrarySystem.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Registered
{
    public partial class EditBooks : System.Web.UI.Page
    {
        private const string OrderBy = "orderBy";
        private const string Ascending = "ascending";
        private const string Descending = "descending";
        private const string OrderDirection = "orderDirection";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LinkButtonNewBook.Visible = true;
        }

        public IQueryable<Book> ListViewBooks_GetData(string sortByExpression = null)
        {
            var context = new ApplicationDbContext();

            var books = context.Books;

            IOrderedQueryable<Book> orderedBooks = null;
            if (sortByExpression != null)
            {
                CacheSortBy(sortByExpression);
                if ((string)Session[OrderDirection] == Ascending)
                {
                    orderedBooks = Sort(books);
                }
                else
                {
                    orderedBooks = SortDecending(books);
                }
            }
            else
            {
                orderedBooks = books.OrderBy(b => b.Id);
            }

            return orderedBooks;
        }

        private IOrderedQueryable<Book> SortDecending(
            IOrderedQueryable<Book> books)
        {
            IOrderedQueryable<Book> orderedBooks = books.OrderByDescending(b => b.Title);

            return orderedBooks;
        }

        private IOrderedQueryable<Book> Sort(
            IOrderedQueryable<Book> books)
        {
            IOrderedQueryable<Book> orderedBooks = books.OrderBy(b => b.Title);

            return orderedBooks;
        }

        private void CacheSortBy(string sortByExpression)
        {
            if (sortByExpression != null)
            {
                if ((string)Session[OrderBy] == sortByExpression)
                {
                    ToggleSortDirection();
                }
                else
                {
                    Session[OrderDirection] = Ascending;
                }

                Session[OrderBy] = sortByExpression;
            }
        }

        private void ToggleSortDirection()
        {
            var direction = (string)Session[OrderDirection];

            if (direction == null || direction == Descending)
            {
                direction = Ascending;
            }
            else
            {
                direction = Descending;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewBooks_DeleteItem(int id)
        {
            using (var scope = new TransactionScope())
            {
                var context = new ApplicationDbContext();

                var booksToDelete = context.Books.Include(b => b.Category)
                    .Where(b => b.Id == id)
                    .AsEnumerable();

                context.Books.RemoveRange(booksToDelete);

                context.SaveChanges();

                var bookToDelete = context.Books.Find(id);

                context.Books.Remove(bookToDelete);

                context.SaveChanges();

                scope.Complete();
            }
        }

        protected void LinkButtonNewBook_Click(object sender, EventArgs e)
        {
            this.LinkButtonNewBook.Visible = false;
            this.PanelNewBook.Visible = true;
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;
            }

            string bookTitle = this.TextBoxNewBook.Text;
            if (string.IsNullOrWhiteSpace(bookTitle))
            {
                this.LabelErrorMessage.Text = "Book title is required.";
                this.PanelNewBook.Visible = true;
                return;
            }

            var book = new Book
            {
                Title = bookTitle
            };

            var context = new ApplicationDbContext();

            context.Books.Add(book);
            context.SaveChanges();

            this.PanelNewBook.Visible = false;
            this.TextBoxNewBook.Text = string.Empty;
            this.LinkButtonNewBook.Visible = true;

            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonEdit_Command(object sender, CommandEventArgs e)
        {
            var context = new ApplicationDbContext();

            var bookToEdit = context.Books.Find(Convert.ToInt32(e.CommandArgument));

            this.LinkButtonNewBook.Visible = false;
            this.PanelNewBook.Visible = false;

            this.PanelEditBook.Visible = true;
            this.TextBoxEditBook.Text = bookToEdit.Title;

            ViewState["BookToEdit"] = e.CommandArgument;
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;
            }

            string bookTitle = this.TextBoxEditBook.Text;
            if (string.IsNullOrWhiteSpace(bookTitle))
            {
                this.LabelErrorMessage.Text = "Book title is required.";
                this.PanelEditBook.Visible = true;
                return;
            }

            int bookId = Convert.ToInt32(ViewState["BookToEdit"]);

            var context = new ApplicationDbContext();

            var bookToEdit = context.Books.Find(bookId);

            if (bookToEdit == null)
            {
                this.LabelErrorMessage.Text = "Book not found.";
                this.PanelEditBook.Visible = true;
                return;
            }

            bookToEdit.Title = bookTitle;
            context.Entry<Book>(bookToEdit).State = EntityState.Modified;

            context.SaveChanges();

            this.PanelEditBook.Visible = false;
            this.TextBoxEditBook.Text = string.Empty;

            Response.Redirect(Request.RawUrl);
        }
    }
}