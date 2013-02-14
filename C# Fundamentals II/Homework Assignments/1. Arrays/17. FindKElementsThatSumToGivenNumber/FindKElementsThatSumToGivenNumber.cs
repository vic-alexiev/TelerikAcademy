using Nakov.IO;
using System;

class FindKElementsThatSumToGivenNumber
{
    private static int[] indices;
    private static int[] finalIndices;
    private static int[] numbers;
    private static int n;
    private static int k;
    private static int sum;

    private static bool CheckSum(int length)
    {
        int currentSum = 0;
        for (int i = 0; i < length; i++)
        {
            currentSum += numbers[indices[i]];
        }

        if (currentSum == sum)
        {
            finalIndices = (int[])indices.Clone();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Generates all combinations of k elements and checks if their
    /// sum is equal to (sum).
    /// </summary>
    /// <param name="i"></param>
    /// <param name="after"></param>
    /// <returns></returns>
    private static bool CheckCombinations(int i, int after)
    {
        if (i > k)
        {
            return false;
        }

        for (int j = after; j < n; j++)
        {
            indices[i - 1] = j;
            if (i == k)
            {
                if (CheckSum(i))
                {
                    return true;
                }
            }

            if (CheckCombinations(i + 1, j + 1))
            {
                return true;
            }
        }

        return false;
    }

    static void Main()
    {
        string sumAsString;

        do
        {
            Console.Write("Enter the sum: ");
            sumAsString = Console.ReadLine();
        }
        while (!Int32.TryParse(sumAsString, out sum) || sum <= 0);

        string numberN;

        do
        {
            Console.Write("Enter the size of the array: ");
            numberN = Console.ReadLine();
        }
        while (!Int32.TryParse(numberN, out n) || n <= 0);

        string numberK;

        do
        {
            Console.Write("Enter the size of the subsets: ");
            numberK = Console.ReadLine();
        }
        while (!Int32.TryParse(numberK, out k) || k <= 0 || k > n);

        numbers = new int[n];

        Console.Write("Enter {0} integers separated by spaces: ", n);

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Cin.NextInt();
        }

        indices = new int[k];
        finalIndices = new int[k];

        bool subsetFound = CheckCombinations(1, 0);

        if (subsetFound)
        {
            Console.Write("Elements that sum to {0}: ", sum);

            for (int i = 0; i < k; i++)
            {
                Console.Write("{0} ", numbers[finalIndices[i]]);
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No {0}-element subset sums to {1}.", k, sum);
        }
    }
}
