using Nakov.IO;
using System;

class LongestIncreasingContiguousSubsequence
{
    /// <summary>
    /// Returns the length and start index of the longest
    /// strictly increasing contiguous subsequence.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    private static int GetLengthOfLongestIncreasingContiguousSubsequence(int[] value, out int start)
    {
        int size = value.Length;

        int length = 1;
        int maxLength = 1;
        int startIndex = 0;
        start = 0;

        for (int i = 1; i < size; i++)
        {
            if (value[i] > value[i - 1])
            {
                length++;
            }

            if (value[i] <= value[i - 1] || i == size - 1)
            {
                if (maxLength < length)
                {
                    maxLength = length;
                    start = startIndex;
                }

                if (i < size - 1)
                {
                    startIndex = i;
                    length = 1;
                }
            }
        }

        return maxLength;
    }

    static void Main()
    {
        string numberN;
        int n;

        do
        {
            Console.Write("Enter the size of the array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        int start;
        int length = GetLengthOfLongestIncreasingContiguousSubsequence(numbers, out start);

        Console.Write("Longest increasing subsequence (length = {0}): ", length);

        for (int i = start; i < start + length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }
}
