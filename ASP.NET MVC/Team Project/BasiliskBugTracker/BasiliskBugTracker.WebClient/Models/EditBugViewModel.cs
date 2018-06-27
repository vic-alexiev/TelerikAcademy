using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasiliskBugTracker.WebClient.Models
{
    public class EditBugViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date discovered")]
        [DataType(DataType.DateTime)]
        public DateTime DateDiscovered { get; set; }

        public UserInProjectViewModel Owner { get; set; }

        [Display(Name = "Assigned to")]
        [UIHint("ProjectContributors")]
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

        public byte[] Attachment { get; set; }

        [UIHint("Priority")]
        public Priority Priority { get; set; }

        [UIHint("Status")]
        public Status Status { get; set; }
    }
}