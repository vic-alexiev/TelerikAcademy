using System;
using System.Globalization;
using System.Threading;

class PrintNumberUsingDifferentFormats
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        string input;
        int number;
        do
        {
            Console.Write("Enter a non-negative integer: ");
            input = Console.ReadLine();
        }
        while (!Int32.TryParse(input, out number) || number < 0);

        Console.WriteLine("The decimal number . . . . . . . . . . : {0,15:D}", number);
        Console.WriteLine("The hexadecimal number . . . . . . . . : {0,15:X4}", number);
        Console.WriteLine("The number as percentage . . . . . . . : {0,15:P2}", number);
        Console.WriteLine("The number in scientific format. . . . : {0,15:E2}", number);
    }
}