using System;
using System.Collections.Generic;

internal class RemoveNegativeNumbers
{
    private static List<int> GetNonNegativeNumbers(List<int> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source", "source cannot be null.");
        }

        List<int> result = new List<int>();

        foreach (var number in source)
        {
            if (number >= 0)
            {
                result.Add(number);
            }
        }

        return result;
    }

    private static void Main()
    {
        List<int> numbers = new List<int>(new int[] { 19, -10, 12, -6, -3, 34, -2, 5 });

        // I solution
        //List<int> nonNegativeNumbers = GetNonNegativeNumbers(numbers);

        //Console.WriteLine(
        //    "The list with the negative elements removed: {0}.",
        //    string.Join(", ", nonNegativeNumbers));

        // II solution
        numbers.RemoveAll(p => p < 0);

        Console.WriteLine(
            "The list with the negative elements removed: {0}.",
            string.Join(", ", numbers));
    }
}
