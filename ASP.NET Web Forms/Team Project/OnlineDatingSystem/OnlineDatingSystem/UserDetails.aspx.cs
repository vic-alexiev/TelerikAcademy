using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;
using Microsoft.AspNet.Identity;
using OnlineDatingSystem.Data;
using OnlineDatingSystem.Models;

namespace OnlineDatingSystem
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var userId = Request.Params["id"];
            if (userId == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (userId != User.Identity.GetUserId())
            {
                var editButton = (this.UserDetailsFormView.FindControl("EditUserDetailsButton") as LinkButton);
                editButton.Visible = false;

                var uploadImageContainer = (this.UserDetailsFormView.FindControl("FileUploadContainer") as Panel);
                uploadImageContainer.Visible = false;
            }
        }

        public ApplicationUser UserDetailsFormView_GetUserInfo()
        {
            var userId = Request.Params["id"];
            ApplicationUser user = new ApplicationUser();
            if (userId == null)
            {
                //TODO: maybe redirect
            }
            else
            {
                ApplicationDbContext context = new ApplicationDbContext();

                user = context.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                {
                    throw new ArgumentException("User not in db");
                }
                else
                {
                    //
                }
            }

            return user;
        }

        public void UserDetailsFormView_UpdateUserInfo(string Id)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var user = context.Users.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                //TODO: User with id <edi-kakvo-si> was not found!
                return;
            }

            try
            {
                var countryDropDown = (this.UserDetailsFormView.FindControl("EditCountryTb") as DropDownList);
                var selectedCountryId = Convert.ToInt32(countryDropDown.SelectedValue);
                user.Country = context.Countries.FirstOrDefault(x => x.Id == selectedCountryId);

                var cityDropDown = (this.UserDetailsFormView.FindControl("EditCityTb") as DropDownList);
                var selectedCityId = Convert.ToInt32(cityDropDown.SelectedValue);
                user.City = context.Cities.FirstOrDefault(x => x.Id == selectedCityId);

                var educationDropDown = (this.UserDetailsFormView.FindControl("EditEducationTb") as DropDownList);
                var selectedEducationId = Convert.ToInt32(educationDropDown.SelectedValue);
                user.Education = context.EducationTypes.FirstOrDefault(x => x.Id == selectedEducationId);

                var reasonDropDown = (this.UserDetailsFormView.FindControl("EditReasonTb") as DropDownList);
                var selectedReasonId = Convert.ToInt32(reasonDropDown.SelectedValue);
                user.Reason = context.Reasons.FirstOrDefault(x => x.Id == selectedReasonId);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            TryUpdateModel(user);

            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        protected void UploadProfileImage_OnClick(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userId = Request.Params["id"];
            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("User not in db");
            }

            FileUpload upload = (FileUpload)UserDetailsFormView.FindControl("ProfilePhotoFileUpload");
            if (upload.HasFile)
            {
                user.Photo = null;
                user.Photo = this.GetUploadedFile(upload.PostedFile);
            }
            context.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        private byte[] GetUploadedFile(HttpPostedFile postedFile)
        {
            if (postedFile != null)
            {
                //Create byte Array with file len
                byte[] data = new Byte[postedFile.ContentLength];

                //force the control to load data in array
                postedFile.InputStream.Read(data, 0, postedFile.ContentLength);

                return data;
            }

            return null;
        }

        protected void UserDetailsFormView_PreEditCommand(object sender, EventArgs eventArgs)
        {
            if (this.UserDetailsFormView.CurrentMode == FormViewMode.Edit)
            {
                var userId = Request.Params["id"];
                var countryDropDown = (this.UserDetailsFormView.FindControl("EditCountryTb") as DropDownList);
                var cityDropDown = (this.UserDetailsFormView.FindControl("EditCityTb") as DropDownList);
                var educationDropDown = (this.UserDetailsFormView.FindControl("EditEducationTb") as DropDownList);
                var reasonDropDown = (this.UserDetailsFormView.FindControl("EditReasonTb") as DropDownList);

                ApplicationDbContext context = new ApplicationDbContext();
                var currentUser = context.Users.Include("City").Include("Country").Include("Education").FirstOrDefault(x => x.Id == userId);

                countryDropDown.DataSource = context.Countries.ToList();
                countryDropDown.SelectedValue = currentUser.Country.Id.ToString();
                countryDropDown.DataBind();

                int selectedCountryId = int.Parse(countryDropDown.SelectedValue);
                cityDropDown.DataSource = context.Cities.ToList();
                cityDropDown.SelectedValue = currentUser.City.Id.ToString();
                cityDropDown.DataBind();

                educationDropDown.DataSource = context.EducationTypes.ToList();
                educationDropDown.SelectedValue = currentUser.Education.Id.ToString();
                educationDropDown.DataBind();

                reasonDropDown.DataSource = context.Reasons.ToList();
                reasonDropDown.SelectedValue = currentUser.Reason.Id.ToString();
                reasonDropDown.DataBind();
            }
        }

        protected void EditCountryTb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var countryDropDown = (this.UserDetailsFormView.FindControl("EditCountryTb") as DropDownList);
            var cityDropDown = (this.UserDetailsFormView.FindControl("EditCityTb") as DropDownList);

            ApplicationDbContext context = new ApplicationDbContext();
            var selectedCountryId = int.Parse(countryDropDown.SelectedValue);
            cityDropDown.DataSource = context.Cities.Include("Country").Where(x => x.Country.Id == selectedCountryId).ToList();
            cityDropDown.DataBind();
        }
    }
}