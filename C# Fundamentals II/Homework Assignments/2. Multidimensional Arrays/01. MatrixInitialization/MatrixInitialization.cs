using System;

class MatrixInitialization
{
    /// <summary>
    /// Recursively initializes the matrix layer by layer 
    /// inwards to the center.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="offset"></param>
    /// <param name="layerSize"></param>
    /// <param name="counter"></param>
    private static void InitializeLayerByLayer(int[,] value, int offset, int layerSize, int counter)
    {
        if (layerSize == 0)
        {
            return;
        }

        if (layerSize == 1)
        {
            value[offset, offset] = counter;
            return;
        }

        int row = offset;
        int col = offset;

        while (row < offset + layerSize - 1)
        {
            value[row, col] = counter++;
            row++;
        }

        while (col < offset + layerSize - 1)
        {
            value[row, col] = counter++;
            col++;
        }

        while (row > offset)
        {
            value[row, col] = counter++;
            row--;
        }

        while (col > offset)
        {
            value[row, col] = counter++;
            col--;
        }

        InitializeLayerByLayer(value, offset + 1, layerSize - 2, counter);
    }

    private static int[,] InitializeMatrixInSpiral1(int n)
    {
        int[,] matrix = new int[n, n];

        InitializeLayerByLayer(matrix, 0, n, 1);

        return matrix;
    }

    private static int[,] InitializeMatrixInSpiral2(int n)
    {
        int i;
        int j;
        int k;
        int counter = 1;
        int[,] matrix = new int[n, n];

        for (i = 0; i <= n / 2 - 1; i++)
        {
            for (k = i; k < n - 1 - i; k++)
            {
                matrix[k, i] = counter++;
            }

            for (j = i; j < n - 1 - i; j++)
            {
                matrix[k, j] = counter++;
            }

            for (k = n - 1 - i; k > i; k--)
            {
                matrix[k, j] = counter++;
            }

            for (j = n - 1 - i; j > i; j--)
            {
                matrix[k, j] = counter++;
            }
        }

        if (n % 2 != 0)
        {
            matrix[n / 2, n / 2] = counter;
        }

        return matrix;
    }

    private static int[,] InitializeMatrixDiagonalwise(int n)
    {
        int[,] matrix = new int[n, n];

        int row;
        int col;
        int counter = 1;
        for (row = n - 1; row >= 0; row--)
        {
            for (col = 0; row + col < n; col++)
            {
                matrix[row + col, col] = counter++;
            }
        }

        for (col = 1; col < n; col++)
        {
            for (row = 0; row + col < n; row++)
            {
                matrix[row, row + col] = counter++;
            }
        }

        return matrix;
    }

    private static int[,] InitializeMatrixSerpentineColumnwise(int n)
    {
        int[,] matrix = new int[n, n];

        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = counter++;
                }
            }
        }

        return matrix;
    }

    private static int[,] InitializeMatrixColumnwise(int n)
    {
        int[,] matrix = new int[n, n];

        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter++;
            }
        }

        return matrix;
    }

    static void Main()
    {
        string size;
        int n;

        do
        {
            Console.Write("Enter the size of the matrix: ");
            size = Console.ReadLine();

        }
        while (!Int32.TryParse(size, out n) || n <= 1);

        //int[,] firstMatrix = InitializeMatrixColumnwise(n);

        //int[,] secondMatrix = InitializeMatrixSerpentineColumnwise(n);

        int[,] thirdMatrix = InitializeMatrixDiagonalwise(n);

        //int[,] fourthMatrix = InitializeMatrixInSpiral2(n);

        Console.WriteLine(new Matrix(thirdMatrix));
    }
}
