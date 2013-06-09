using System;
using System.Collections.Generic;

internal class FilterElementsThatOccurOddNumberOfTimes
{
    private static IList<T> GetItemsThatOccurOddNumberOfTimes<T>(T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "array cannot be null.");
        }

        List<T> result = new List<T>();
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

        foreach (var occurrence in occurrences)
        {
            if (occurrence.Value % 2 == 1)
            {
                result.Add(occurrence.Key);
            }
        }

        return result;
    }

    private static void Main()
    {
        string[] languages = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        IList<string> filteredLanguages = GetItemsThatOccurOddNumberOfTimes(languages);

        Console.WriteLine("Items that occur odd number of times: {0}.", string.Join(", ", filteredLanguages));
    }
}
