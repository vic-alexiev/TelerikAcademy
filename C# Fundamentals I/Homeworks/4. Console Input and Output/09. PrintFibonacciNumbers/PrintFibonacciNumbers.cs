using System;
using System.Numerics;

class PrintFibonacciNumbers
{
    static void Main()
    {
        //PrintFirstNFibonacciNumbers1(501);
        PrintFirstNFibonacciNumbers2(501);
    }

    /// <summary>
    /// Recursively calculates the xth Fibonacci number.
    /// Practically unusable.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private static int Fibonacci(int x)
    {
        if (x == 0) return 0;
        if (x == 1) return 1;

        return Fibonacci(x - 1) + Fibonacci(x - 2);
    }

    private static BigInteger Fibo(BigInteger n, BigInteger previous, BigInteger oneBeforePrevious)
    {
        return n < 2 ? n : previous + Fibo(n - 1, oneBeforePrevious + previous, previous);
    }

    private static void PrintFirstNFibonacciNumbers1(uint n)
    {
        BigInteger[] fibonacciNumbers = new BigInteger[n];
        fibonacciNumbers[0] = 0;
        fibonacciNumbers[1] = 1;

        uint upperLimit = n - 1;

        bool isNOdd = (n & 1U) == 1U;
        if (isNOdd)
        {
            upperLimit--;
        }

        BigInteger a = 0;
        BigInteger b = 1;

        for (int i = 1; i < upperLimit; i += 2)
        {
            a += b;
            b += a;
            fibonacciNumbers[i + 1] = a;
            fibonacciNumbers[i + 2] = b;
        }

        // if n is odd, the last number should be calculated outside the loop
        if (isNOdd)
        {
            a += b;
            fibonacciNumbers[n - 1] = a;
        }

        for (int j = 0; j < fibonacciNumbers.Length; j++)
        {
            Console.WriteLine("{0,6}: {1}", j + 1, fibonacciNumbers[j]);
        }
    }

    private static void PrintFirstNFibonacciNumbers2(uint n)
    {
        BigInteger[] fibonacciNumbers = new BigInteger[n];
        fibonacciNumbers[0] = 0;
        fibonacciNumbers[1] = 1;

        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger sum;

        for (int i = 2; i < n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
            fibonacciNumbers[i] = sum;
        }

        for (int j = 0; j < fibonacciNumbers.Length; j++)
        {
            Console.WriteLine("{0,6}: {1}", j + 1, fibonacciNumbers[j]);
        }
    }
}
