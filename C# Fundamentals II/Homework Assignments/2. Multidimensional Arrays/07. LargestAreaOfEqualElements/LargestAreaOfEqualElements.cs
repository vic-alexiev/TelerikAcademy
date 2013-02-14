using Nakov.IO;
using System;
using System.Drawing;

class LargestAreaOfEqualElements
{
    private static Point[] neighbourDeltas =
    {
      new Point(-1, 0),
      new Point(0, 1),
      new Point(1, 0),
      new Point(0, -1)
    };

    private static int[,] matrix;
    private static bool[,] visited;
    private static int n;
    private static int m;

    private static bool CanBeVisited(int row, int col)
    {
        return row >= 0 && row < n
            && col >= 0 && col < m
            && visited[row, col] == false;
    }

    /// <summary>
    /// Uses DFS to find all the elements within reach from the cell given.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private static int FindAreaOfEqualElements(int row, int col)
    {
        int count = 0;
        int currentElement = matrix[row, col];
        // mark visited
        visited[row, col] = true;

        // traverse neighbours
        foreach (Point neighbourDelta in neighbourDeltas)
        {
            int newRow = row + neighbourDelta.X;
            int newCol = col + neighbourDelta.Y;

            if (CanBeVisited(newRow, newCol) && matrix[newRow, newCol] == currentElement)
            {
                count += FindAreaOfEqualElements(newRow, newCol);
            }
        }

        return 1 + count;
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

        matrix = new int[n, m];
        visited = new bool[n, m];

        Console.WriteLine("Enter the matrix as {0} rows containing {1} integers separated with spaces:", n, m);

        int row;
        int col;
        for (row = 0; row < n; row++)
        {
            for (col = 0; col < m; col++)
            {
                matrix[row, col] = Cin.NextInt();
            }
        }

        Console.WriteLine("Your matrix:");

        Console.WriteLine(new Matrix(matrix));

        int maxCount = Int32.MinValue;
        int maxElementRow = 0;
        int maxElementCol = 0;

        for (row = 0; row < n; row++)
        {
            for (col = 0; col < m; col++)
            {
                if (!visited[row, col])
                {
                    int count = FindAreaOfEqualElements(row, col);

                    if (maxCount < count)
                    {
                        maxCount = count;
                        maxElementRow = row;
                        maxElementCol = col;
                    }
                }
            }
        }

        Console.WriteLine("The largest area contains {0} occurrences of the element {1}.",
            maxCount, matrix[maxElementRow, maxElementCol]);
    }
}
