using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

class DatesExtractor
{
    private static List<DateTime> GetDates(string input)
    {
        string pattern = @"\b(?<day>0?\d|1\d|2\d|3[01])\.(?<month>0?\d|1[012])\.(?<year>\d{4})\b";

        MatchCollection matches = Regex.Matches(input, pattern);

        List<DateTime> dates = new List<DateTime>();

        foreach (Match match in matches)
        {
            dates.Add(new DateTime(
                Int32.Parse(match.Groups["year"].Value),
                Int32.Parse(match.Groups["month"].Value),
                Int32.Parse(match.Groups["day"].Value)));
        }

        return dates;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");

        string text = "I was born on 14.06.1980. You were born on 3.7.1891." +
            "In 8/2000 we were at the seaside. For further information, see [7.2.5.11].";

        List<DateTime> datesList = GetDates(text);

        Console.WriteLine("Dates:");

        foreach (DateTime date in datesList)
        {
            Console.WriteLine("{0:yyyy/MM/dd}", date);
        }
    }
}
