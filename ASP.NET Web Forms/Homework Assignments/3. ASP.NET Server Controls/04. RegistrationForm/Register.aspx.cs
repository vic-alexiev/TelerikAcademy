using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class Register : System.Web.UI.Page
    {
        private static readonly Dictionary<string, List<string>> courses;
        private static readonly List<string> universities;

        static Register()
        {
            courses = LoadCourses();
            universities = LoadUniversities();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DropDownListUniversity.DataSource = universities;
                this.DropDownListUniversity.DataBind();

                this.DropDownListSpeciality.DataSource = courses.Keys;
                this.DropDownListSpeciality.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                var panelResult = this.FindControl("PanelResult");
                if (panelResult != null)
                {
                    this.Controls.Remove(panelResult);
                }

                return;
            }
            var panel = new Panel();
            panel.ID = "PanelResult";

            var heading = new HtmlGenericControl("h1");
            heading.InnerText = "Student Info";

            var paragraph = new HtmlGenericControl("p");
            paragraph.InnerHtml = string.Format(
                @"<strong>First Name: </strong>{0}<br />
                  <strong>Last Name: </strong>{1}<br />
                  <strong>Faculty Number: </strong>{2}<br />
                  <strong>University: </strong>{3}<br />
                  <strong>Speciality: </strong>{4}<br />
                  <strong>Courses:</strong><br />",
                this.TextBoxFirstName.Text,
                this.TextBoxLastName.Text,
                this.TextBoxFacultyNumber.Text,
                this.DropDownListUniversity.SelectedItem.Text,
                this.DropDownListSpeciality.SelectedItem.Text);

            foreach (var index in this.ListBoxCourses.GetSelectedIndices())
            {
                string item = this.ListBoxCourses.Items[index].Text;
                paragraph.InnerHtml += item + "<br />";
            }

            panel.Controls.Add(heading);
            panel.Controls.Add(paragraph);
            this.Controls.Add(panel);
        }

        protected void DropDownListSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = this.DropDownListSpeciality.SelectedItem.Text;
            this.ListBoxCourses.DataSource = courses[selectedItem];
            this.ListBoxCourses.DataBind();
        }

        private static List<string> LoadUniversities()
        {
            List<string> universities = new List<string>()
            {
                "",
                "Harvard University",
                "Princeton University",
                "Yale University",
                "Columbia University",
                "University of Chicago",
                "Massachusetts Institute of Technology",
                "Stanford University",
                "Duke University",
                "University of Pennsylvania",
                "California Institute of Technology"
            };

            return universities;
        }

        private static Dictionary<string, List<string>> LoadCourses()
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            courses.Add("", new List<string>());
            courses.Add("Accounting", new List<string>());
            courses.Add("Leadership", new List<string>());
            courses.Add("Human Resource Management", new List<string>());
            courses.Add("Project Management", new List<string>());

            courses["Accounting"].Add("Auditing");
            courses["Accounting"].Add("Financial Accounting");
            courses["Accounting"].Add("Fundamentals of Managerial Accounting");
            courses["Accounting"].Add("Tax Planning");
            courses["Accounting"].Add("Taxes and Business Strategy");

            courses["Leadership"].Add("Creativity");
            courses["Leadership"].Add("Innovation");
            courses["Leadership"].Add("Global Business");
            courses["Leadership"].Add("Leadership");
            courses["Leadership"].Add("Managerial Effectiveness");
            courses["Leadership"].Add("Marketing Research");

            courses["Human Resource Management"].Add("Business Policy");
            courses["Human Resource Management"].Add("Business Strategy");
            courses["Human Resource Management"].Add("Collecting Bargaining");
            courses["Human Resource Management"].Add("Compensation");
            courses["Human Resource Management"].Add("Benefits");
            courses["Human Resource Management"].Add("Employment Law");

            courses["Project Management"].Add("Contract Management");
            courses["Project Management"].Add("Producement Management");
            courses["Project Management"].Add("Managing Software Development Projects");
            courses["Project Management"].Add("Project Cost");
            courses["Project Management"].Add("Schedule Control");
            courses["Project Management"].Add("Managing Quality");

            return courses;
        }
    }
}