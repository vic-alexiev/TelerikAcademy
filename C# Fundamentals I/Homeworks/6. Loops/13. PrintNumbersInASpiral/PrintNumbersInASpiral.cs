using System;
using System.Globalization;

class PrintNumbersInASpiral
{
    static void Main()
    {
        byte n;
        string numberN;

        do
        {
            Console.Write("Enter N in [2, 20): ");
            numberN = Console.ReadLine();
        }
        while (!Byte.TryParse(numberN, NumberStyles.Number, CultureInfo.InvariantCulture, out n) || n < 2 || n >= 20);

        int i;
        int j;
        int k;
        int counter = 1;
        int[,] matrix = new int[n, n];

        for (i = 0; i <= n / 2 - 1; i++)
        {
            for (j = i; j <= n - 2 - i; j++)
            {
                matrix[i, j] = counter++;
            }
            for (k = i; k <= n - 2 - i; k++)
            {
                matrix[k, j] = counter++;
            }
            for (j = n - 1 - i; j >= i + 1; j--)
            {
                matrix[k, j] = counter++;
            }
            for (k = n - 1 - i; k >= i + 1; k--)
            {
                matrix[k, j] = counter++;
            }
        }

        if (n % 2 != 0)
        {
            matrix[n / 2, n / 2] = counter;
        }



        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                Console.Write(" {0,2}", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}
