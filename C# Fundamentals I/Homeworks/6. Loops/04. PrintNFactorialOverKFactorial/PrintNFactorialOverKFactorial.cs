using System;
using System.Globalization;
using System.Numerics;

class PrintNFactorialOverKFactorial
{
    /// <summary>
    /// Calculates N!/K!
    /// </summary>
    static void Main()
    {
        int n;
        int k;
        string numberN;
        string numberK;

        do
        {
            Console.Write("Enter N > 2: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n <= 2);

        do
        {
            Console.Write("Enter K in (1, {0}): ", n);
            numberK = Console.ReadLine();
        }
        while (!Int32.TryParse(numberK, NumberStyles.Number, CultureInfo.InvariantCulture, out k) || k <= 1 || k >= n);

        BigInteger product = 1;

        for (int i = k + 1; i <= n; i++)
        {
            product *= i;
        }

        Console.WriteLine("{0}! / {1}! = {2}\n", n, k, product);
    }
}
