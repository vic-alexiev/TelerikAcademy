using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using OnlineDatingSystem.Data;
using OnlineDatingSystem.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Drawing;

namespace OnlineDatingSystem.Account
{
    public partial class Register : Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DropDownListCountry.DataSource = context.Countries.ToList();
                this.DropDownListCountry.DataValueField = "Id";
                this.DropDownListCountry.DataTextField = "Name";

                this.DropDownListEducation.DataSource = context.EducationTypes.ToList();
                this.DropDownListEducation.DataValueField = "Id";
                this.DropDownListEducation.DataTextField = "Name";

                this.SetInterests(context.Interests);

                this.DropDownListReason.DataSource = context.Reasons.ToList();
                this.DropDownListReason.DataValueField = "Id";
                this.DropDownListReason.DataTextField = "Name";

                this.DataBind();

                this.DropDownListCountry_SelectedIndexChanged(DropDownListCountry, EventArgs.Empty);
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            var userDto = new UserDto();

            userDto.Username = this.TextBoxUserName.Text.Trim();
            userDto.Password = this.TextBoxPassword.Text.Trim();
            userDto.FirstName = this.TextBoxFirstName.Text.Trim();
            userDto.LastName = this.TextBoxLastName.Text.Trim();
            userDto.Email = this.TextBoxEmail.Text.Trim();
            userDto.Phone = this.TextBoxPhone.Text.Trim();
            userDto.BirthDate = DateTime.Parse(this.TextBoxBirthDate.Text);
            userDto.CountryId = int.Parse(this.DropDownListCountry.SelectedValue);
            userDto.CityId = int.Parse(this.DropDownListCity.SelectedValue);
            userDto.Sex = this.DropDownListSex.SelectedValue;
            userDto.LookingFor = this.DropDownListLookingFor.SelectedValue;
            userDto.EducationTypeId = int.Parse(this.DropDownListEducation.SelectedValue);
            userDto.Description = this.TextBoxDescription.Text;

            userDto.Photo = null;
            if (this.FileUploadPhoto.HasFile)
            {
                userDto.Photo = this.GetUploadedFile(this.FileUploadPhoto.PostedFile);
            }

            userDto.InterestIds = new List<int>();

            foreach (ListItem item in this.CheckBoxListInterests.Items)
            {
                if (item.Selected)
                {
                    userDto.InterestIds.Add(int.Parse(item.Value));
                }
            }

            userDto.ReasonId = int.Parse(this.DropDownListReason.SelectedValue);

            this.CreateUser(userDto);
        }

        protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountryIdAsString = this.DropDownListCountry.SelectedValue;
            if (!string.IsNullOrWhiteSpace(selectedCountryIdAsString))
            {
                int selectedCountryId = int.Parse(selectedCountryIdAsString);
                this.DropDownListCity.DataSource = context.Cities
                    .Include(ct => ct.Country)
                    .Where(c => c.Country.Id == selectedCountryId).ToList();

                this.DropDownListCity.DataValueField = "Id";
                this.DropDownListCity.DataTextField = "Name";

                this.DropDownListCity.DataBind();
            }
        }

        private async void CreateUser(UserDto userDto)
        {
            var country = context.Countries.FirstOrDefault(c => c.Id == userDto.CountryId);
            if (country == null)
            {
                ErrorMessage.Text = "No country found with id=" + userDto.CountryId;
                return;
            }

            var city = context.Cities.FirstOrDefault(c => c.Id == userDto.CityId);
            if (city == null)
            {
                ErrorMessage.Text = "No city found with id=" + userDto.CityId;
                return;
            }

            var educationType = context.EducationTypes.FirstOrDefault(et => et.Id == userDto.EducationTypeId);
            if (educationType == null)
            {
                ErrorMessage.Text = "No education type found with id=" + userDto.EducationTypeId;
                return;
            }

            var reason = context.Reasons.FirstOrDefault(r => r.Id == userDto.ReasonId);
            if (reason == null)
            {
                ErrorMessage.Text = "No reason found with id=" + userDto.ReasonId;
                return;
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Phone = userDto.Phone,
                BirthDate = userDto.BirthDate,
                Country = country,
                City = city,
                Sex = userDto.Sex,
                LookingFor = userDto.LookingFor,
                Education = educationType,
                Description = userDto.Description,
                Photo = userDto.Photo,
                Reason = reason
            };

            foreach (int interestId in userDto.InterestIds)
            {
                var interest = context.Interests.FirstOrDefault(i => i.Id == interestId);
                if (interest == null)
                {
                    ErrorMessage.Text = "No interest found with id=" + interestId;
                    return;
                }

                user.Interests.Add(interest);
            }

            var manager = new AuthenticationIdentityManager(new IdentityStore(context));

            var role = await manager.Roles.FindRoleByNameAsync("Registered user");
            if (role == null)
            {
                ErrorMessage.Text = "Role \"Registered user\" missing.";
                return;
            }

            IdentityResult result = manager.Users.CreateLocalUser(user, userDto.Password);
            if (result.Success)
            {
                IdentityResult addToRoleResult = await manager.Roles.AddUserToRoleAsync(user.Id, role.Id);
                if (addToRoleResult.Success)
                {
                    manager.Authentication.SignIn(Context.GetOwinContext().Authentication, user.Id, isPersistent: false);
                    OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = addToRoleResult.Errors.FirstOrDefault();
                }
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
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

        private void SetInterests(DbSet<Interest> interests)
        {
            foreach (var interest in interests)
            {
                this.CheckBoxListInterests.Items.Add(
                    new ListItem(interest.Name, interest.Id.ToString()));
            }
        }
    }
}