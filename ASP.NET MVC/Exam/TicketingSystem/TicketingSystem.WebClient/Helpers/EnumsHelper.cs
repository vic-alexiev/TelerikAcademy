using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketingSystem.WebClient.Helpers
{
    public static class EnumsHelper
    {
        public static List<SelectListItem> EnumToDropDownList(Type enumType)
        {
            return Enum
              .GetValues(enumType)
              .Cast<int>()
              .Select(i => new SelectListItem
              {
                  Value = i.ToString(),
                  Text = Enum.GetName(enumType, i)
              })
              .ToList();
        }
    }
}