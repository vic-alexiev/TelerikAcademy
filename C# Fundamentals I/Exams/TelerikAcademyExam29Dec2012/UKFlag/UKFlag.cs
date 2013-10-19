using System;

class UKFlag
{
    static void Main()
    {
        string numberN = Console.ReadLine();
        int n = Int32.Parse(numberN);

        int[,] canvas = new int[n, n];

        int row = -1;
        int col = -1;
        int row1 = -1;
        int col1 = n;

        for (int i = 0; i < n; i++)
        {
            // primary (main) diagonal
            canvas[++row, ++col] = 3;

            // secondary diagonal
            canvas[++row1, --col1] = 4;

            // vertical line
            canvas[row, n / 2] = 1;

            // horizontal line
            canvas[n / 2, col] = 2;
        }

        canvas[n / 2, n / 2] = 5;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                switch (canvas[i, j])
                {
                    case 0:
                        Console.Write(".");
                        break;
                    case 1:
                        Console.Write("|");
                        break;
                    case 2:
                        Console.Write("-");
                        break;
                    case 3:
                        Console.Write("\\");
                        break;
                    case 4:
                        Console.Write("/");
                        break;
                    default:
                        Console.Write("*");
                        break;
                }
            }

            Console.WriteLine();
        }
    }
}
