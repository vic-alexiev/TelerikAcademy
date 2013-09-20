using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChat
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            ListViewMessages.DataBind();
        }

        protected void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            string contents = this.TextBoxContents.Text.Trim();
            string author = this.TextBoxAuthor.Text.Trim();

            if (contents.Length > 250)
            {
                this.LabelErrorMessage.Text = "The contents must be at most 250 characters long.";
                return;
            }

            if (author.Length > 50)
            {
                this.LabelErrorMessage.Text = "The author name must be at most 50 characters long.";
                return;
            }

            var context = new SimpleChatEntities();

            var message = new Message
            {
                Contents = this.TextBoxContents.Text,
                Author = this.TextBoxAuthor.Text,
                Timestamp = DateTime.Now
            };

            context.Messages.Add(message);
            context.SaveChanges();

            this.TextBoxContents.Text = string.Empty;
            this.TextBoxAuthor.Text = string.Empty;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Message> ListViewMessages_GetData()
        {
            var context = new SimpleChatEntities();
            return context.Messages
                .OrderByDescending(m => m.Timestamp)
                .Take(100);
        }
    }
}