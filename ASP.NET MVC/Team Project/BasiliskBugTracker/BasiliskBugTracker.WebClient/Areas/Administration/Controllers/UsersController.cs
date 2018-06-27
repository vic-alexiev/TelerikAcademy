using BasiliskBugTracker.Data;
using BasiliskBugTracker.Models;
using BasiliskBugTracker.WebClient.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BasiliskBugTracker.WebClient.Controllers;
using BasiliskBugTracker.WebClient.Areas.Administration.Models;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : BaseController
    {
        public UsersController()
            : base()
        {
            IdentityManager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
        }

        public UsersController(AuthenticationIdentityManager manager)
        {
            IdentityManager = manager;
        }

        public AuthenticationIdentityManager IdentityManager { get; private set; }

        private Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUsers([DataSourceRequest] DataSourceRequest request)
        {
            var users = this.Data.GetRepository<ApplicationUser>().All().Include(u => u.Roles).Select(UserViewModel.FromUser);
            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRoles([DataSourceRequest] DataSourceRequest request)
        {
            var usersRoles = this.Data.GetRepository<Role>().All().Select(RoleViewModel.FromRole);
            return Json(usersRoles, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                var currentUser = this.Data.GetRepository<ApplicationUser>().All().FirstOrDefault(u => u.Id == user.Id);
                currentUser.IsDeleted = true;
                this.Data.GetRepository<ApplicationUser>().Update(currentUser);
                this.Data.Save();
            }

            return Json(new[] { user }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var newRoles = new List<UserRole>();

            if (user != null && ModelState.IsValid)
            {
                var currentUser = this.Data
                    .GetRepository<ApplicationUser>()
                    .All()
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Id == user.Id);

                if (user.Roles != null)
                {
                    foreach (var role in user.Roles)
                    {
                        string current = role.Id;
                        var currentRole = this.Data
                            .GetRepository<Role>()
                            .All()
                            .FirstOrDefault(r => r.Id == current);

                        var newUserRole = new UserRole()
                        {
                            Role = currentRole,
                            RoleId = currentRole.Id,
                            User = currentUser,
                            UserId = currentUser.Id
                        };

                        newRoles.Add(newUserRole);
                    } 
                }

                currentUser.IsDeleted = user.IsDeleted;
                currentUser.UserName = user.UserName;
                currentUser.Name = user.Name;
                currentUser.Phone = user.Phone;
                currentUser.Email = user.Email;
                currentUser.Roles = newRoles;
                this.Data.GetRepository<ApplicationUser>().Update(currentUser);
                this.Data.Save();
                user = UserViewModel.ConvertFrom(currentUser);
            }

            return Json(new[] { user }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterUserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    IsDeleted = model.IsDeleted,
                    Name = model.Name,
                    Phone = model.Phone
                };

                var result = await IdentityManager.Users.CreateLocalUserAsync(user, model.Password);
                if (result.Success)
                {
                    foreach (var roleId in model.Roles)
                    {
                        IdentityResult addToRoleResult = await IdentityManager.Roles.AddUserToRoleAsync(user.Id, roleId);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }

            return PartialView("_CreateUser", new RegisterUserViewModel());
        }

        public ActionResult CreateUser([DataSourceRequest] DataSourceRequest request)
        {
            return PartialView("_CreateUser", new RegisterUserViewModel());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && IdentityManager != null)
            {
                IdentityManager.Dispose();
                IdentityManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUrl)
            {
                LoginProvider = provider;
                RedirectUrl = redirectUrl;
            }

            public string LoginProvider { get; set; }
            public string RedirectUrl { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties() { RedirectUrl = RedirectUrl }, LoginProvider);
            }
        }
        #endregion
    }
}