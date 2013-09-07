using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.GetExecutingPath
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello, ASP.NET from the code-behind.");
        }

        protected string GetExecutingPath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
}