using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesGridView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var context = new NorthwindEntities())
                {
                    var employees = context.Employees.Select(emp => new
                    {
                        Id = emp.EmployeeID,
                        FullName = emp.FirstName + " " + emp.LastName
                    })
                    .ToList();

                    this.GridViewEmployees.DataSource = employees;
                    this.GridViewEmployees.DataBind();
                }
            }
        }
    }
}