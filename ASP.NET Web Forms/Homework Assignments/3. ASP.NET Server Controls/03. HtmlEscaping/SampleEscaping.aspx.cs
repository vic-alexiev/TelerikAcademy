using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlEscaping
{
    public partial class SampleEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            string input = this.TextBoxInput.Text;
            this.TextBoxOutput.Text = input;
            this.LabelOutput.Text = Server.HtmlEncode(input);
        }
    }
}