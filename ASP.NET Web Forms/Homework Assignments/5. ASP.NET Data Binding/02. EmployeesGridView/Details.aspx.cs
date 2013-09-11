using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesGridView
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
            }

            string id = this.Request.Params["id"];

            if (!string.IsNullOrWhiteSpace(id))
            {
                int employeeId = int.Parse(id);
                using (var context = new NorthwindEntities())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.EmployeeID == employeeId);
                    if (employee != null)
                    {
                        this.DetailsViewEmployee.DataSource = new List<Employee>() { employee };
                        this.DetailsViewEmployee.DataBind();
                    }
                }
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }
    }
}