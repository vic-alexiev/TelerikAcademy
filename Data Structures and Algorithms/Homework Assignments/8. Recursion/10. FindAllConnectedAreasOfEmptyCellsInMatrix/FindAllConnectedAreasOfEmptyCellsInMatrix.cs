using System;

internal class FindAllConnectedAreasOfEmptyCellsInMatrix
{
    private static char[,] labyrinth = 
    {
        {' ', ' ', ' ', '#', ' ', ' ', ' '},
        {'#', '#', ' ', '#', ' ', '#', ' '},
        {' ', '#', ' ', '#', ' ', '#', ' '},
        {' ', '#', '#', '#', '#', '#', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
    };

    private static bool[,] visited;

    private static int FindConnectedArea(int row, int col)
    {
        if ((col < 0) ||
            (row < 0) ||
            (col >= labyrinth.GetLength(1)) ||
            (row >= labyrinth.GetLength(0)))
        {
            // We are out of the labyrinth
            return 0;
        }

        if (labyrinth[row, col] != ' ')
        {
            // The current cell is not free
            return 0;
        }

        if (visited[row, col])
        {
            // The current cell has already been visited
            return 0;
        }

        // mark visited
        visited[row, col] = true;
        int count = 0;

        // Invoke recursively to explore all possible directions
        count += FindConnectedArea(row, col - 1); // left
        count += FindConnectedArea(row - 1, col); // up
        count += FindConnectedArea(row, col + 1); // right
        count += FindConnectedArea(row + 1, col); // down

        return 1 + count;
    }

    private static void Main()
    {
        int rowsCount = labyrinth.GetLength(0);
        int colsCount = labyrinth.GetLength(1);

        visited = new bool[rowsCount, colsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < colsCount; col++)
            {
                if (labyrinth[row, col] == ' ' && !visited[row, col])
                {
                    int count = FindConnectedArea(row, col);

                    Console.WriteLine("Connected area containing {0} empty cells.", count);
                }
            }
        }
    }
}
