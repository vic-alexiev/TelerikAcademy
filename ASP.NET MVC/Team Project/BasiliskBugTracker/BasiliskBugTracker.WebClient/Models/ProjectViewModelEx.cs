using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasiliskBugTracker.WebClient.Areas.Administration.Models;
using BasiliskBugTracker.Models;
using System.Linq.Expressions;

namespace BasiliskBugTracker.WebClient.Models
{
    public class ProjectViewModelEx : ProjectViewModel
    {
        public IEnumerable<string> Bugs { get; set; }

        public static Expression<Func<Project, ProjectViewModelEx>> CreateFromProject
        {
            get
            {
                return project => new ProjectViewModelEx
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    Contributors = project.Contributors.AsQueryable().Select(UserViewModel.FromUser),
                    BugsCount = project.Bugs.Count,
                    Bugs = project.Bugs.AsQueryable().Select(b => b.Title),
                    Manager = new UserInProjectViewModel
                    {
                        Id = project.Manager.Id,
                        Name = project.Manager.Name
                    }
                };
            }
        }
    }
}