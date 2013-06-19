using System;
using System.Collections.Generic;
using System.Linq;

internal class ColourfulMarbles
{
    private static long GetBinomialCoefficient(int n, int k)
    {
        if ((k < 0) || (k > n))
        {
            return 0;
        }

        if (k > n / 2)
        {
            k = n - k;
        }

        long result = 1;

        for (int i = 1; i <= k; i++)
        {
            result *= n--;
            result /= i;
        }

        return result;
    }

    /// <summary>
    /// Calculates the number of multiset permutations, which is given by the
    /// multinomial coefficient:
    /// http://en.wikipedia.org/wiki/Permutation#In_combinatorics
    /// and
    /// http://en.wikipedia.org/wiki/Multinomial_coefficient#Multinomial_coefficients
    /// </summary>
    /// <param name="n"></param>
    /// <param name="multiplicities"></param>
    /// <returns></returns>
    private static long GetMultinomialCoefficient(int n, int[] multiplicities)
    {
        long product = 1;
        int m = multiplicities.Length;

        for (int i = 0; i < m; i++)
        {
            int sum = 0;
            for (int j = 0; j <= i; j++)
            {
                sum += multiplicities[j];
            }

            long binomialCoefficient = GetBinomialCoefficient(sum, multiplicities[i]);

            product *= binomialCoefficient;
        }

        return product;
    }

    private static void Main()
    {
        string input = Console.ReadLine();

        int n = input.Length;

        Dictionary<char, int> colours = new Dictionary<char, int>();

        foreach (char letter in input)
        {
            if (!colours.ContainsKey(letter))
            {
                colours[letter] = 1;
            }
            else
            {
                colours[letter]++;
            }
        }

        long result = GetMultinomialCoefficient(n, colours.Values.ToArray());

        Console.WriteLine(result);
    }
}
