using Nakov.IO;
using System;

class FindKxKPlatformHavingMaximumSum
{
    private static int ComputeSum(int[,] matrix, int rowIndex, int colIndex, int platformSize)
    {
        int sum = 0;

        for (int row = rowIndex; row < rowIndex + platformSize; row++)
        {
            for (int col = colIndex; col < colIndex + platformSize; col++)
            {
                sum += matrix[row, col];
            }
        }

        return sum;
    }

    private static int RecomputeSum(int[,] matrix, int oldSum, int rowIndex, int colIndex, int platformSize)
    {
        int recomputedSum = oldSum;
        int row;
        for (row = rowIndex; row < rowIndex + platformSize; row++)
        {
            recomputedSum -= matrix[row, colIndex - 1];
            recomputedSum += matrix[row, colIndex + platformSize - 1];
        }

        return recomputedSum;
    }

    private static int GetPlatformMaximumSum(int[,] matrix, int platformSize, out int platformNorthWestRow, out int platformNorthWestCol)
    {
        int rowsCount = matrix.GetLength(0);
        int colsCount = matrix.GetLength(0);
        int sum = 0;
        int maxSum = Int32.MinValue;
        platformNorthWestRow = 0;
        platformNorthWestCol = 0;

        for (int row = 0; row <= rowsCount - platformSize; row++)
        {
            for (int col = 0; col <= colsCount - platformSize; col++)
            {
                if (col == 0)
                {
                    // compute the initial sum for every row
                    sum = ComputeSum(matrix, row, 0, platformSize);
                }
                else
                {
                    // remove the first column from the previous window
                    // and add the next column, thus moving the window to the right
                    // and saving large part of the previous sum
                    sum = RecomputeSum(matrix, sum, row, col, platformSize);
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    platformNorthWestRow = row;
                    platformNorthWestCol = col;
                }
            }
        }

        return maxSum;
    }

    static void Main()
    {
        int k = 3; // the size of the platform
        string rowsCount;
        int n;

        do
        {
            Console.Write("Enter number of rows: ");
            rowsCount = Console.ReadLine();

        }
        while (!Int32.TryParse(rowsCount, out n) || n < k);

        string colsCount;
        int m;

        do
        {
            Console.Write("Enter number of columns: ");
            colsCount = Console.ReadLine();

        }
        while (!Int32.TryParse(colsCount, out m) || m < k);

        int[,] matrix = new int[n, m];

        Console.WriteLine("Enter the matrix as {0} rows containing {1} integers separated with spaces:", n, m);

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = Cin.NextInt();
            }
        }

        Console.WriteLine("Your matrix:");

        Console.WriteLine(new Matrix(matrix));

        int northWestElementRow;
        int northWestElementCol;
        int maxSum = GetPlatformMaximumSum(matrix, k, out northWestElementRow, out northWestElementCol);

        Console.WriteLine("The {0}x{0}-platform whose elements have maximum sum ({1}) has a NW corner at [{2}, {3}].",
            k, maxSum, northWestElementRow, northWestElementCol);
    }
}
