using System;
using System.Globalization;

class PrintMinAndMax
{
    static void Main()
    {
        int numbersCount = 5;

        string input;
        int number;
        int min = 0;
        int max = 0;

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                input = Console.ReadLine();
            }
            while (!Int32.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out number));

            if (number < min)
            {
                min = number;
            }

            if (max < number)
            {
                max = number;
            }
        }

        Console.WriteLine("\nMinimum number . . . . . . . . . : {0}"
            + "\nMaximum number . . . . . . . . . : {1}\n", min, max);
    }
}
