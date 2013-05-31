using System;
using System.Collections.Generic;

internal class SortNumbers
{
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

        numbers.Sort((p, q) => p.CompareTo(q));

        Console.WriteLine("The list sorted in ascending order: {0}.", string.Join(", ", numbers));
    }
}
