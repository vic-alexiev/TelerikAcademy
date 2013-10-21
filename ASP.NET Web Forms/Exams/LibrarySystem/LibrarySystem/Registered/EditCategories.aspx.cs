using LibrarySystem.Data;
using LibrarySystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;

namespace LibrarySystem.Registered
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LinkButtonNewCategory.Visible = true;
        }

        public IQueryable<Category> GridViewCategories_GetData()
        {
            var context = new ApplicationDbContext();

            var categories = context.Categories.AsQueryable();

            return categories;
        }

        protected void LinkButtonEditCategory_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = ((LinkButton)sender).Parent.Parent as GridViewRow;

            int categoryId = Convert.ToInt32(GridViewCategories.DataKeys[currentRow.RowIndex].Value);
            var context = new ApplicationDbContext();

            var categoryToEdit = context.Categories.Find(categoryId);

            this.LinkButtonNewCategory.Visible = false;
            this.PanelNewCategory.Visible = false;
            this.PanelDeleteCategory.Visible = false;

            this.PanelEditCategory.Visible = true;
            this.TextBoxEditCategory.Text = categoryToEdit.Name;

            ViewState["CategoryToEdit"] = categoryId;
        }

        protected void LinkButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            GridViewRow currentRow = ((LinkButton)sender).Parent.Parent as GridViewRow;

            int categoryId = Convert.ToInt32(GridViewCategories.DataKeys[currentRow.RowIndex].Value);
            var context = new ApplicationDbContext();

            var categoryToDelete = context.Categories.Find(categoryId);

            this.LinkButtonNewCategory.Visible = false;
            this.PanelNewCategory.Visible = false;
            this.PanelEditCategory.Visible = false;

            this.PanelDeleteCategory.Visible = true;
            this.TextBoxDeleteCategory.Text = categoryToDelete.Name;

            ViewState["CategoryToDelete"] = categoryId;
        }

        protected void LinkButtonNewCategory_Click(object sender, EventArgs e)
        {
            this.LinkButtonNewCategory.Visible = false;
            this.PanelNewCategory.Visible = true;
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;
            }

            string categoryName = this.TextBoxNewCategory.Text;
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                this.LabelErrorMessage.Text = "Category name is required.";
                this.PanelNewCategory.Visible = true;
                return;
            }

            var category = new Category
            {
                Name = categoryName
            };

            var context = new ApplicationDbContext();

            context.Categories.Add(category);
            context.SaveChanges();

            this.PanelNewCategory.Visible = false;
            this.TextBoxNewCategory.Text = string.Empty;
            this.LinkButtonNewCategory.Visible = true;

            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;
            }

            string categoryName = this.TextBoxEditCategory.Text;
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                this.LabelErrorMessage.Text = "Category name is required.";
                this.PanelEditCategory.Visible = true;
                return;
            }

            int categoryId = Convert.ToInt32(ViewState["CategoryToEdit"]);

            var context = new ApplicationDbContext();

            var categoryToEdit = context.Categories.Find(categoryId);

            if (categoryToEdit == null)
            {
                this.LabelErrorMessage.Text = "Category not found.";
                this.PanelEditCategory.Visible = true;
                return;
            }

            categoryToEdit.Name = categoryName;
            context.Entry<Category>(categoryToEdit).State = EntityState.Modified;

            context.SaveChanges();

            this.PanelEditCategory.Visible = false;
            this.TextBoxEditCategory.Text = string.Empty;

            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            using (var scope = new TransactionScope())
            {
                var context = new ApplicationDbContext();

                int categoryId = Convert.ToInt32(ViewState["CategoryToDelete"]);

                var booksToDelete = context.Books.Include(b => b.Category)
                    .Where(b => b.Category.Id == categoryId)
                    .AsEnumerable();

                context.Books.RemoveRange(booksToDelete);

                context.SaveChanges();

                var categoryToDelete = context.Categories.Find(categoryId);

                context.Categories.Remove(categoryToDelete);

                context.SaveChanges();

                scope.Complete();

                this.PanelDeleteCategory.Visible = false;
                this.TextBoxDeleteCategory.Text = string.Empty;

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}