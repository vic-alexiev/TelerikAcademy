using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using LibrarySystem.Data;
using LibrarySystem.Models;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var categories = context.Categories.Include(c => c.Books);
                this.ListViewCategories.DataSource = categories.ToList();
                this.DataBind();
            }
        }

        protected void ButtonSearchBooks_Click(object sender, EventArgs e)
        {
            string searchString = this.TextBoxSearchBooks.Text;
            Response.Redirect("Search.aspx?q=" + searchString);
        }
    }
}