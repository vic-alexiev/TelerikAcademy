using System;
using System.Numerics;
using System.Text;

class ProvadiaNumbers
{
    private static string[] digits = new string[256];

    private static void FillDigits()
    {
        int counter = 0;

        for (char u = 'A'; u <= 'Z'; u++)
        {
            digits[counter++] = u.ToString();
        }

        for (char l = 'a'; l <= 'i'; l++)
        {
            for (char u = 'A'; u <= 'Z'; u++)
            {
                if (counter <= 255)
                {
                    digits[counter++] = String.Format("{0}{1}", l, u);
                }
                else
                {
                    return;
                }
            }
        }
    }

    private static string FromDecimal(BigInteger decimalValue, int radix)
    {
        if (decimalValue < 0)
        {
            throw new ArgumentException("The decimal number should be a non-negative integer.");
        }

        if (radix < 2 || radix > digits.Length)
        {
            throw new ArgumentException(String.Format("The radix must be an integer in the range [2, {0}].", digits.Length));
        }

        if (decimalValue == 0)
        {
            return digits[0];
        }

        StringBuilder resultBuilder = new StringBuilder();

        while (decimalValue > 0)
        {
            int remainder = (int)(decimalValue % radix);
            resultBuilder.Insert(0, digits[remainder]);
            decimalValue = decimalValue / radix;
        }

        return resultBuilder.ToString();
    }

    static void Main()
    {
        FillDigits();

        string input = Console.ReadLine();
        BigInteger number = BigInteger.Parse(input);

        string provadian = FromDecimal(number, 256);
        Console.WriteLine(provadian);
    }
}
