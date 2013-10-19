using System;
using System.Numerics;

class TribonacciTriangle
{
    static void Main()
    {
        string trib0 = Console.ReadLine();
        BigInteger t0 = BigInteger.Parse(trib0);


        string trib1 = Console.ReadLine();
        BigInteger t1 = BigInteger.Parse(trib1);

        string trib2 = Console.ReadLine();
        BigInteger t2 = BigInteger.Parse(trib2);

        string linesCount = Console.ReadLine();
        int lines = Int32.Parse(linesCount);

        // the numbers count is equal to the sum of the arithmetic progression 1 + 2 + 3 + ... + lines
        // which is lines(lines + 1) / 2
        int n = (lines * (lines + 1)) / 2;

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

        int index = 0;

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (j < i)
                {
                    Console.Write("{0} ", tribonacciNumbers[index]);
                }
                else
                {
                    Console.Write("{0}\n", tribonacciNumbers[index]);
                }

                index++;
            }
        }
    }
}
