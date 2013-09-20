using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesOrders
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
        }
    }
}