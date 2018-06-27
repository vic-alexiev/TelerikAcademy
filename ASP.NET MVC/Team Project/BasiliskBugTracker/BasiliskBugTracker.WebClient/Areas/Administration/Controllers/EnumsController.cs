using BasiliskBugTracker.Models;
using BasiliskBugTracker.WebClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BasiliskBugTracker.WebClient.Areas.Administration.Controllers
{
    public class EnumsController : BaseController
    {
        [NonAction]
        public static List<SelectListItem> EnumToDropDownList(Type enumType)
        {
            return Enum
              .GetValues(enumType)
              .Cast<int>()
              .Select(i => new SelectListItem
                {
                    Value = i.ToString(),
                    Text = Enum.GetName(enumType, i),
                }
              )
              .ToList();
        }
    }
}
