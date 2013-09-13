using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoModels;

namespace ToDosManagement
{
    public partial class ToDos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddToDo_Click(object sender, EventArgs e)
        {
            using (var context = new ToDosDbEntities())
            {
                string categoryName = (this.GridViewToDos.FooterRow.FindControl("TextBoxNewCategoryName") as TextBox).Text;
                var category = context.Categories.FirstOrDefault(c => string.Compare(c.Name, categoryName, true) == 0);
                if (category == null)
                {
                    category = new Category
                    {
                        Name = categoryName
                    };

                    context.Categories.Add(category);

                    context.SaveChanges();
                }

                context.ToDos.Add(new ToDo
                {
                    Title = (this.GridViewToDos.FooterRow.FindControl("TextBoxNewTitle") as TextBox).Text,
                    Body = (this.GridViewToDos.FooterRow.FindControl("TextBoxNewBody") as TextBox).Text,
                    LastUpdated = DateTime.Parse((this.GridViewToDos.FooterRow.FindControl("TextBoxNewLastUpdated") as TextBox).Text),
                    Category = category
                });

                context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            using (var context = new ToDosDbEntities())
            {
                string categoryName = (this.GridViewCategories.FooterRow.FindControl("TextBoxNewName") as TextBox).Text;

                var category = context.Categories.FirstOrDefault(c => string.Compare(c.Name, categoryName, true) == 0);
                if (category == null)
                {
                    category = new Category
                    {
                        Name = categoryName
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}