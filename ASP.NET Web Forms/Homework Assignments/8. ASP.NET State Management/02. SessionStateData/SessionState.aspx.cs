using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionStateData
{
    /// <summary>
    /// http://www.youtube.com/watch?v=Lvt1BnSwRvo 
    /// </summary>
    public partial class SessionState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Clicks"] == null)
                {
                    Session["Clicks"] = new List<string>();
                }

                LabelSessionContents.Text =
                    "<strong>Session contents:</strong><br />" +
                    string.Join("<br />", Session["Clicks"] as List<string>);
            }
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            (Session["Clicks"] as List<string>).Add(TextBoxInput.Text);

            LabelSessionContents.Text =
                "<strong>Session contents:</strong><br />" +
                string.Join("<br />", Session["Clicks"] as List<string>);
        }
    }
}