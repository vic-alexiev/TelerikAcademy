using Nakov.IO;
using System;

class FindContiguousSubsequenceThatSumsToGivenNumber
{
    /// <summary>
    /// Uses one for-loop. Works only for arrays of non-negative numbers.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="sum"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private static bool FindSubsequenceThatSumsTo2(int[] array, int sum, out int start, out int end)
    {
        int n = array.Length;
        int currentSum = 0;
        start = -1;
        end = -1;

        for (int i = 0; i < n; i++)
        {
            currentSum += array[i];

            if (currentSum > sum)
            {
                // subtract the leftmost elements 
                // from the current sum until it becomes
                // less than or equal to the given sum
                do
                {
                    start++;
                    currentSum -= array[start];
                }
                while (currentSum > sum);
            }

            if (currentSum == sum)
            {
                start++;
                end = i;
                return true;
            }
        }

        return false;
    }

    private static bool FindSubsequenceThatSumsTo1(int[] array, int sum, out int start, out int end)
    {
        int n = array.Length;
        start = -1;
        end = -1;

        for (int i = 0; i < n; i++)
        {
            int currentSum = 0;
            for (int j = i; j < n; j++)
            {
                currentSum += array[j];

                if (currentSum == sum)
                {
                    start = i;
                    end = j;
                    return true;
                }
            }
        }

        return false;
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

        int start;
        int end;

        if (FindSubsequenceThatSumsTo2(numbers, s, out start, out end))
        {
            Console.Write("The following subsequence sums to {0}: ", s);

            int[] result = new int[end - start + 1];
            Array.Copy(numbers, start, result, 0, end - start + 1);
            Console.WriteLine(String.Join(", ", result));
        }
        else
        {
            Console.WriteLine("No contiguous subsequence sums to {0}.", s);
        }
    }
}
