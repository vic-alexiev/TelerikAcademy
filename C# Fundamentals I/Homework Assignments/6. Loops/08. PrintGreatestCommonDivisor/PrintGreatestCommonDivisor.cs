using System;
using System.Globalization;

class PrintGreatestCommonDivisor
{
    private static int GetGreatestCommonDivisor3(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private static int GetGreatestCommonDivisor2(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        else
        {
            return GetGreatestCommonDivisor2(b, a % b);
        }
    }

    private static int GetGreatestCommonDivisor1(int a, int b)
    {
        if (a == 0)
        {
            return b;
        }
        while (b != 0)
        {
            if (a > b)
            {
                a = a - b;
            }
            else
            {
                b = b - a;
            }
        }
        return a;
    }

    static void Main()
    {
        int a;
        int b;
        string numberA;
        string numberB;

        do
        {
            Console.Write("Enter a > 1: ");
            numberA = Console.ReadLine();
        }
        while (!Int32.TryParse(numberA, NumberStyles.Number, CultureInfo.InvariantCulture, out a) || a <= 1);

        do
        {
            Console.Write("Enter b > 1: ");
            numberB = Console.ReadLine();
        }
        while (!Int32.TryParse(numberB, NumberStyles.Number, CultureInfo.InvariantCulture, out b) || b <= 1);

        int gcd = GetGreatestCommonDivisor3(a, b);

        Console.WriteLine("GCD({0}, {1}) = {2}", a, b, gcd);
    }
}
