using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using WebChat.Data;
using WebChat.Models;

namespace WebChat.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = TextBoxUserName.Text.Trim();
            string password = TextBoxPassword.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string lastName = TextBoxLastName.Text.Trim();
            string email = TextBoxEmail.Text.Trim();

            this.CreateUser(userName, password, firstName, lastName, email);
        }

        private async void CreateUser(string userName, string password, string firstName, string lastName, string email)
        {
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));

            var role = await manager.Roles.FindRoleByNameAsync("Registered user");
            if (role == null)
            {
                ErrorMessage.Text = "Role \"Registered user\" missing.";
                return;
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            IdentityResult result = manager.Users.CreateLocalUser(user, password);
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
    }
}