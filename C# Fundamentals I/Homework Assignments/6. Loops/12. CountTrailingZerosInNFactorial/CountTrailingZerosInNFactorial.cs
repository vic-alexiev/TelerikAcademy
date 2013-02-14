using System;
using System.Globalization;

class CountTrailingZerosInNFactorial
{
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

        int trailingZeros = 0;
        int powerOf5 = 5;

        try
        {
            while (powerOf5 <= n)
            {
                checked
                {
                    trailingZeros += (n / powerOf5);
                    powerOf5 *= powerOf5;
                }
            }

            Console.WriteLine("There are {0} trailing zeros in {1}!", trailingZeros, n);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
