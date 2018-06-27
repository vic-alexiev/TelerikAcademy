using Error_Handler_Control;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineDatingSystem.Data;
using OnlineDatingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDatingSystem
{
    public partial class SendMessage : System.Web.UI.Page
    {
        private string otherUserId = string.Empty;
        private const string OrderBy = "orderBy";
        private const string Ascending = "ascending";
        private const string Descending = "descending";
        private const string OrderDirection = "orderDirection";

        protected void Page_Load(object sender, EventArgs e)
        {
            otherUserId = Request.Params["id"];
        }

        protected void GridViewMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMessages.PageIndex = e.NewPageIndex;
            e.Cancel = true;
        }

        protected void LinkButtonSendMessage_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                string content = TextBoxNewMessageContent.Text;

                if (string.IsNullOrWhiteSpace(content))
                {
                    ErrorSuccessNotifier.AddErrorMessage("Content cannot be empty.");
                    return;
                }

                var user = context.Users.Find(User.Identity.GetUserId());
                if (user == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage("You must login to send a message.");
                    return;
                }

                var otherUser = context.Users.Find(otherUserId);
                if (otherUser == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Error identifying the other user.");
                    return;
                }

                var message = new Message
                {
                    Content = content.Trim(),
                    Timestamp = DateTime.Now,
                    Read = false,
                    Author = user,
                    Receiver = otherUser
                };

                context.Messages.Add(message);
                context.SaveChanges();
                this.TextBoxNewMessageContent.Text = string.Empty;
                
                //DataBind();
                //Response.Redirect(Request.RawUrl);
            }
        }

        public IQueryable<Message> GridViewMessages_GetData([ViewState("OrderBy")]string orderBy = null)
        {
            try
            {
                var context = new ApplicationDbContext();

                string currentUserId = User.Identity.GetUserId();
                string otherUserId = Request.Params["id"];

                var messages = context.Messages
                    .Where(m => (m.Author.Id == currentUserId || m.Receiver.Id == currentUserId) &&
                        (m.Author.Id == otherUserId || m.Receiver.Id == otherUserId))
                        .OrderBy(m => m.Timestamp);

                return messages;
            }
            catch (Exception ex)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex);
                return new List<Message>().AsQueryable();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMessages_DeleteItem(string id)
        {
            try
            {
                int messageId = int.Parse(id);
                var context = new ApplicationDbContext();
                var message = context.Messages.Find(messageId);
                context.Messages.Remove(message);
                context.SaveChanges();

                ErrorSuccessNotifier.AddInfoMessage("Message deleted.");
                this.GridViewMessages.DataBind();
            }
            catch (DbEntityValidationException ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }

        }

        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            this.GridViewMessages.DataBind();
        }
    }
}