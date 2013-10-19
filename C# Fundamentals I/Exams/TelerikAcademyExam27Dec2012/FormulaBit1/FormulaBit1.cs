using System;
using System.Drawing;

class FormulaBit1
{
    private static bool IsInGrid(Point car, int gridSize)
    {
        return car.X >= 0 && car.X < gridSize
            && car.Y >= 0 && car.Y < gridSize;
    }

    private static bool IsOutThroughSouthWestCorner(Point car, int gridSize)
    {
        return car.X == gridSize - 1 && car.Y >= gridSize
            || car.X >= gridSize && car.Y == gridSize - 1;
    }

    static void Main()
    {
        int n = 8;

        int[,] grid = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string numberAsString = Console.ReadLine();
            int number = Int32.Parse(numberAsString);

            for (int j = 0; j < n; j++)
            {
                grid[i, j] = (number >> j) & 1;
            }
        }

        Point[] directions = new Point[4];
        // South
        directions[0] = new Point(1, 0);
        // West
        directions[1] = new Point(0, 1);
        // North
        directions[2] = new Point(-1, 0);
        // West
        directions[3] = new Point(0, 1);

        int trackLength = 0;
        int turnsCount = 0;

        Point car = new Point(0, 0);

        Point currentDirection = directions[0];
        int currentDirectionIndex = 0;

        // start looking for a track
        while (true)
        {
            if (IsInGrid(car, n) && grid[car.X, car.Y] == 0)
            {
                trackLength++;
                car.X += currentDirection.X;
                car.Y += currentDirection.Y;
            }
            else
            {
                if (IsOutThroughSouthWestCorner(car, n))
                {
                    Console.WriteLine("{0} {1}", trackLength, turnsCount);
                    return;
                }

                // return to previous position
                car.X -= currentDirection.X;
                car.Y -= currentDirection.Y;

                // change direction
                currentDirectionIndex = (currentDirectionIndex + 1) % 4;
                currentDirection = directions[currentDirectionIndex];
                turnsCount++;

                // move ahead
                car.X += currentDirection.X;
                car.Y += currentDirection.Y;

                if (!IsInGrid(car, n) || grid[car.X, car.Y] == 1)
                {
                    Console.WriteLine("No {0}", trackLength);
                    return;
                }
            }
        }
    }
}
