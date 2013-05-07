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
    /// <exception cref="System.ArgumentNullException">Thrown when 
    /// <paramref name="array"/> is null.</exception>
    public static void SelectionSort<T>(T[] array)
        where T : IComparable<T>
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "Value cannot be null.");
        }

        for (int index = 0; index < array.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);

            Swap(ref array[index], ref array[minElementIndex]);
        }
    }

    /// <summary>
    /// Finds the position of <paramref name="value"/> 
    /// in a sorted array.
    /// </summary>
    /// <typeparam name="T">The type of the array elements.</typeparam>
    /// <param name="array">The sorted one-dimensional, zero-based array to search.</param>
    /// <param name="value">The object to search for.</param>
    /// <returns>The index of <paramref name="value"/> in the array, -1 if it is not found.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when 
    /// <paramref name="array"/> is null.</exception>
    /// <exception cref="System.ArgumentException">Thrown when 
    /// <paramref name="array"/> is not sorted.</exception>
    /// <remarks>Since the algorithm doesn't work correctly for unsorted arrays, it throws
    /// an exception in that case.</remarks>
    public static int BinarySearch<T>(T[] array, T value)
        where T : IComparable<T>
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "Value cannot be null.");
        }

        if (array.Length == 0)
        {
            return -1;
        }

        if (!IsSorted(array))
        {
            throw new ArgumentException("array is not sorted. Binary search is not applicable.", "array");
        }

        int index = BinarySearch(array, value, 0, array.Length - 1);
        return index;
    }

    /// <summary>
    /// Checks if <paramref name="array"/> is sorted.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="array">The array to check.</param>
    /// <returns>True if <paramref name="array"/> is sorted in ascending order, 
    /// otherwise - false.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when 
    /// <paramref name="array"/> is null.</exception>
    public static bool IsSorted<T>(T[] array)
        where T : IComparable<T>
    {
        if (array == null)
        {
            throw new ArgumentNullException("array", "Value cannot be null.");
        }

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1].CompareTo(array[i]) > 0)
            {
                return false;
            }
        }

        return true;
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
        Debug.Assert(array != null, "Array is null.");
        Debug.Assert(array.Length > 0, "Array is empty");
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
        Debug.Assert(startIndex <= endIndex, "startIndex must be less than or equal to endIndex.");

        int minElementIndex = startIndex;

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (array[i].CompareTo(array[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(
            new Func<bool>(() =>
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (array[minElementIndex].CompareTo(array[i]) > 0)
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "Minimum element is not correctly identified.");

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
        Debug.Assert(array != null, "Array is null.");
        Debug.Assert(array.Length > 0, "Array is empty");
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
        Debug.Assert(startIndex <= endIndex, "startIndex must be less than or equal to endIndex.");

        Debug.Assert(
            new Func<bool>(() =>
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "The array is not sorted.");

        int initialStartIndex = startIndex;
        int initialEndIndex = endIndex;

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

        Debug.Assert(
            new Func<bool>(() =>
            {
                for (int i = initialStartIndex; i <= initialEndIndex; i++)
                {
                    if (array[i].Equals(value))
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "The index of value cannot be -1 since value is in the array.");

        // value not found
        return -1;
    }

    #endregion
}
