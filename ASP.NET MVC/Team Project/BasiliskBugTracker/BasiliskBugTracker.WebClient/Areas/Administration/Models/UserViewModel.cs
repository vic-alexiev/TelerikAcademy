using BasiliskBugTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Web;
using BasiliskBugTracker.WebClient.Models;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Models
{
    public class UserViewModel : UserInProjectViewModel
    {
        [UIHint("Roles")]
        public IEnumerable<RoleViewModel> Roles { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter valid phone number")]
        public string Phone { get; set; }

        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> FromUser
        {
            get
            {
                return user => new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    IsDeleted = user.IsDeleted,
                    Name = user.Name,
                    Phone = user.Phone,
                    UserName = user.UserName,
                    Roles = user.Roles.AsQueryable().Select(RoleViewModel.FromUserRole).ToList()
                };
            }
        }

        public static UserViewModel ConvertFrom(ApplicationUser user)
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                IsDeleted = user.IsDeleted,
                Name = user.Name,
                Phone = user.Phone,
                UserName = user.UserName,
                Roles = user.Roles.AsQueryable().Select(RoleViewModel.FromUserRole).ToList()
            };

            return userViewModel;
        }
    }
}