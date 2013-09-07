using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloASP.NET
{
    public partial class HelloASP_NET : System.Web.UI.Page
    {
        protected void ButtonSayHello_Click(object sender, EventArgs e)
        {
            this.LabelGreeting.Text = string.Format("Hello, {0}", Server.HtmlEncode(TextBoxName.Text));
        }
    }
}