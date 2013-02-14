using System;
using System.Globalization;
using System.Numerics;

class PrintSumOfFirstNFibonacciNumbers
{
    private static BigInteger GetSumOfFirstNFibonacciNumbers(uint n)
    {
        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger accumulator = 1;
        BigInteger sum = 1;

        for (int i = 2; i < n; i++)
        {
            accumulator = a + b;
            a = b;
            b = accumulator;
            sum += accumulator;
        }

        return sum;
    }

    static void Main()
    {
        uint n;
        string numberN;

        do
        {
            Console.Write("Enter N > 1: ");
            numberN = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberN, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n <= 1);

        BigInteger fibonacciSum = GetSumOfFirstNFibonacciNumbers(n);

        Console.WriteLine("The sum of the first {0} Fibonacci numbers equals to {1}.", n, fibonacciSum);
    }
}
