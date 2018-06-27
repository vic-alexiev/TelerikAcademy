using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BasiliskBugTracker.WebClient.Models
{
    public class UserInProjectViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public static Expression<Func<ApplicationUser, UserInProjectViewModel>> FromUser
        {
            get
            {
                return user => new UserInProjectViewModel()
                {
                    Id = user.Id,
                    Name = user.Name
                };
            }
        }
    }
}
