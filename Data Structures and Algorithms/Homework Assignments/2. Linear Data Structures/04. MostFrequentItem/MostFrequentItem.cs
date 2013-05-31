using System;
using System.Collections.Generic;
using System.Linq;

internal class MostFrequentItem
{
    /// <summary>
    /// Finds the most frequent item in <paramref name="source"/> and
    /// the number of its occurrences. Returns a list which contains the
    /// most frequent item repeated as many times as it occurs in the original list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    private static List<T> GetLongestSequenceOfEqualItems<T>(List<T> source, IEqualityComparer<T> comparer)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        if (source.Count == 0)
        {
            return new List<T>();
        }

        comparer = comparer ?? EqualityComparer<T>.Default;

        int n = source.Count;
        int occurrences = 1;
        T item = source[0];

        for (int i = 0; i < n; i++)
        {
            int count = 1;
            for (int j = i + 1; j < n; j++)
            {
                if (comparer.Equals(source[j], source[i]))
                {
                    count++;
                }
            }

            if (occurrences < count)
            {
                occurrences = count;
                item = source[i];
            }
        }

        List<T> result = new List<T>(Enumerable.Repeat(item, occurrences));
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

            Console.Write("Longest sequence of equal items (length = {0}): ", longestSequenceOfEqualItems.Count);
            Console.WriteLine(string.Join(", ", longestSequenceOfEqualItems));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
