using System;

class MatrixDemo
{
    static void Main()
    {
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

            Matrix<int> m1 = new Matrix<int>(matrix1);
            Matrix<int> m2 = new Matrix<int>(matrix2);

            Console.WriteLine(m1 + m2);
            Console.WriteLine(m1 - m2);
            Console.WriteLine(m1 * m2);
            Console.WriteLine(m1.Transpose());
            Console.WriteLine(m1 * 5);

            if (m1)
            {
                Console.WriteLine("m1 contains non-zero items.");
            }

            Matrix<decimal> matrixOfDecimals = new Matrix<decimal>(10, 10);
            Console.WriteLine(matrixOfDecimals);
        }
        catch (MatrixException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
