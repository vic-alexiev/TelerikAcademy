using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Role, RoleViewModel>> FromRole
        {
            get
            {
                return role => new RoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name
                };
            }
        }

        public static Expression<Func<UserRole, RoleViewModel>> FromUserRole
        {
            get
            {
                return userRole => new RoleViewModel()
                {
                    Id = userRole.RoleId,
                    Name = userRole.Role.Name
                };
            }
        }
    }
}