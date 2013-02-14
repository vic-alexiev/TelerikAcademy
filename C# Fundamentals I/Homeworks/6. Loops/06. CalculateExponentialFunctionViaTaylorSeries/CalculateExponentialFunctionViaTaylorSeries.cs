using System;
using System.Globalization;

class CalculateExponentialFunctionViaTaylorSeries
{
    static void Main()
    {
        int n;
        double x;
        string numberN;
        string numberX;

        do
        {
            Console.Write("Enter N > 2: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n <= 2);

        do
        {
            Console.Write("Enter x: ");
            numberX = Console.ReadLine();
        }
        while (!Double.TryParse(numberX, NumberStyles.Number, CultureInfo.InvariantCulture, out x));

        double sum = 1.0;
        double numerator = 1.0;
        double denominator = 1.0;

        for (int i = 1; i <= n; i++)
        {
            numerator *= x;
            denominator *= i;
            sum += (numerator / denominator);
        }

        Console.WriteLine("The exponent function at the point {0} is approximately equal to {1}.", x, sum);
    }
}
