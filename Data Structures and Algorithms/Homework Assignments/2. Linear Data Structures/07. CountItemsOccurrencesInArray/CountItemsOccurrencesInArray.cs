using System;

internal class CountItemsOccurrencesInArray
{
    private static void Main()
    {
        int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        // the use of an additional array is justified only because
        // the numbers are in a specified range: [0...1000].
        int[] occurrences = new int[1001];

        foreach (var number in numbers)
        {
            occurrences[number]++;
        }

        for (int i = 0; i < occurrences.Length; i++)
        {
            if (occurrences[i] > 0)
            {
                Console.WriteLine("{0} occurs {1} times.", i, occurrences[i]);
            }
        }
    }
}
