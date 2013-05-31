using System;
using System.Collections.Generic;

internal class ShortestPathsInLabyrinth
{
    private static readonly int[] DeltaRow = { -1, 0, 1, 0 };
    private static readonly int[] DeltaCol = { 0, 1, 0, -1 };
    private static readonly int DirectionsCount = 4;

    private static bool InLabyrinth(Cell cell, int labyrinthSize)
    {
        return cell.Row >= 0 && cell.Row < labyrinthSize &&
            cell.Col >= 0 && cell.Col < labyrinthSize;
    }

    private static void CalculateShortestPaths(string[,] labyrinth, Cell startingCell)
    {
        int labyrinthSize = labyrinth.GetLength(0);

        Queue<Cell> visitedCells = new Queue<Cell>();
        visitedCells.Enqueue(startingCell);

        while (visitedCells.Count > 0)
        {
            Cell cell = visitedCells.Dequeue();

            for (int i = 0; i < DirectionsCount; i++)
            {
                Cell nextCell = new Cell(
                    cell.Row + DeltaRow[i],
                    cell.Col + DeltaCol[i],
                    cell.Generation + 1);

                if (InLabyrinth(nextCell, labyrinthSize) &&
                    labyrinth[nextCell.Row, nextCell.Col] == "0")
                {
                    labyrinth[nextCell.Row, nextCell.Col] = Convert.ToString(nextCell.Generation);
                    visitedCells.Enqueue(nextCell);
                }
            }
        }
    }

    private static void Main()
    {
        string[,] labyrinth = new string[,]
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"},
        };

        CalculateShortestPaths(labyrinth, new Cell(2, 1, 0));

        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == "0")
                {
                    Console.Write("{0,3}", "u");
                }
                else
                {
                    Console.Write("{0,3}", labyrinth[row, col]);
                }
            }

            Console.WriteLine();
        }
    }
}
