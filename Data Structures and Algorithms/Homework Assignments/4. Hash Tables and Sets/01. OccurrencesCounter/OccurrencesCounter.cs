using System;
using System.Collections.Generic;

internal class OccurrencesCounter
{
    private static Dictionary<T, int> GetOccurrences<T>(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "array cannot be null.");
        }

        Dictionary<T, int> occurrences = new Dictionary<T, int>();

        foreach (T item in array)
        {
            if (!occurrences.ContainsKey(item))
            {
                occurrences[item] = 1;
            }
            else
            {
                occurrences[item]++;
            }
        }

        return occurrences;
    }

    private static void Main()
    {
        double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

        Dictionary<double, int> occurrences = GetOccurrences(numbers);

        foreach (var item in occurrences)
        {
            Console.WriteLine("{0,5} -> {1} occurrence(s)", item.Key, item.Value);
        }
    }
}
