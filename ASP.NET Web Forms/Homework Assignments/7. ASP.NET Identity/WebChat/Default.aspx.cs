using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web.UI;
using WebChat.Data;
using WebChat.Models;

namespace WebChat
{
    public partial class _Default : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Redirect();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                this.RepeaterMessages.DataSource = context.Messages.ToList();
                this.RepeaterMessages.DataBind();
            }
        }

        protected void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            string contents = this.TextBoxMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(contents))
            {
                this.LabelErrorMessage.Text = "No message to send.";
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.Find(User.Identity.GetUserId());
                if (user == null)
                {
                    this.LabelErrorMessage.Text = "User not logged in.";
                    return;
                }

                var newMessage = new Message
                {
                    Author = user,
                    Contents = contents,
                    Timestamp = DateTime.Now
                };

                context.Messages.Add(newMessage);
                context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        private async void Redirect()
        {
            AuthenticationIdentityManager manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            var userId = User.Identity.GetUserId();
            var roles = await manager.Roles.GetRolesForUserAsync(userId);
            if (roles.Any(r => r.Name == "Administrator"))
            {
                Response.Redirect("~/Administrator/AdministratorDefault.aspx");
            }
            else if (roles.Any(r => r.Name == "Moderator"))
            {
                Response.Redirect("~/Moderator/ModeratorDefault.aspx");
            }
        }
    }
}