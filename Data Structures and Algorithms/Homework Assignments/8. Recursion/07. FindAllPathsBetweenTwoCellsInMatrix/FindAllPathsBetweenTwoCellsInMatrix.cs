using System;

internal class FindAllPathsBetweenTwoCellsInMatrix
{
    private static char[,] labyrinth = 
    {
        {' ', ' ', ' ', '#', ' ', ' ', ' '},
        {'#', '#', ' ', '#', ' ', '#', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '#', '#', '#', '#', '#', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
    };

    private static void PrintPath()
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                Console.Write(labyrinth[row, col] + " ");
            }

            Console.WriteLine();
        }
    }

    private static void FindPath(int row, int col)
    {
        if ((col < 0) ||
            (row < 0) ||
            (col >= labyrinth.GetLength(1)) ||
            (row >= labyrinth.GetLength(0)))
        {
            // We are out of the labyrinth
            return;
        }

        // Check if we have found the exit
        if (labyrinth[row, col] == 'e')
        {
            Console.WriteLine("Exit found!");
            PrintPath();
            return;
        }

        if (labyrinth[row, col] != ' ')
        {
            // The current cell is not free
            return;
        }

        // Mark the current cell as visited
        labyrinth[row, col] = 's';

        // Invoke recursion to explore all possible directions
        FindPath(row, col - 1); // left
        FindPath(row - 1, col); // up
        FindPath(row, col + 1); // right
        FindPath(row + 1, col); // down

        // Mark back the current cell as free
        labyrinth[row, col] = ' ';
    }

    private static void Main()
    {
        FindPath(0, 0);
    }
}
