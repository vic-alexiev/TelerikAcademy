using Nakov.IO;
using System;

class ConsecutiveElementsHavingMaximumSum
{
    private static int GetMaximumSumOfContiguousSubsequence(int[] value, int subsequenceLength, out int start)
    {
        int size = value.Length;
        int sum = 0;
        int maxSum = 0;

        for (int i = 0; i < subsequenceLength; i++)
        {
            sum += value[i];
        }

        maxSum = sum;
        start = 0;

        for (int j = 1; j <= size - subsequenceLength; j++)
        {
            sum -= value[j - 1];
            sum += value[j - 1 + subsequenceLength];

            if (maxSum < sum)
            {
                maxSum = sum;
                start = j;
            }
        }

        return maxSum;
    }

    static void Main()
    {
        string numberN;
        int n;
        string numberK;
        int k;

        do
        {
            Console.Write("Enter the size of the array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        do
        {
            Console.Write("Enter the size of the subsequence: ");
            numberK = Console.ReadLine();
        }
        while (!Int32.TryParse(numberK, out k) || k <= 0 || k > n);

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        int start;
        int maxSum = GetMaximumSumOfContiguousSubsequence(numbers, k, out start);

        Console.Write("The {0} consecutive elements having maximum sum ({1}) are: ", k, maxSum);

        for (int i = start; i < start + k; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }
}
