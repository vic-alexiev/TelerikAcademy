using Nakov.IO;
using System;
using System.Collections.Generic;

class LongestContiguousSubsequenceOfEqualElements
{
    /// <summary>
    /// A generic method which finds the longest contiguous subsequence of equal elements.
    /// It works only for arrays of types that implement IComparable
    /// (i.e. int, long, DateTime, string).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    private static int GetLengthOfLongestSequenceOfEqualElements<T>(IList<T> value, out int start) where T : IComparable<T>
    {
        int size = value.Count;

        int length = 1;
        int startIndex = 0;
        int maxLength = 1;
        start = 0;

        for (int i = 1; i < size; i++)
        {
            if (value[i].Equals(value[i - 1]))
            {
                length++;
            }

            // the adjacent elements are different - 
            // check if the sequence which has just finished
            // is the longest sequence so far
            if (!value[i].Equals(value[i - 1]) || i == size - 1)
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

    private static int GetLengthOfLongestContiguousSubsequenceOfEqualElements(int[] value, out int start)
    {
        int size = value.Length;

        int length = 1;
        int startIndex = 0;
        int maxLength = 1;
        start = 0;

        for (int i = 1; i < size; i++)
        {
            if (value[i] == value[i - 1])
            {
                length++;
            }

            // the adjacent elements are different - 
            // check if the sequence which has just finished
            // is the longest sequence so far
            if (value[i] != value[i - 1] || i == size - 1)
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
        int length = GetLengthOfLongestSequenceOfEqualElements(numbers, out start);

        Console.Write("Longest subsequence of equal elements (length = {0}): ", length);

        for (int i = start; i < start + length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }
}
