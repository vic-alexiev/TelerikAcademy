using System;
using System.Globalization;

class FindTheGreatestOf3Integers
{
    private static void PrintGreatestInt()
    {
        string number1;
        string number2;
        string number3;
        int a;
        int b;
        int c;

        do
        {
            Console.Write("Enter the first number: ");
            number1 = Console.ReadLine();
        }
        while (!Int32.TryParse(number1, NumberStyles.Number, CultureInfo.InvariantCulture, out a));

        do
        {
            Console.Write("Enter the second number: ");
            number2 = Console.ReadLine();
        }
        while (!Int32.TryParse(number2, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        do
        {
            Console.Write("Enter the third number: ");
            number3 = Console.ReadLine();
        }
        while (!Int32.TryParse(number3, NumberStyles.Number, CultureInfo.InvariantCulture, out c));

        if (a >= b)
        {
            if (b >= c)
            {
                Console.WriteLine("{0} is greatest.", a);
            }
            else if (a >= c)
            {
                Console.WriteLine("{0} is greatest.", a);
            }
            else
            {
                Console.WriteLine("{0} is greatest.", c);
            }
        }
        else if (b >= c)
        {
            Console.WriteLine("{0} is greatest.", b);
        }
        else
        {
            Console.WriteLine("{0} is greatest.", c);
        }
    }

    private static void PrintGreatestInt(int numbersCount)
    {
        if (numbersCount <= 0)
        {
            return;
        }

        int[] numbers = new int[numbersCount];
        string numberAsString;
        int number;
        int max = 0;

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                numberAsString = Console.ReadLine();
            }
            while (!Int32.TryParse(numberAsString, NumberStyles.Number, CultureInfo.InvariantCulture, out number));

            if (max < number)
            {
                max = number;
            }
        }

        Console.WriteLine("{0} is greatest.", max);
    }

    static void Main()
    {
        //PrintGreatestInt();
        PrintGreatestInt(3);
    }
}
