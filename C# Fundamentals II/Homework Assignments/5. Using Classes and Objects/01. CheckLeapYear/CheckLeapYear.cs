using System;

class CheckLeapYear
{
    static void Main()
    {
        string inputYear;
        int year;

        do
        {
            Console.Write("Enter a year (an integer in the range [1, 9999]): ");
            inputYear = Console.ReadLine();
        }
        while (!Int32.TryParse(inputYear, out year) || year < 1 || year > 9999);

        bool isLeapYear = DateTime.IsLeapYear(year);

        Console.WriteLine("This is{0} a leap year.", isLeapYear ? String.Empty : " not");
    }
}
