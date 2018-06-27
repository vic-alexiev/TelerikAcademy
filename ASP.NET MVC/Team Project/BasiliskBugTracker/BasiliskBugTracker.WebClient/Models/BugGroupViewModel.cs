using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasiliskBugTracker.WebClient.Models
{
    public class BugGroupViewModel
    {
        private static Random randomGenerator = new Random();

        private string _color;
        public string category
        {
            get
            {
                return this.Status.ToString();
            }
        }

        public double value
        {
            get
            {
                return this.Count;
            }
        }

        public string color
        {
            get
            {
                switch (this.category)
                {
                    case "New":
                        this._color = "#9de219";
                        break;
                    case "InProgress":
                        this._color = "#90cc38";
                        break;
                    case "Fixed":
                        this._color = "#068c35";
                        break;
                    case "Closed":
                        this._color = "#006634";
                        break;
                    case "Deleted":
                        this._color = "#033939";
                        break;
                }

                return this._color;
            }
        }

        public Status Status { get; set; }

        public int Count { get; set; }
    }
}