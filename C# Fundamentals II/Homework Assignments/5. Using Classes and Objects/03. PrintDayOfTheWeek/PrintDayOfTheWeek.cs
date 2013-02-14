using System;

class PrintDayOfTheWeek
{
    static void Main()
    {
        DateTime now = DateTime.Now;

        Console.WriteLine("Today is {0}.", now.DayOfWeek);
    }
}
