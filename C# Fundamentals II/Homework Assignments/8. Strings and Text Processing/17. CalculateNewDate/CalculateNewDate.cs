using System;
using System.Globalization;
using System.Threading;

class CalculateNewDate
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        int hoursToAdd = 6;
        int minutesToAdd = 30;
        int secondsToAdd = 0;

        string inputDate;
        DateTime date;

        do
        {
            Console.Write("Enter a date in the format d.MM.yyyy h:mm:ss : ");
            inputDate = Console.ReadLine();
        }
        while (!DateTime.TryParseExact(inputDate, "d.MM.yyyy h:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));

        DateTime newDate = date.Add(new TimeSpan(hoursToAdd, minutesToAdd, secondsToAdd));

        Console.WriteLine("The date after {0} hours, {1} minutes and {2} seconds is {3:d.MM.yyyy h:mm:ss} ({3:dddd})",
            hoursToAdd, minutesToAdd, secondsToAdd, newDate);
    }
}
