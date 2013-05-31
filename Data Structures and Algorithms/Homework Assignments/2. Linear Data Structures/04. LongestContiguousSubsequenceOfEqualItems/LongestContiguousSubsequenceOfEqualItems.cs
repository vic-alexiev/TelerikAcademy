using System;
using System.Collections.Generic;
using System.Linq;

internal class LongestContiguousSubsequenceOfEqualItems
{
    /// <summary>
    /// Finds the longest contiguous subsequence of equal items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    private static List<T> GetLongestSequenceOfEqualItems<T>(List<T> source, IEqualityComparer<T> comparer)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        if (source.Count == 0)
        {
            throw new ArgumentException("Sequence contains no elements.", "source");
        }

        comparer = comparer ?? EqualityComparer<T>.Default;

        int size = source.Count;

        int currentLength = 1;
        int currentStart = 0;
        int length = 1;
        int start = 0;

        for (int i = 1; i < size; i++)
        {
            if (comparer.Equals(source[i], source[i - 1]))
            {
                currentLength++;
            }

            // the adjacent elements are different - 
            // check if the sequence which has just finished
            // is the longest sequence so far
            if (!comparer.Equals(source[i], source[i - 1]) || i == size - 1)
            {
                if (length < currentLength)
                {
                    length = currentLength;
                    start = currentStart;
                }

                if (i < size - 1)
                {
                    currentStart = i;
                    currentLength = 1;
                }
            }
        }

        T item = source[start];
        List<T> result = new List<T>(Enumerable.Repeat(item, length));

        return result;
    }

    private static void Main()
    {
        List<int> numbers = new List<int>();
        string input;
        int number;

        Console.WriteLine("Enter a sequence of integers, empty line to finish input:");

        do
        {
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            if (int.TryParse(input, out number))
            {
                numbers.Add(number);
            }
        }
        while (true);

        try
        {
            List<int> longestSequenceOfEqualItems = GetLongestSequenceOfEqualItems(numbers, null);

            Console.Write("Longest subsequence of equal items (length = {0}): ", longestSequenceOfEqualItems.Count);
            Console.WriteLine(string.Join(", ", longestSequenceOfEqualItems));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
