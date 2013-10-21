using LibrarySystem.Data;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                string bookIdAsString = Request.Params["id"];
                int bookId = 0;
                if (string.IsNullOrWhiteSpace(bookIdAsString) || !int.TryParse(bookIdAsString, out bookId))
                {
                    Response.Redirect("~/");
                }

                using (var context = new ApplicationDbContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    this.LabelBookTitle.InnerText = book.Title;
                    this.LabelBookAuthor.InnerText = "by " + book.Author;
                    this.LabelBookIsbn.InnerText = "ISBN " + book.Isbn;
                    this.LinkButtonBookWebSite.Text = book.WebSite;
                    this.LabelBookDescription.Text = book.Description;
                }
            }
        }
    }
}