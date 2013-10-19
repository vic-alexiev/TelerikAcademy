using System;

class Bitball
{
    private static int n = 8;
    private static int[,] playField = new int[n, n];

    private static bool CanBeStopped(int i, int j, bool top)
    {
        if (top)
        {
            i++;
            while (i < n)
            {
                if (playField[i, j] == 1)
                {
                    return true;
                }
                i++;
            }

            return false;
        }
        else
        {
            i--;
            while (i >= 0)
            {
                if (playField[i, j] == 1)
                {
                    return true;
                }
                i--;
            }

            return false;
        }
    }

    static void Main()
    {
        int[,] topTeam = new int[n, n];
        int[,] bottomTeam = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string numberAsString = Console.ReadLine();
            int number = Int32.Parse(numberAsString);

            for (int j = 0; j < n; j++)
            {
                topTeam[i, j] = (number >> j) & 1;
            }
        }

        for (int i = 0; i < n; i++)
        {
            string numberAsString = Console.ReadLine();
            int number = Int32.Parse(numberAsString);

            for (int j = 0; j < n; j++)
            {
                bottomTeam[i, j] = (number >> j) & 1;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                playField[i, j] = topTeam[i, j] ^ bottomTeam[i, j];
            }
        }

        int topScore = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (topTeam[i, j] == 1 && playField[i, j] == 1 && !CanBeStopped(i, j, true))
                {
                    topScore += 1;
                }
            }
        }

        int bottomScore = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (bottomTeam[i, j] == 1 && playField[i, j] == 1 && !CanBeStopped(i, j, false))
                {
                    bottomScore += 1;
                }
            }
        }

        Console.WriteLine("{0}:{1}", topScore, bottomScore);
    }
}
