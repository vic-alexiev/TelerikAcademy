using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasiliskBugTracker.WebClient.Models
{
    public class ChartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BugGroupViewModel> Bugs { get; set; }
    }
}