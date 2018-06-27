using BasiliskBugTracker.Models;
using BasiliskBugTracker.WebClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Models
{
    public class ProjectViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        public int BugsCount { get; set; }

        public UserInProjectViewModel Manager { get; set; }

        [UIHint("Contributors")]
        public IEnumerable<UserInProjectViewModel> Contributors { get; set; }


        public static Expression<Func<Project, ProjectViewModel>> FromProject
        {
            get
            {
                return project => new ProjectViewModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    Manager = new UserInProjectViewModel
                    {
                        Id = project.Manager.Id,
                        Name = project.Manager.Name
                    },
                    Contributors = project.Contributors.AsQueryable().Select(UserInProjectViewModel.FromUser),
                    BugsCount = project.Bugs.Count
                };
            }
        }

        public static ProjectViewModel ConvertFrom(Project project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Manager = new UserInProjectViewModel
                {
                    Id = project.Manager.Id,
                    Name = project.Manager.Name
                },
                Contributors = project.Contributors.AsQueryable().Select(UserInProjectViewModel.FromUser),
                BugsCount = project.Bugs.Count
            };
        }
    }
}