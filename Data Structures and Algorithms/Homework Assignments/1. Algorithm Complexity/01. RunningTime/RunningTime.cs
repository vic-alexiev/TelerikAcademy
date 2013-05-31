using System;

internal class RunningTime
{
    /// <summary>
    /// Expected running time: O(n^2).
    /// The outer loop performs n iterations (n is the size of the array)
    /// and the inner loop's iterations are of the order of n.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private static long Compute(int[] array)
    {
        int n = array.Length;
        long count = 0;

        for (int i = 0; i < n; i++)
        {
            int start = 0;
            int end = n - 1;
            while (start < end)
            {
                if (array[start] < array[end])
                {
                    start++;
                    count++;
                }
                else
                {
                    end--;
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Returns the number of positive elements in the rows which start
    /// with an even element.
    /// Expected running time: O(n * m) 
    /// (n is the number of rows, m - the number of columns).
    /// The worst case is when the if-statements are always true:
    /// each line starts with an even number and all the elements 
    /// in the matrix are positive. Then "count++" will get executed exactly n * m times.
    /// In the other cases this number is reduced by a constant which can be ignored.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    private static long CalcCount(int[,] matrix)
    {
        long count = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int row = 0; row < n; row++)
        {
            if (matrix[row, 0] % 2 == 0)
            {
                for (int col = 0; col < m; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    /// <summary>
    /// Returns the sum of the elements in the matrix (using recursion).
    /// Expected running time: O(n * m)
    /// (n is the number of rows, m - the number of columns).
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="row"></param>
    /// <returns></returns>
    private static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int col = 0; col < m; col++)
        {
            sum += matrix[row, col];
        }

        if (row + 1 < n)
        {
            sum += CalcSum(matrix, row + 1);
        }

        return sum;
    }

    private static void Main()
    {
        int[] numbers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        Console.WriteLine(Compute(numbers));

        int[,] matrix = 
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine(CalcCount(matrix));
        Console.WriteLine(CalcSum(matrix, 0));
    }
}
