using System;
using System.Globalization;

namespace DayOfWeekInBGService
{
    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDayOfWeek(DateTime date)
        {
            return date.ToString("dddd", new CultureInfo("bg-BG"));
        }
    }
}
