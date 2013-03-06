using System;
using System.Globalization;

class InvalidRangeExceptionDemo
{
    private const string DATE_FORMAT = "d.M.yyyy";

    private static int ReadInteger(int start, int end)
    {
        int number;
        string inputValue;

        do
        {
            Console.Write("Enter an integer in the range [{0}...{1}]: ", start, end);
            inputValue = Console.ReadLine();
        }
        while (!Int32.TryParse(inputValue, out number));

        if (number < start || number > end)
        {
            throw new InvalidRangeException<int>("Input value was not in the permissible range.", start, end);
        }

        return number;
    }

    private static DateTime ReadDate(DateTime start, DateTime end)
    {
        DateTime date;
        string inputValue;

        do
        {
            Console.Write("Enter a date in the range [{0} - {1}]: ", start.ToString(DATE_FORMAT), end.ToString(DATE_FORMAT));
            inputValue = Console.ReadLine();
        }
        while (!DateTime.TryParseExact(inputValue, DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out date));

        if (date < start || date > end)
        {
            throw new InvalidRangeException<DateTime>("Input value was not in the permissible range.", start, end);
        }

        return date;
    }

    static void Main()
    {
        int start = 1;
        int end = 100;
        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime endDate = new DateTime(2013, 12, 31);

        try
        {
            int number = ReadInteger(start, end);
            Console.WriteLine("Your number: " + number);
        }
        catch (InvalidRangeException<int> ex)
        {
            Console.WriteLine("{0}\nRange: [{1}...{2}]", ex.Message, ex.Start, ex.End);
        }

        try
        {
            DateTime date = ReadDate(startDate, endDate);
            Console.WriteLine("Your date: " + date.ToString(DATE_FORMAT));
        }
        catch (InvalidRangeException<DateTime> ex)
        {
            Console.WriteLine("{0}\nRange: [{1} - {2}]", ex.Message, ex.Start.ToString(DATE_FORMAT), ex.End.ToString(DATE_FORMAT));
        }
    }
}