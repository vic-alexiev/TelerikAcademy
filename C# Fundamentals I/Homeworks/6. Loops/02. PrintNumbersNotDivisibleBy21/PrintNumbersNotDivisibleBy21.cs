using System;
using System.Globalization;

class PrintNumbersNotDivisibleBy21
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

        Console.WriteLine("Numbers which aren't multiples of 21 in [1, {0}]:", n);

        for (int i = 1; i <= n; i++)
        {
            if (i % 21 != 0)
            {
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine();
    }
}
