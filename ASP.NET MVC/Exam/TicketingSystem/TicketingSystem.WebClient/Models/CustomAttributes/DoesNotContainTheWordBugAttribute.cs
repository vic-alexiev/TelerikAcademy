using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketingSystem.WebClient.Models.CustomAttributes
{
    public class DoesNotContainTheWordBugAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;
            }

            return !valueAsString.Contains("bug");
        }
    }
}