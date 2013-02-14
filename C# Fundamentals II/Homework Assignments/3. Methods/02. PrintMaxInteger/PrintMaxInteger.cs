using Nakov.IO;
using System;

class PrintMaxInteger
{
    private static int GetMaxInArray(int[] value)
    {
        if (value == null || value.Length == 0)
        {
            throw new ArgumentException("Empty array.");
        }

        if (value.Length == 1)
        {
            return value[0];
        }

        int max = value[0];

        for (int i = 1; i < value.Length; i++)
        {
            if (max < value[i])
            {
                max = value[i];
            }
        }

        return max;
    }

    private static int GetMax(int a, int b)
    {
        return a >= b ? a : b;
    }

    static void Main()
    {
        int n = 3;
        int[] numbers = new int[n];
        Console.Write("Enter {0} integers separated with spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        // I solution
        int greatestNumber = GetMax(numbers[0], GetMax(numbers[1], numbers[2]));

        // II solution
        //int greatestNumber = GetMaxInArray(numbers);

        Console.WriteLine("{0} is greatest.", greatestNumber);
    }
}
