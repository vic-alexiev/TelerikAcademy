using System;
using System.Globalization;

class FindTheGreatestOf5Numbers
{
    private static void PrintGreatestNumber(int numbersCount)
    {
        if (numbersCount <= 0)
        {
            return;
        }

        double[] numbers = new double[numbersCount];
        string numberAsString;
        double number;
        double max = 0;

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                numberAsString = Console.ReadLine();
            }
            while (!Double.TryParse(numberAsString, NumberStyles.Number, CultureInfo.InvariantCulture, out number));

            if (max < number)
            {
                max = number;
            }
        }

        Console.WriteLine("{0} is greatest.", max);
    }

    static void Main()
    {
        PrintGreatestNumber(5);
    }
}
