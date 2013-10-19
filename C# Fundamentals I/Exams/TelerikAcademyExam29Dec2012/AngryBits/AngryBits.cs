using System;

class AngryBits
{
    private static int n = 8;
    private static int[,] field = new int[n, 2 * n];

    private static int GetKilledPigs(int row, int col)
    {
        int pigsCount = 0;
        int startRow = Math.Max(0, row - 1);
        int endRow = Math.Min(n - 1, row + 1);
        int startCol = col + 1;
        int endCol = Math.Max(0, col - 1);

        // find the pigs in the 3x3 neighbourhood
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j >= endCol; j--)
            {
                if (field[i, j] == 1)
                {
                    pigsCount++;
                    // clear the bit
                    field[i, j] = 0;
                }
            }
        }

        return pigsCount;
    }

    /// <summary>
    /// Calculates the score of the bird located in field[row, col] - 
    /// the length of the flight multiplied by the number of pigs killed.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private static int ThrowBird(int row, int col)
    {
        // clear the bit of the bird
        field[row, col] = 0;

        bool flightFinished = false;
        int flight = 0;
        int pigsKilled = 0;
        int upFlight = row;
        int downFlight = Math.Min(n - 1, col - row);

        // fly upwards
        for (int i = 0; i < upFlight; i++)
        {
            flight++;
            // the bird has hit a pig
            if (field[--row, --col] == 1)
            {
                pigsKilled = GetKilledPigs(row, col);
                flightFinished = true;
                break;
            }
        }

        // fly downwards
        if (!flightFinished)
        {
            for (int i = 0; i < downFlight; i++)
            {
                flight++;
                // the bird has hit a pig
                if (field[++row, --col] == 1)
                {
                    pigsKilled = GetKilledPigs(row, col);
                    break;
                }
            }
        }

        return flight * pigsKilled;
    }

    /// <summary>
    /// Checks if there are remaining pigs on the right side
    /// of the field.
    /// </summary>
    /// <returns></returns>
    private static bool PlayerWins()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (field[i, j] == 1)
                {
                    return false;
                }
            }
        }

        return true;
    }

    static void Main()
    {
        for (int i = 0; i < n; i++)
        {
            string numberAsString = Console.ReadLine();
            int number = Int32.Parse(numberAsString);

            // fill the field with zeros and ones
            for (int j = 0; j < 2 * n; j++)
            {
                field[i, j] = (number >> j) & 1;
            }
        }

        int total = 0;

        // start looking for birds column by column
        for (int col = n; col < 2 * n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                if (field[row, col] == 1)
                {
                    // this is a bird - throw it at the pigs
                    total += ThrowBird(row, col);
                    // one bird per column
                    break;
                }
            }
        }

        Console.WriteLine("{0} {1}", total, PlayerWins() ? "Yes" : "No");
    }
}
