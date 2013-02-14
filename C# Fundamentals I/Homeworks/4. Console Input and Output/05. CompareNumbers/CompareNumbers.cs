using System;
using System.Globalization;

class CompareNumbers
{
    static void Main()
    {
        string firstNumber;
        string secondNumber;
        int a;
        int b;

        do
        {
            Console.Write("Enter the first number: ");
            firstNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(firstNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out a));

        do
        {
            Console.Write("Enter the second number: ");
            secondNumber = Console.ReadLine();
        }
        while (!Int32.TryParse(secondNumber, NumberStyles.Number, CultureInfo.InvariantCulture, out b));

        // I
        //Console.WriteLine("{0} is greater.", Math.Max(a, b));

        // II
        //Console.WriteLine("{0} is greater.", (a + b + Math.Abs(a - b)) / 2);

        // III
        // if a - b is negative, (a - b) >> 31 will be 11111111111111111111111111111111 (binary)
        // if a - b is positive or zero, (a - b) >> 31 will be 00000000000000000000000000000000 (binary)
        //int max = a - ((a - b) & ((a - b) >> 31));
        //Console.WriteLine("{0} is greater.", max);

        // IV
        int d = a - b;
        int m = (d >> 31) & 1; // m: 0 or 1
        long max = a - m * d;
        Console.WriteLine("{0} is greater.", max);
    }
}
