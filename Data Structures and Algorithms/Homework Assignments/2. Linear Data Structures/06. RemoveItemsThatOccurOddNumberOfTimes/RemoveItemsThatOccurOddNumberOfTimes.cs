using System;
using System.Collections.Generic;
using System.Linq;

internal class RemoveItemsThatOccurOddNumberOfTimes
{
    private static List<T> GetItemsThatOccurEvenNumberOfTimes<T>(List<T> source, IEqualityComparer<T> comparer)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        if (source.Count == 0)
        {
            throw new ArgumentException("Sequence contains no elements.", "source");
        }

        int size = source.Count;

        T[] items = new T[source.Count];
        source.CopyTo(items);
        List<T> sourceCopy = new List<T>(items);
        sourceCopy.Sort();

        List<T> itemsThatOccurEvenNumberOfTimes = new List<T>();

        comparer = comparer ?? EqualityComparer<T>.Default;
        int count = 1;

        for (int i = 1; i < size; i++)
        {
            if (comparer.Equals(sourceCopy[i], sourceCopy[i - 1]))
            {
                count++;
            }

            // the adjacent elements are different - 
            // check if the sequence which has just finished
            // is the longest sequence so far
            if (!comparer.Equals(sourceCopy[i], sourceCopy[i - 1]) || i == size - 1)
            {
                if (count % 2 == 0)
                {
                    itemsThatOccurEvenNumberOfTimes.Add(sourceCopy[i - 1]);
                }

                if (i < size - 1)
                {
                    count = 1;
                }
            }
        }

        List<T> result = new List<T>(source.Where(p => itemsThatOccurEvenNumberOfTimes.Contains(p)));
        return result;
    }

    private static void Main()
    {
        List<int> numbers = new List<int>(new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 });

        List<int> itemsThatOccurEvenNumberOfTimes = GetItemsThatOccurEvenNumberOfTimes(numbers, null);

        Console.WriteLine(
            "The list with the items that occur odd number of times removed: {0}.",
            string.Join(", ", itemsThatOccurEvenNumberOfTimes));
    }
}
