// ********************************
// <copyright file="MatrixTraversalDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using MatrixTraversal;

/// <summary>
/// Used to read the size of the matrix, traverse it
/// and display the result to the console.
/// </summary>
internal class MatrixTraversalDemo
{
    /// <summary>
    /// Reads the matrix size from the console. The method repeats the 
    /// prompt until a valid number is entered.
    /// </summary>
    /// <param name="maxSize">The maximum possible size of the matrix.</param>
    /// <returns>The matrix size entered by the user.</returns>
    private static int ReadMatrixSize(int maxSize)
    {
        string input;
        int size;

        do
        {
            Console.WriteLine("Enter n, the size of the matrix (0 < n <= {0}):", maxSize);
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out size) || size < 1 || size > maxSize);

        return size;
    }

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        int size = ReadMatrixSize(Matrix.MaxSize);

        Matrix matrix = new Matrix(size);

        matrix.Traverse();

        Console.WriteLine(matrix);
    }
}
