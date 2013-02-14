using System;
using System.Globalization;
using System.Linq;

class CalculateWorkdays
{
    // these are the Saturdays of 2013 which are officially declared workdays
    private static DateTime[] specialWorkdays2013 =
    {
        new DateTime(2013, 5, 11),
        new DateTime(2013, 12, 14)
    };

    private static DateTime[] nationalHolidays2013 =
    {
        new DateTime(2013, 1, 1),
        new DateTime(2013, 3, 3),
        new DateTime(2013, 5, 1),
        new DateTime(2013, 5, 2),
        new DateTime(2013, 5, 3),
        new DateTime(2013, 5, 4),
        new DateTime(2013, 5, 5),
        new DateTime(2013, 5, 6),
        new DateTime(2013, 5, 24),
        new DateTime(2013, 9, 6),
        new DateTime(2013, 9, 22),
        new DateTime(2013, 12, 24),
        new DateTime(2013, 12, 25),
        new DateTime(2013, 12, 26),
        new DateTime(2013, 12, 31)
    };

    private static bool IsWorkday(DateTime date)
    {
        return date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday;
    }

    static void Main()
    {
        string userInput;
        DateTime futureDate;
        DateTime today = DateTime.Today;

        do
        {
            Console.Write("Enter a future date during this year (dd.MM.yyyy): ");
            userInput = Console.ReadLine();
        }
        while (!DateTime.TryParseExact(userInput, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out futureDate)
            || futureDate <= today || futureDate.Year != 2013);

        DateTime currentDate = today;

        int count = 0;

        do
        {
            currentDate = currentDate.AddDays(1);

            if (IsWorkday(currentDate) && !nationalHolidays2013.Contains(currentDate)
                || specialWorkdays2013.Contains(currentDate))
            {
                count++;
            }
        }
        while (currentDate < futureDate);

        Console.WriteLine("There are {0} work days until {1:dd.MM.yyyy} (including).", count, futureDate);
    }
}
