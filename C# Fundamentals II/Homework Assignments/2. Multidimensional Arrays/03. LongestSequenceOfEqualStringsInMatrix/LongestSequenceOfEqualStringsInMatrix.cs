using Nakov.IO;
using System;
using System.Drawing;

class LongestSequenceOfEqualStringsInMatrix
{
    private static string[,] matrix;
    private static int n;
    private static int m;
    private static Point[] directions =
    {
        new Point(1, 0), // South
        new Point(1, 1), // South-East
        new Point(1, 1), // South-East
        new Point(0, 1), // East
        new Point(-1, 1), // North-East
        new Point(-1, 1) // North-East
    };

    private static int GetLengthOfAbsoluteLongestSequence(out Point startCell, out Point direction)
    {
        int maxLength = 1;
        startCell = new Point(0, 0);
        direction = directions[0]; // South

        int currentMaxLength;
        Point currentStartCell;

        int row = 0;
        int col = 0;
        int dirIndex = 0;
        // traverse the elements in the top row
        for (col = 0; col < m; col++)
        {
            for (dirIndex = 0; dirIndex < 2; dirIndex++)
            {
                currentMaxLength = GetLengthOfLongestSequenceOfEqualElements(dirIndex, new Point(0, col), out currentStartCell);

                if (maxLength < currentMaxLength)
                {
                    maxLength = currentMaxLength;
                    startCell = currentStartCell;
                    direction = directions[dirIndex];
                }
            }
        }

        // traverse the elements in the leftmost column
        for (row = 0; row < n; row++)
        {
            for (dirIndex = 2; dirIndex < 5; dirIndex++)
            {
                currentMaxLength = GetLengthOfLongestSequenceOfEqualElements(dirIndex, new Point(row, 0), out currentStartCell);

                if (maxLength < currentMaxLength)
                {
                    maxLength = currentMaxLength;
                    startCell = currentStartCell;
                    direction = directions[dirIndex];
                }
            }
        }

        // traverse the elements in the bottom row
        for (col = 0; col < m; col++)
        {
            currentMaxLength = GetLengthOfLongestSequenceOfEqualElements(directions.Length - 1, new Point(n - 1, col), out currentStartCell);

            if (maxLength < currentMaxLength)
            {
                maxLength = currentMaxLength;
                startCell = currentStartCell;
                direction = directions[dirIndex];
            }
        }

        return maxLength;
    }

    private static int GetLengthOfLongestSequenceOfEqualElements(int dirIndex, Point cell, out Point startCell)
    {
        int length = 1;
        int maxLength = 1;

        Point currentStartCell = cell;
        startCell = cell;

        int row = cell.X + directions[dirIndex].X;
        int col = cell.Y + directions[dirIndex].Y;

        while (row >= 0 && col >= 0 && row < n && col < m)
        {
            if (matrix[row, col].Equals(matrix[row - directions[dirIndex].X, col - directions[dirIndex].Y]))
            {
                length++;
            }

            // the adjacent elements are different - 
            // check if the sequence which has just finished
            // is the longest sequence so far
            if (!matrix[row, col].Equals(matrix[row - directions[dirIndex].X, col - directions[dirIndex].Y])
                || directions[dirIndex].X == -1 && row == 0
                || directions[dirIndex].X == 1 && row == n - 1
                || directions[dirIndex].Y == 1 && col == m - 1)
            {
                if (maxLength < length)
                {
                    maxLength = length;
                    startCell = currentStartCell;
                }

                currentStartCell.X = row;
                currentStartCell.Y = col;
                length = 1;
            }

            row += directions[dirIndex].X;
            col += directions[dirIndex].Y;
        }

        return maxLength;
    }

    private static void PrintMatrix<T>(T[,] value)
    {
        int rowsCount = value.GetLength(0);
        int colsCount = value.GetLength(1);

        int row;
        int col;
        int maxLength = Int32.MinValue;
        for (row = 0; row < rowsCount; row++)
        {
            for (col = 0; col < colsCount; col++)
            {
                int length = value[row, col].ToString().Length;
                if (maxLength < length)
                {
                    maxLength = length;
                }
            }
        }

        Console.WriteLine();

        for (row = 0; row < rowsCount; row++)
        {
            Console.Write("\t|");

            for (col = 0; col < colsCount; col++)
            {
                Console.Write(value[row, col].ToString().PadLeft(maxLength + 1, ' '));
            }

            Console.Write("{0,2}", '|');

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main()
    {
        string rowsCount;

        do
        {
            Console.Write("Enter number of rows: ");
            rowsCount = Console.ReadLine();

        }
        while (!Int32.TryParse(rowsCount, out n) || n < 2);

        string colsCount;

        do
        {
            Console.Write("Enter number of columns: ");
            colsCount = Console.ReadLine();

        }
        while (!Int32.TryParse(colsCount, out m) || m < 2);

        matrix = new string[n, m];

        Console.WriteLine("Enter the matrix as {0} rows containing {1} strings separated with spaces:", n, m);

        int row;
        int col;
        for (row = 0; row < n; row++)
        {
            for (col = 0; col < m; col++)
            {
                matrix[row, col] = Cin.NextToken();
            }
        }

        Console.WriteLine("Your matrix:");

        PrintMatrix(matrix);

        Point startCell;
        Point direction;
        int length = GetLengthOfAbsoluteLongestSequence(out startCell, out direction);

        Console.Write("The longest sequence of equal strings: ");

        row = startCell.X;
        col = startCell.Y;
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0} ", matrix[row, col]);
            row += direction.X;
            col += direction.Y;
        }

        Console.WriteLine();
    }
}
