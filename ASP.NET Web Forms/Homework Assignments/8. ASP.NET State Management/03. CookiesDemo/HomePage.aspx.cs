using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiesDemo
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie == null)
            {
                Response.Redirect("~/LoginForm.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelInfo.Text = "User is logged in. Cookie: " + Request.Cookies["User"].Value;
        }
    }
}