using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Models
{
    public class CreateProjectViewModel : ProjectViewModel
    {
        public new string Manager { get; set; }

        [UIHint("Contributors")]
        public new IEnumerable<string> Contributors { get; set; }

        public static new CreateProjectViewModel ConvertFrom(Project project)
        {
            return new CreateProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Contributors = project.Contributors.AsQueryable().Select(c => c.Id),
            };
        }
    }
}