using System;
using System.Globalization;
using System.Numerics;

class PrintBinomialCoefficient
{
    private static BigInteger GetBinomialCoefficient2(int n, int k)
    {
        if ((k < 0) || (k > n))
        {
            return 0;
        }

        if (k > n / 2)
        {
            k = n - k;
        }

        BigInteger result = 1;

        for (int i = 1; i <= k; i++)
        {
            result *= n--;
            result /= i;
        }

        return result;
    }

    private static BigInteger GetBinomialCoefficient1(int n, int k)
    {
        if ((k < 0) || (k > n))
        {
            return 0;
        }

        if (k > n / 2)
        {
            k = n - k;
        }

        BigInteger product = 1;

        for (int i = 1; i <= k; i++)
        {
            product = (product * (n - k + i)) / i;
        }

        return product;
    }

    /// <summary>
    /// Prints the binomial coefficient C(n, k) for given n and k.
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Binomial_coefficient"/>
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

        BigInteger coefficient = GetBinomialCoefficient2(n, k);

        Console.WriteLine("C({0}, {1}) = {0}! / ({1}! {2}!) = {3}", n, k, n - k, coefficient);
    }
}
