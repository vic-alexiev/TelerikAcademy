using System;
using System.Globalization;

class SignOfTheProduct
{
    private static void DetermineProductSign1(int numbersCount)
    {
        if (numbersCount <= 0)
        {
            return;
        }

        string number;
        double realNumber;
        int precision = 15;
        int minusesCount = 0;

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                number = Console.ReadLine();
            }
            while (!Double.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out realNumber));

            if (Math.Round(realNumber, precision) == 0.0)
            {
                Console.WriteLine("The product of your numbers will be zero");
                return;
            }

            if (realNumber < 0.0)
            {
                minusesCount++;
            }
        }

        if (minusesCount % 2 == 0)
        {
            Console.WriteLine("The product of your numbers will be positive.");
        }
        else
        {
            Console.WriteLine("The product of your numbers will be negative.");
        }
    }

    private static void DetermineProductSign2()
    {
        string number1;
        string number2;
        string number3;
        double a;
        double b;
        double c;

        int precision = 15;

        do
        {
            Console.Write("Enter the first number: ");
            number1 = Console.ReadLine();
        }
        while (!Double.TryParse(number1, NumberStyles.Number, CultureInfo.InvariantCulture, out a));

        do
        {
            Console.Write("Enter the second number: ");
            number2 = Console.ReadLine();
        }
        while (!Double.TryParse(number2, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        do
        {
            Console.Write("Enter the third number: ");
            number3 = Console.ReadLine();
        }
        while (!Double.TryParse(number3, NumberStyles.Number, CultureInfo.InvariantCulture, out c));

        if (Math.Round(a, precision) == 0.0 || Math.Round(b, precision) == 0.0 || Math.Round(c, precision) == 0.0)
        {
            Console.WriteLine("The product of your numbers will be zero");
            return;
        }

        // if there is 1 or 3 minus signs
        if ((a < 0) ^ (b < 0) ^ (c < 0))
        {
            Console.WriteLine("The product of your numbers will be negative.");
        }
        else // 0 or 2 minus signs
        {
            Console.WriteLine("The product of your numbers will be positive.");
        }
    }

    static void Main()
    {
        //DetermineProductSign1(3);
        DetermineProductSign2();
    }
}
