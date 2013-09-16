using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientInfoExtractor
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralOutput.Text += "<strong>Browser Type: </strong>" + Request.Browser.Type + "<br />";
            LiteralOutput.Text += "<strong>Client IP Address: </strong>" + Request.UserHostAddress + "<br />";
        }
    }
}