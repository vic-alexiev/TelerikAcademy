// ********************************
// <copyright file="ArrayUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using System.Diagnostics;

/// <summary>
/// Contains methods for sorting and searching in arrays.
/// </summary>
public static class ArrayUtils
{
    #region Public Methods

    /// <summary>
    /// Sorts the array using the selection sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="array">The array to sort.</param>
    public static void SelectionSort<T>(T[] array)
        where T : IComparable<T>
    {
        Debug.Assert(array != null, "Array is null.", "Cannot sort an array which is null.");
        Debug.Assert(array.Length > 0, "Array is empty", "An empty array cannot be sorted.");

        for (int index = 0; index < array.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);

            Debug.Assert(
                array[minElementIndex].CompareTo(array[index]) <= 0,
                "Minimum element is not correctly identified.");

            Swap(ref array[index], ref array[minElementIndex]);

            Debug.Assert(
                array[index].CompareTo(array[minElementIndex]) <= 0,
                "Swapping elements failed.");
        }
    }

    /// <summary>
    /// Finds the position of <paramref name="value"/> 
    /// in a sorted array.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="array">The sorted array to search in.</param>
    /// <param name="value">The value to find.</param>
    /// <returns>The index of <paramref name="value"/> in the array.</returns>
    public static int BinarySearch<T>(T[] array, T value)
        where T : IComparable<T>
    {
        Debug.Assert(array != null, "Array is null.", "Cannot sort an array which is null.");
        Debug.Assert(array.Length > 0, "Array is empty", "An empty array cannot be sorted.");

        for (int i = 1; i < array.Length; i++)
        {
            Debug.Assert(
                array[i - 1].CompareTo(array[i]) <= 0,
                "The array is not sorted.",
                "The elements {0} and {1} are not in the correct order.",
                array[i - 1],
                array[i]);
        }

        int index = BinarySearch(array, value, 0, array.Length - 1);

        Debug.Assert(
            index == -1 || (index >= 0 && index < array.Length),
            "Binary search index is invalid.",
            "Binary search returned an invalid index: {0}.",
            index);

        return index;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Finds the index of the minimum element in the range specified by
    /// <paramref name="startIndex"/> and <paramref name="endIndex"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements.</typeparam>
    /// <param name="array">The array to search in.</param>
    /// <param name="startIndex">The left bound of the range.</param>
    /// <param name="endIndex">The right bound of the range.</param>
    /// <returns>The index of the minimum element in the specified range.</returns>
    private static int FindMinElementIndex<T>(T[] array, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(array != null, "Array is null.", "Cannot sort an array which is null.");
        Debug.Assert(array.Length > 0, "Array is empty", "An empty array cannot be sorted.");
        Debug.Assert(
            startIndex >= 0 && startIndex < array.Length,
            "startIndex is invalid.",
            "startIndex is not in the range between 0 and {0}.",
            array.Length - 1);
        Debug.Assert(
            endIndex >= 0 && endIndex < array.Length,
            "endIndex is invalid.",
            "endIndex is not in the range between 0 and {0}.",
            array.Length - 1);
        Debug.Assert(startIndex <= endIndex, "startIndex should be less than or equal to endIndex.");

        int minElementIndex = startIndex;

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (array[i].CompareTo(array[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    /// <summary>
    /// Swaps the values of <paramref name="x"/> and
    /// <paramref name="y"/>. The change is reflected
    /// in the original variables passed as parameters.
    /// </summary>
    /// <typeparam name="T">The type of the variables to swap.</typeparam>
    /// <param name="x">The first variable.</param>
    /// <param name="y">The second variable.</param>
    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    /// <summary>
    /// Searches for <paramref name="value"/> in the specified array.
    /// The range of search is bounded by <paramref name="startIndex"/>
    /// and <paramref name="endIndex"/>.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="array">The array to search in.</param>
    /// <param name="value">The value to search for in the array.</param>
    /// <param name="startIndex">Search starting index.</param>
    /// <param name="endIndex">Search ending index.</param>
    /// <returns>The index of <paramref name="value"/> in the array, or -1 if it is not found.</returns>
    private static int BinarySearch<T>(T[] array, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(array != null, "Array is null.", "Cannot sort an array which is null.");
        Debug.Assert(array.Length > 0, "Array is empty", "An empty array cannot be sorted.");
        Debug.Assert(
            startIndex >= 0 && startIndex < array.Length,
            "startIndex is invalid.",
            "startIndex is not in the range between 0 and {0}.",
            array.Length - 1);
        Debug.Assert(
            endIndex >= 0 && endIndex < array.Length,
            "endIndex is invalid.",
            "endIndex is not in the range between 0 and {0}.",
            array.Length - 1);
        Debug.Assert(startIndex <= endIndex, "startIndex should be less than or equal to endIndex.");

        for (int i = 1; i < array.Length; i++)
        {
            Debug.Assert(
                array[i - 1].CompareTo(array[i]) <= 0,
                "The array is not sorted.",
                "The elements {0} and {1} are not in the correct order.",
                array[i - 1],
                array[i]);
        }

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (array[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (array[midIndex].CompareTo(value) < 0)
            {
                // search in the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // search in the left half
                endIndex = midIndex - 1;
            }
        }

        // value not found
        return -1;
    }

    #endregion
}
