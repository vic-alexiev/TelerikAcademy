using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using OnlineDatingSystem.Data;
using OnlineDatingSystem.Models;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace OnlineDatingSystem
{
    public partial class _Default : Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Redirect();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGridView();

                this.DropDownListCityFilter.DataSource = context.Cities.ToList();
                this.DropDownListCityFilter.DataBind();
                this.DropDownListCityFilter.Items.Insert(0, new ListItem("All", "0"));
                this.DropDownListCityFilter.SelectedValue = "0";
            }
        }

        protected void LinkButtonApplyFilter_Click(object sender, EventArgs e)
        {
            this.ApplyFilter();
        }

        protected void LinkButtonRemoveFilter_Click(object sender, EventArgs e)
        {
            this.BindGridView();
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewUsers.PageIndex = e.NewPageIndex;
            this.BindGridView();
        }

        protected int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        private async void Redirect()
        {
            AuthenticationIdentityManager manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            var userId = User.Identity.GetUserId();
            var roles = await manager.Roles.GetRolesForUserAsync(userId);
            if (roles.Any(r => r.Name == "Administrator"))
            {
                Response.Redirect("~/Administrator/AdministratorDefault.aspx");
            }
        }

        private void ApplyFilter()
        {
            string loggedUserId = User.Identity.GetUserId();

            var filteredUsers = context.Users
                .Where(u => u.Id != loggedUserId)
                .Include(u => u.City.Country);

            int cityFilter = int.Parse(this.DropDownListCityFilter.SelectedValue);

            filteredUsers = filteredUsers.Where(u => u.City.Id == cityFilter || cityFilter == 0);

            string sexFilter = this.DropDownListSexFilter.SelectedValue;

            filteredUsers = filteredUsers.Where(u => u.Sex == sexFilter || sexFilter == "A");

            string fromAgeAsString = this.TextBoxAgeFilterFrom.Text;
            string toAgeAsString = this.TextBoxAgeFilterTo.Text;

            if (!string.IsNullOrEmpty(fromAgeAsString) &&
                !string.IsNullOrEmpty(toAgeAsString))
            {
                int fromAge = int.Parse(this.TextBoxAgeFilterFrom.Text);
                int toAge = int.Parse(this.TextBoxAgeFilterTo.Text);

                filteredUsers = filteredUsers.Where(
                    u => fromAge <= DateTime.Today.Year - u.BirthDate.Year &&
                        DateTime.Today.Year - u.BirthDate.Year <= toAge);
            }

            this.GridViewUsers.DataSource = filteredUsers.ToList();
            this.GridViewUsers.DataBind();
        }

        private void BindGridView()
        {
            string loggedUserId = User.Identity.GetUserId();

            this.GridViewUsers.DataSource = context.Users
                .Where(u => u.Id != loggedUserId)
                .Include(u => u.City.Country)
                .ToList();
            this.GridViewUsers.DataBind();
        }
    }
}