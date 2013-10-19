using System;

class TelerikLogo
{
    static void Main()
    {
        string numberN = Console.ReadLine();
        int n = Int32.Parse(numberN);

        int[,] screen = new int[3 * n - 2, 3 * n - 2];

        int row = n / 2 + 1;
        int col = -1;
        int index;
        for (index = 0; index <= n / 2; index++)
        {
            screen[--row, ++col] = 1;
        }

        for (index = 0; index < 2 * n - 2; index++)
        {
            screen[++row, ++col] = 1;
        }

        for (index = 0; index < n - 1; index++)
        {
            screen[++row, --col] = 1;
        }

        for (index = 0; index < n - 1; index++)
        {
            screen[--row, --col] = 1;
        }

        for (index = 0; index < 2 * n - 2; index++)
        {
            screen[--row, ++col] = 1;
        }

        for (index = 0; index < n / 2; index++)
        {
            screen[++row, ++col] = 1;
        }

        for (int i = 0; i < 3 * n - 2; i++)
        {
            for (int j = 0; j < 3 * n - 2; j++)
            {
                if (screen[i, j] == 0)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }

            Console.WriteLine();
        }
    }
}
