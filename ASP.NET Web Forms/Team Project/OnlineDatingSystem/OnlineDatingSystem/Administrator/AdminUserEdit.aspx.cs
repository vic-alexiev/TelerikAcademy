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
using OnlineDatingSystem.Account;
using System.Text.RegularExpressions;
using Error_Handler_Control;

namespace OnlineDatingSystem.Administrator
{
    public partial class AdminUserEdit : System.Web.UI.Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        private string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.userId = Request.Params["userId"];

                if (this.userId == null)
                {
                    Response.Redirect("AdministratorDefault.aspx");
                    return;
                }

                InitDropDownLists();

                FillCurrentUserData();

                this.DropDownListCountry_SelectedIndexChanged(this.DropDownListCountry, null);
            }
        }

        protected void ChangeUser_Click(object sender, EventArgs e)
        {
            if(!ValidateInputs())
            {
                // some of the validation failed
                return;
            }

            try
            {
                var user = LoadUserData();

                this.GetPhoto(user);

                this.GetIterests(this.context, user);

                this.AddDropDownData(user);

                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        #region Init methods
        private void InitDropDownLists()
        {
            this.DropDownListCountry.DataSource = context.Countries.ToList();
            this.DropDownListCountry.SelectedIndexChanged += this.DropDownListCountry_SelectedIndexChanged;
            this.DropDownListCountry.DataValueField = "Id";
            this.DropDownListCountry.DataTextField = "Name";

            this.DropDownListEducation.DataSource = context.EducationTypes.ToList();
            this.DropDownListEducation.DataValueField = "Id";
            this.DropDownListEducation.DataTextField = "Name";

            this.SetInterests(context.Interests);

            this.DropDownListReason.DataSource = context.Reasons.ToList();
            this.DropDownListReason.DataValueField = "Id";
            this.DropDownListReason.DataTextField = "Name";

            this.DropDownListCity.DataSource = context.Cities.ToList();
            this.DropDownListCity.DataValueField = "Id";
            this.DropDownListCity.DataTextField = "Name";

            this.DropDownListRole.DataSource = context.Roles.ToList();
            this.DataBind();
        }

        private void FillCurrentUserData()
        {
            var user = this.context.Users
                .Include(u => u.Roles)
                .Include(u => u.City)
                .Include(u => u.Country)
                .Include(u => u.Education)
                .Include(u => u.Interests)
                .Include(u => u.Reason)
                .FirstOrDefault(u => u.Id == this.userId);

            this.DropDownListRole.SelectedValue = user.Roles.First().RoleId;
            this.DropDownListCity.SelectedValue = user.City.Id.ToString();
            this.DropDownListCountry.SelectedValue = user.Country.Id.ToString();

            this.DropDownListEducation.SelectedValue = user.Education.Id.ToString();
            this.DropDownListReason.SelectedValue = user.Reason.Id.ToString();

            foreach (ListItem item in this.CheckBoxListInterests.Items)
            {
                if (user.Interests.Any(i => item.Value == i.Id.ToString()))
                {
                    item.Selected = true;
                }
            }

            this.DropDownListReason.SelectedValue = user.Reason.Id.ToString();
            this.DropDownListSex.SelectedValue = user.Sex;
            this.DropDownListLookingFor.SelectedValue = user.LookingFor;


            this.TextBoxUserName.Text = user.UserName;
            this.TextBoxFirstName.Text = user.FirstName;
            this.TextBoxLastName.Text = user.LastName;
            this.TextBoxEmail.Text = user.Email;
            this.TextBoxDescription.Text = user.Description;
            this.TextBoxPhone.Text = user.Phone;
            this.TextBoxBirthDate.Text = user.BirthDate.ToString("dd-MM-yyyy");
            
        } 
        #endregion

        #region Edit user methods
        private ApplicationUser LoadUserData()
        {
            var userId = Request.Params["userId"];

            if (userId == null)
            {
                Response.Redirect("AdministratorDefault.aspx");
            }

            var user = this.context.Users.Find(userId);

            user.UserName = this.TextBoxUserName.Text.Trim();
            user.FirstName = this.TextBoxFirstName.Text.Trim();
            user.LastName = this.TextBoxLastName.Text.Trim();
            user.Email = this.TextBoxEmail.Text.Trim();
            user.Phone = this.TextBoxPhone.Text.Trim();
            user.BirthDate = DateTime.Parse(this.TextBoxBirthDate.Text);
            user.Sex = this.DropDownListSex.SelectedValue;
            user.LookingFor = this.DropDownListLookingFor.SelectedValue;
            user.Description = this.TextBoxDescription.Text;

            return user;
        }

        private void AddDropDownData(ApplicationUser user)
        {
            UpdateCountry(user);

            UpdateCity(user);

            UpdateEducation(user);

            UpdateReason(user);

            var roleId = this.DropDownListRole.SelectedValue;

        }

        private void UpdateReason(ApplicationUser user)
        {
            int reasonId;
            if (!int.TryParse(this.DropDownListReason.SelectedValue, out reasonId))
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid Reason!");
                return;
            }

            if (reasonId == user.Reason.Id)
            {
                // not changed 
                return;
            }

            var reason = context.Reasons.FirstOrDefault(r => r.Id == reasonId);
            if (reason == null)
            {
                ErrorMessage.Text = "No such reason found!";
                return;
            }
            user.Reason = reason;
        }

        private void UpdateEducation(ApplicationUser user)
        {
            int educationId;
            if (!int.TryParse(this.DropDownListEducation.SelectedValue, out educationId))
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid Education Type!");
                return;
            }

            if (user.Education.Id == educationId)
            {
                // not changed
                return;
            }

            var educationType = this.context.EducationTypes
                .FirstOrDefault(et => et.Id == educationId);

            if (educationType == null)
            {
                ErrorMessage.Text = "No such education found";
                return;
            }
            user.Education = educationType;
        }

        private void UpdateCity(ApplicationUser user)
        {
            int cityId;
            if (!int.TryParse(this.DropDownListCity.SelectedValue, out cityId))
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid City!");
                return;
            }

            if (cityId == user.City.Id)
            {
                //not changed !
                return;
            }

            var city = context.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                ErrorMessage.Text = "No such city found!";
                return;
            }
            user.City = city;
        }

        private void UpdateCountry(ApplicationUser user)
        {
            int countryId;

            if (!int.TryParse(this.DropDownListCountry.SelectedValue, out countryId))
	        {
                ErrorSuccessNotifier.AddErrorMessage("Invalid Country!");
                return;
	        }

            if (countryId == user.Country.Id)
            {
                // not changed
                return;
            }

            var country = context.Countries.FirstOrDefault(c => c.Id == countryId);
            if (country == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("No such country found!");
                return;
            }

            user.Country = country;
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

        private void GetReasons(ApplicationDbContext dbContext, ApplicationUser user)
        {
            user.Reason = dbContext.Reasons
                .Find(int.Parse(this.DropDownListReason.SelectedValue));
        }

        private void SetInterests(DbSet<Interest> interests)
        {
            foreach (var interest in interests)
            {
                this.CheckBoxListInterests.Items.Add(
                    new ListItem(interest.Name, interest.Id.ToString()));
            }
        }

        private void GetIterests(ApplicationDbContext dbContext, ApplicationUser userDto)
        {
            var interestIds = new List<int>();

            foreach (ListItem item in this.CheckBoxListInterests.Items)
            {
                if (item.Selected)
                {
                    interestIds.Add(int.Parse(item.Value));
                }
            }

            userDto.Interests.Clear();
            var interests = dbContext.Interests
                .Where(i => interestIds.Contains(i.Id)).ToList();

            foreach (var interest in interests)
            {
                userDto.Interests.Add(interest);
            }
        }

        private void GetPhoto(ApplicationUser userDto)
        {
            userDto.Photo = null;
            if (this.FileUploadPhoto.HasFile)
            {
                userDto.Photo = this.GetUploadedFile(this.FileUploadPhoto.PostedFile);
            }
        } 
        #endregion

        #region Validation methods

        private bool ValidateInputs()
        {
            //ValidateUserName(this.TextBoxUserName.Text); //db validates it's length!
            var dateValid = ValidateDate(this.TextBoxBirthDate.Text);
            var phoneValid = ValidatePhone(this.TextBoxPhone.Text);

            return dateValid && phoneValid;
        }

        private bool ValidatePhone(string phone)
        {
            var phoneMatch = Regex.IsMatch(phone, @"^[\d]{5,15}$");
            if (!phoneMatch)
            {
                ErrorSuccessNotifier.AddErrorMessage("Phone must consist only of numbers. Allowed length 5 to 15 digits long!");
                //throw new ArgumentOutOfRangeException("Phone invalid");
            }

            return phoneMatch;
        }

        private bool ValidateDate(string dateText)
        {
            var validDate = Regex.IsMatch(dateText, @"^[\d]{1,2}-[\d]{1,2}-[\d]{4}$");
            if (!validDate)
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid Date string. Should be (dd-mm-yyyy) i.e. 10-24-1999");
                //throw new ArgumentOutOfRangeException("Date invalid");
            }

            var year = DateTime.Parse(dateText);
            if (year < new DateTime(1900,1,1) || year > DateTime.Now)
            {
                ErrorSuccessNotifier.AddErrorMessage("Birth date must be between 01-01-1900 and " + 
                    DateTime.Now.ToString("dd-MM-yyyy"));

                validDate = false;
            }
            return validDate;
        }

        #endregion

        protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var countriesDropDown = sender as DropDownList;
            var selected = countriesDropDown.SelectedValue;
            var countryId = Convert.ToInt32(selected);

            var dbContext = new ApplicationDbContext();
            var cities = 
                dbContext.Cities.Where(c => c.Country.Id == countryId).ToList();
            if (cities != null && cities.Count > 0)
            {
                this.DropDownListCity.DataSource = cities;
            }
            else
            {
                this.DropDownListCity.DataSource = new List<City> 
                { 
                    new City 
                    { 
                        Name = "No cities for this country!!!", 
                        Id = int.Parse(this.DropDownListCity.SelectedValue)
                    }
                };
            }
            this.DropDownListCity.DataBind();
            this.UpdatePanelCities.Update();
        }
    }
}
