using Nakov.IO;
using System;
using System.Linq;

class FindSubsetThatSumsToGivenNumber
{
    private const int OFFSET = 1024;

    /// <summary>
    /// Using the DP method described in Wikipedia.
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Subset_sum_problem#Pseudo-polynomial_time_dynamic_programming_solution"/>
    /// <param name="numbers"></param>
    /// <param name="sum"></param>
    /// <returns></returns>
    private static bool ContainsSubsetWhichSumsTo(int[] numbers, int sum)
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

    static void Main()
    {
        string numberS;
        int s;

        do
        {
            Console.Write("Enter the sum: ");
            numberS = Console.ReadLine();
        }
        while (!Int32.TryParse(numberS, out s) || s <= 0);

        string numberN;
        int n;

        do
        {
            Console.Write("Enter the size of the array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        int[] numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        bool subsetFound = ContainsSubsetWhichSumsTo(numbers, s);

        Console.WriteLine("This set of numbers {0} a non-empty subset whose sum is {1}.",
            subsetFound ? "contains" : "doesn't contain", s);
    }
}
