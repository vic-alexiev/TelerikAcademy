using System;
using System.Collections.Generic;
using System.Linq;

internal class SumAndAverage
{
    private static void Main()
    {
        List<int> numbers = new List<int>();
        string input;
        int number;

        Console.WriteLine("Enter a sequence of positive integers, empty line to finish input:");

        do
        {
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            if (int.TryParse(input, out number) && number > 0)
            {
                numbers.Add(number);
            }
        }
        while (true);

        try
        {
            if (numbers.Count > 0)
            {
                Console.WriteLine("The sum of the elements is equal to {0}.", numbers.Sum());
                Console.WriteLine("The average of the elements is equal to {0:F4}.", numbers.Average());
            }
            else
            {
                Console.WriteLine("The list is empty. No sum or average calculated.");
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("An error occurred while summing the numbers: " + ex.Message);
        }
    }
}
