using System;

internal class Divisors
{
    private static int minDivisorsCount = int.MaxValue;
    private static int minDivisorsCountNumber = int.MaxValue;

    private static int GetDivisorsCount(int number)
    {
        int divisorsCount = 0;

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                divisorsCount++;

                // optimization: no need to have all the divisors
                // since we have exceeded the number of minimum divisors, i.e.
                // this number cannot be a solution. Due to this optimization,
                // the method doesn't return the actual number of divisors
                if (divisorsCount >= minDivisorsCount)
                {
                    break;
                }
            }
        }

        return divisorsCount;
    }

    static void GeneratePermutations(int[] items, int start, int size)
    {
        int number = int.Parse(string.Join(string.Empty, items));

        int divisorsCount = GetDivisorsCount(number);
        if (divisorsCount < minDivisorsCount)
        {
            minDivisorsCount = divisorsCount;
            minDivisorsCountNumber = number;
        }

        for (int left = size - 2; left >= start; left--)
        {
            for (int right = left + 1; right < size; right++)
            {
                if (items[left] != items[right])
                {
                    int temp = items[left];
                    items[left] = items[right];
                    items[right] = temp;

                    GeneratePermutations(items, left + 1, size);
                }
            }

            // Undo all modifications done by the
            // swaps and previous recursive calls
            var firstElement = items[left];
            for (int i = left; i < size - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[size - 1] = firstElement;
        }
    }

    private static void Main()
    {
        int digitsCount = int.Parse(Console.ReadLine());

        int[] digits = new int[digitsCount];

        for (int i = 0; i < digitsCount; i++)
        {
            digits[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(digits);
        GeneratePermutations(digits, 0, digits.Length);

        Console.WriteLine(minDivisorsCountNumber);
    }
}
