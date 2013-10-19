using System;
using System.Numerics;

class QuadronacciRectangle
{
    static void Main()
    {
        string numberA = Console.ReadLine();
        BigInteger a = BigInteger.Parse(numberA);

        string numberB = Console.ReadLine();
        BigInteger b = BigInteger.Parse(numberB);

        string numberC = Console.ReadLine();
        BigInteger c = BigInteger.Parse(numberC);

        string numberD = Console.ReadLine();
        BigInteger d = BigInteger.Parse(numberD);

        string rowsCount = Console.ReadLine();
        int rows = Int32.Parse(rowsCount);

        string colsCount = Console.ReadLine();
        int cols = Int32.Parse(colsCount);

        int count = rows * cols;

        BigInteger[] quadronacciNumbers = new BigInteger[count < 4 ? 4 : count];

        quadronacciNumbers[0] = a;
        quadronacciNumbers[1] = b;
        quadronacciNumbers[2] = c;
        quadronacciNumbers[3] = d;
        BigInteger sum = 0;

        for (int i = 4; i < count; i++)
        {
            sum = a + b + c + d;
            a = b;
            b = c;
            c = d;
            d = sum;
            quadronacciNumbers[i] = sum;
        }

        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j == cols - 1)
                {
                    Console.Write("{0}\n", quadronacciNumbers[index]);
                }
                else
                {
                    Console.Write("{0} ", quadronacciNumbers[index]);
                }
                index++;
            }
        }
    }
}
