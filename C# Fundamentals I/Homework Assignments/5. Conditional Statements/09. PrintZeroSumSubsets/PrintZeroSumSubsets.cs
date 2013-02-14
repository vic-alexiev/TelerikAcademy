using System;
using System.Globalization;
using System.Linq;

class PrintZeroSumSubsets
{
    private const int OFFSET = 1024;

    /// <summary>
    /// Using the DP method described in Wikipedia.
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Subset_sum_problem#Pseudo-polynomial_time_dynamic_programming_solution"/>
    /// <param name="numbers"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    private static bool ContainsSubsetWhichSumsTo3(int[] numbers, int sum)
    {
        int N = numbers.Where(x => x < 0).Sum();
        int P = numbers.Where(x => x > 0).Sum();

        if (sum < N || sum > P)
        {
            return false;
        }

        int n = numbers.Length;
        bool[,] Q = new bool[n, OFFSET + OFFSET];

        // Initially, for N <= s <= P, set Q(0, OFFSET + s) := (x0 == s).
        for (int s = N; s <= P; s++)
        {
            Q[0, OFFSET + s] = (numbers[0] == s);
        }

        // Then, for i = 1, ..., n-1, set
        // Q(i, OFFSET + s) := Q(i − 1, OFFSET + s) or (xi == s) or Q(i − 1, OFFSET + s − xi) for N <= s <= P.
        for (int i = 1; i < n; i++)
        { 
            for (int s = N; s <= P; s++)
            {
                Q[i, OFFSET + s] = Q[i - 1, OFFSET + s] || (numbers[i] == s) || Q[i - 1, OFFSET + s - numbers[i]]; 
            }
        }

        return Q[n - 1, OFFSET + sum];
    }

    /// <summary>
    /// Using Dynamic Programming.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    private static bool ContainsSubsetWhichSumsTo1(int[] numbers, int sum)
    {
        bool[] possible = new bool[OFFSET + OFFSET];

        int count = numbers.Length;
        int minPos = numbers[0];
        int maxPos = numbers[0];
        for (int i = 0; i < count; i++)
        {
            int newMinPos = minPos;
            int newMaxPos = maxPos;
            bool[] newPossible = new bool[OFFSET + OFFSET];
            for (int j = maxPos; j >= minPos; j--) // j = one possible sum
            {
                if (possible[j + OFFSET] == true)
                {
                    newPossible[j + numbers[i] + OFFSET] = true;
                }
                if (j + numbers[i] > newMaxPos)
                {
                    newMaxPos = j + numbers[i];
                }
                if (j + numbers[i] < newMinPos)
                {
                    newMinPos = j + numbers[i];
                }
            }

            minPos = newMinPos;
            maxPos = newMaxPos;

            for (int j = maxPos; j >= minPos; j--)
            {
                if (newPossible[j + OFFSET] == true)
                {
                    possible[j + OFFSET] = true;
                }
            }

            if (numbers[i] > maxPos)
            {
                maxPos = numbers[i];
            }
            if (numbers[i] < minPos)
            {
                minPos = numbers[i];
            }

            possible[numbers[i] + OFFSET] = true;
        }

        return possible[sum + OFFSET];
    }

    private static bool ContainsSubsetWhichSumsTo2(int[] numbers, int sum)
    {
        int numbersCount = numbers.Length;
        int subsetsCount = (1 << numbersCount);
        int subsetSum = 0;

        for (int i = 1; i < subsetsCount; i++)
        {
            subsetSum = 0;
            for (int j = 0; j < numbersCount; j++)
            {
                // if the i-th subset contains the j-th number,
                // then we add it to the sum
                checked
                {
                    subsetSum += ((i >> j) & 1) * numbers[j];
                }
            }

            if (subsetSum == sum)
            {
                return true;
            }
        }

        return false;
    }

    static void Main()
    {
        int numbersCount = 5;
        string numberAsString;
        int number;
        int[] numbers = new int[numbersCount];

        for (int i = 0; i < numbersCount; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                numberAsString = Console.ReadLine();
            }
            while (!Int32.TryParse(numberAsString, NumberStyles.Number, CultureInfo.InvariantCulture, out number));

            numbers[i] = number;
        }
        bool hasZeroSumSubset = false;

        try
        {
            hasZeroSumSubset = ContainsSubsetWhichSumsTo3(numbers, 0);
            Console.WriteLine("This set of numbers {0} a non-empty subset whose sum is zero.", hasZeroSumSubset ? "contains" : "doesn't contain");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
