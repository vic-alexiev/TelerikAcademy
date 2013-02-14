using Nakov.IO;
using System;

class MaximumContiguousSubsequenceSum
{
    /// <summary>
    /// A DP version. Uses one for-loop.
    /// <seealso cref="http://www.8bitavenue.com/2011/11/dynamic-programming-maximum-contiguous-sub-sequence-sum/"/>
    /// </summary>
    /// <param name="A"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private static int GetMaximumContiguousSubsequenceSum2(int[] A, out int start, out int end)
    {
        int n = A.Length;
        int[] M = new int[n];
        int[] b = new int[n];

        // Initialize the first value in (m) and (b)
        M[0] = A[0];
        b[0] = 0;

        // Initialize maxSum as the first element in (m)
        // we will keep updating maxSum until we get the
        // largest element in (m) which is indeed our
        // MCSS value. (k) saves the (j) position of 
        // the max value (MCSS)
        int maxSum = M[0];
        int k = 0;

        // For each subsequence ending at position (j)
        for (int j = 1; j < n; j++)
        {
            // m[j-1] + a[j] > a[j] is equivalent to m[j-1] > 0
            if (M[j - 1] > 0)
            {
                // Extending the current window at (j-1)
                M[j] = M[j - 1] + A[j];
                b[j] = b[j - 1];
            }
            else
            {
                // Starting a new window at (j)
                M[j] = A[j];
                b[j] = j;
            }

            // Update max and save (j)
            if (M[j] > maxSum)
            {
                maxSum = M[j];
                k = j;
            }
        }

        start = b[k];
        end = k;
        return maxSum;
    }

    /// <summary>
    /// The more straightforward solution. Uses two for-loops.
    /// <seealso cref="http://tkramesh.wordpress.com/2011/03/09/dynamic-programming-maximum-sum-contiguous-subsequence/"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private static int GetMaximumContiguousSubsequenceSum1(int[] value, out int start, out int end)
    {
        start = 0;
        end = 0;
        int n = value.Length;
        int maxSum = Int32.MinValue;

        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = i; j < n; j++)
            {
                sum += value[j];

                if (maxSum < sum)
                {
                    maxSum = sum;
                    start = i;
                    end = j;
                }
            }
        }

        return maxSum;
    }

    static void Main()
    {
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
        int maxSum = GetMaximumContiguousSubsequenceSum2(numbers, out start, out end);

        Console.WriteLine("The maximum contiguous subsequence sum is {0}.", maxSum);
        Console.Write("The subsequence is: ");

        for (int i = start; i <= end; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }
}
