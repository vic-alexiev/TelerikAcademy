using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BasiliskBugTracker.WebClient.Models
{
    public class BugViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date discovered")]
        //[DataType(DataType.DateTime)]
        public DateTime DateDiscovered { get; set; }

        [Display(Name = "Owner")]
        public UserInProjectViewModel Owner { get; set; }

        [Display(Name = "Assigned to")]
        public UserInProjectViewModel AssignedTo { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(100, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        public ExistingProjectViewModel Project { get; set; }

        public IEnumerable<string> Attachments { get; set; }

        [UIHint("Priority")]
        public Priority Priority { get; set; }

        [UIHint("Status")]
        public Status Status { get; set; }

        public string StatusName
        {
            get
            {
                return Enum.GetName(typeof(Status), this.Status);
            }
        }

        public static Expression<Func<Bug, BugViewModel>> FromBug
        {
            get
            {
                return bug => new BugViewModel()
                {
                    Id = bug.Id,
                    Title = bug.Title,
                    AssignedTo = new UserInProjectViewModel
                    {
                        Id = bug.AssignedTo.Id,
                        Name = bug.AssignedTo.Name
                    },
                    DateDiscovered = bug.DateDiscovered,
                    Description = bug.Description,
                    Owner = new UserInProjectViewModel
                    {
                        Id = bug.Owner.Id,
                        Name = bug.Owner.Name
                    },
                    Priority = bug.Priority,
                    Project = new ExistingProjectViewModel()
                    {
                        Id = bug.Project.Id,
                        Name = bug.Project.Name
                    },
                    Status = bug.Status,
                    Attachments = (from atachment in bug.Attachments
                                   select atachment.PhysicalPath)
                };
            }
        }
    }
}