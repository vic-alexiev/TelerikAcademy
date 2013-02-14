using System;
using System.Globalization;
using System.Threading;

class PrintTheNumbersFrom1ToN
{
    static void Main()
    {
        uint n;
        string number;

        do
        {
            Console.Write("Enter a positive integer: ");
            number = Console.ReadLine();
        }
        while (!UInt32.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n < 1);

        Console.WriteLine("All the numbers in [1, {0}]:", n);

        for (int i = 1; i <= n; i++)
        {
            Console.Write(i);
            Console.Write("\r");
            Thread.Sleep(130);
        }

        Console.WriteLine();
    }
}
