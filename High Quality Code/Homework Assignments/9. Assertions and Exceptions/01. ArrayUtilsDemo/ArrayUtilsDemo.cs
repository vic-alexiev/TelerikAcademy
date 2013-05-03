// ********************************
// <copyright file="ArrayUtilsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;

/// <summary>
/// Contains methods which test the functionality of the <see cref="ArrayUtils"/> class.
/// </summary>
internal class ArrayUtilsDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        try
        {
            int[] array = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("array = [{0}]", string.Join(", ", array));
            ArrayUtils.SelectionSort(array);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", array));

            // Test sorting empty array
            ArrayUtils.SelectionSort(new int[0]);

            // Test sorting single element array
            ArrayUtils.SelectionSort(new int[1]);

            Console.WriteLine(ArrayUtils.BinarySearch(array, -1000));
            Console.WriteLine(ArrayUtils.BinarySearch(array, 0));
            Console.WriteLine(ArrayUtils.BinarySearch(array, 17));
            Console.WriteLine(ArrayUtils.BinarySearch(array, 10));
            Console.WriteLine(ArrayUtils.BinarySearch(array, 1000));
        }
        catch (ArgumentNullException anex)
        {
            Console.WriteLine(anex.Message);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine(aex.Message);
        }
    }
}
