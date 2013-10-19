using System;

class NextDate
{
    static void Main()
    {
        string days = Console.ReadLine();
        int day = Int32.Parse(days);

        string months = Console.ReadLine();
        int month = Int32.Parse(months);

        string years = Console.ReadLine();
        int year = Int32.Parse(years);

        DateTime date = new DateTime(year, month, day);
        DateTime nextDate = date.AddDays(1);

        Console.WriteLine("{0:d.M.yyyy}", nextDate);
    }
}