using System;
using System.Globalization;
using System.Numerics;

class PrintNthCatalanNumber
{
    private static BigInteger GetNthCatalanNumber(int n)
    {
        if (n < 2)
        {
            return 1;
        }

        BigInteger product = 1;

        for (BigInteger i = 0; i < n; i++)
        {
            product = (2 * (2 * i + 1) * product) / (i + 2);
        }

        return product;
    }

    static void Main()
    {
        int n;
        string numberN;

        do
        {
            Console.Write("Enter N >= 0: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n < 0);

        BigInteger nthCatalanNumber = GetNthCatalanNumber(n);

        string nAsString = n.ToString();
        char lastDigit = nAsString[nAsString.Length - 1];
        string suffix;

        switch (lastDigit)
        {
            case '1':
                {
                    suffix = "st";
                    break;
                }
            case '2':
                {
                    suffix = "nd";
                    break;
                }
            case '3':
                {
                    suffix = "rd";
                    break;
                }
            default:
                {
                    suffix = "th";
                    break;
                }
        }

        Console.WriteLine("The {0}{1} Catalan number equals to {2}", n, suffix, nthCatalanNumber);
    }
}
