using System;
using System.Globalization;

class CalculateTimeSpan
{
    static void Main()
    {
        string inputDate1;
        DateTime date1;

        do
        {
            Console.Write("Enter the first date in the format d.MM.yyyy: ");
            inputDate1 = Console.ReadLine();
        }
        while (!DateTime.TryParseExact(inputDate1, "d.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1));

        string inputDate2;
        DateTime date2;

        do
        {
            Console.Write("Enter the second date in the format d.MM.yyyy: ");
            inputDate2 = Console.ReadLine();
        }
        while (!DateTime.TryParseExact(inputDate2, "d.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date2));

        DateTime newDate1 = new DateTime(DateTime.Now.Year, date1.Month, date1.Day);
        DateTime newDate2 = new DateTime(DateTime.Now.Year, date2.Month, date2.Day);

        TimeSpan timeSpan = newDate2.Subtract(newDate1);

        Console.WriteLine("There are {0} days between the two dates.", Math.Abs(timeSpan.Days));
    }
}
