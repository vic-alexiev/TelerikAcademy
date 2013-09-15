using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Data;
using WebChat.Models;

namespace WebChat.Moderator
{
    public partial class ModeratorDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        protected void GridViewMessages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                string contents = (this.GridViewMessages.Rows[e.RowIndex].FindControl("TextBoxContents") as TextBox).Text;

                if (string.IsNullOrWhiteSpace(contents))
                {
                    LabelErrorMessage.Text = "Contents cannot be empty";
                    e.Cancel = true;
                    return;
                }

                int messageId = Convert.ToInt32(this.GridViewMessages.DataKeys[e.RowIndex].Value);

                var message = context.Messages.FirstOrDefault(m => m.Id == messageId);
                if (message == null)
                {
                    LabelErrorMessage.Text = "No message selected.";
                    e.Cancel = true;
                    return;
                }

                message.Contents = contents;
                context.Entry<Message>(message).State = EntityState.Modified;
                context.SaveChanges();

                DataBind();
                Response.Redirect(Request.RawUrl);
                e.Cancel = true;
            }
        }

        protected void GridViewMessages_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewMessages.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridViewMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMessages.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void GridViewMessages_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewMessages.EditIndex = -1;
            BindData();
        }

        protected void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                string contents = (this.GridViewMessages.FooterRow.FindControl("TextBoxNewContents") as TextBox).Text;

                if (string.IsNullOrWhiteSpace(contents))
                {
                    LabelErrorMessage.Text = "Contents cannot be empty";
                    return;
                }

                var user = context.Users.Find(User.Identity.GetUserId());
                if (user == null)
                {
                    LabelErrorMessage.Text = "You must login to send a message.";
                    return;
                }

                var message = new Message
                {
                    Author = user,
                    Contents = contents.Trim(),
                    Timestamp = DateTime.Now
                };

                context.Messages.Add(message);
                context.SaveChanges();
                DataBind();
                Response.Redirect(Request.RawUrl);
            }
        }

        private void BindData()
        {
            using (var context = new ApplicationDbContext())
            {
                GridViewMessages.DataSource = context.Messages.ToList();
                GridViewMessages.DataBind();
            }
        }
    }
}