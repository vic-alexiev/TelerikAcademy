using System;
using System.Numerics;

class Tribonacci
{
    static bool IsInTribonacciRange(BigInteger n)
    {
        return (-2000000000 <= n && n <= 2000000000);
    }

    static bool IsInIndexRange(int n)
    {
        return (1 <= n && n <= 15000);
    }

    static void Main()
    {
        string trib0 = Console.ReadLine();
        BigInteger t0;
        if (!BigInteger.TryParse(trib0, out t0) || !IsInTribonacciRange(t0))
        {
            Console.WriteLine("Invalid number!");
            return;
        }

        string trib1 = Console.ReadLine();
        BigInteger t1;
        if (!BigInteger.TryParse(trib1, out t1) || !IsInTribonacciRange(t1))
        {
            Console.WriteLine("Invalid number!");
            return;
        }

        string trib2 = Console.ReadLine();
        BigInteger t2;
        if (!BigInteger.TryParse(trib2, out t2) || !IsInTribonacciRange(t2))
        {
            Console.WriteLine("Invalid number!");
            return;
        }

        string index = Console.ReadLine();
        int n;
        if (!Int32.TryParse(index, out n) || !IsInIndexRange(n))
        {
            Console.WriteLine("Invalid number!");
            return;
        }

        BigInteger[] tribonacciNumbers = new BigInteger[n > 2 ? n : 3];
        tribonacciNumbers[0] = t0;
        tribonacciNumbers[1] = t1;
        tribonacciNumbers[2] = t2;

        BigInteger sum = 0;

        for (int i = 3; i < n; i++)
        {
            sum = t0 + t1 + t2;
            t0 = t1;
            t1 = t2;
            t2 = sum;
            tribonacciNumbers[i] = sum;
        }

        Console.WriteLine(tribonacciNumbers[n - 1]);
    }
}
