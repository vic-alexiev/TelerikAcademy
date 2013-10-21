using LibrarySystem.Data;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string searchString = Request.Params["q"];

                using (var context = new ApplicationDbContext())
                {
                    var books = context.Books.Include(b => b.Category)
                        .Where(b => string.IsNullOrEmpty(searchString) ||
                            b.Title.Contains(searchString) ||
                            b.Author.Contains(searchString))
                            .OrderBy(b => b.Title)
                            .ThenBy(b => b.Author);

                    LabelSearchResults.Text = string.Format("Search Results for Query “{0}”:", searchString);

                    this.RepeaterBooksFound.DataSource = books.ToList();
                    this.RepeaterBooksFound.DataBind();
                }
            }
        }
    }
}