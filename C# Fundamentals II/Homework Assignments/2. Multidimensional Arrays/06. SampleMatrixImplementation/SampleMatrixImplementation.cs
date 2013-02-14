using Nakov.IO;
using System;

class SampleMatrixImplementation
{
    static void Main()
    {
        string rowsCount;
        int n;

        do
        {
            Console.Write("Enter number of rows: ");
            rowsCount = Console.ReadLine();

        }
        while (!Int32.TryParse(rowsCount, out n) || n <= 1);

        string colsCount;
        int m;

        do
        {
            Console.Write("Enter number of columns: ");
            colsCount = Console.ReadLine();

        }
        while (!Int32.TryParse(colsCount, out m) || m <= 1);

        Matrix matrix = new Matrix(n, m);

        Console.WriteLine("Enter the matrix as {0} rows containing {1} integers separated with spaces:", n, m);

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = Cin.NextInt();
            }
        }

        Console.WriteLine("Your matrix:");

        Console.WriteLine(matrix);

        Console.WriteLine("Your matrix transposed:");

        Console.WriteLine(Matrix.Transpose(matrix));

        try
        {
            Console.WriteLine("Some hard coded tests:");

            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            int[,] matrix2 = new int[,]
            {
                {4, 5, 6},
                {-1, 0, 7},
                {3, 2, 1}
            };

            Matrix m1 = new Matrix(matrix1);
            Matrix m2 = new Matrix(matrix2);

            Console.WriteLine(m1 + m2);
            Console.WriteLine(m1 - m2);
            Console.WriteLine(m1 * m2);
            Console.WriteLine(Matrix.Transpose(m1));
            Console.WriteLine(m1 * 5);

        }
        catch (MatrixException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
