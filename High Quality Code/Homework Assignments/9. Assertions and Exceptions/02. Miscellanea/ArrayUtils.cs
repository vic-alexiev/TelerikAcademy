// ********************************
// <copyright file="ArrayUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Miscellanea
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains methods for processing arrays.
    /// </summary>
    public static class ArrayUtils
    {
        /// <summary>
        /// Retrieves a subsequence from the array. The subsequence starts at a specified
        /// position and has a specified length.
        /// </summary>
        /// <typeparam name="T">The type of the array elements.</typeparam>
        /// <param name="array">The source sequence.</param>
        /// <param name="startIndex">The zero-based starting position of the subsequence.</param>
        /// <param name="length">The number of elements in the subsequence.</param>
        /// <returns>An array that is equivalent to the subsequence of length <paramref name="length"/>
        /// that begins at position <paramref name="startIndex"/>, or System.String.Empty 
        /// if startIndex is equal to the length of the array and length is zero.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="startIndex"/>
        /// plus <paramref name="length"/> indicates a position not within the array or when
        /// <paramref name="startIndex"/> or <paramref name="length"/> is less than zero.</exception>
        public static T[] Subsequence<T>(T[] array, int startIndex, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "array cannot be null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex", "startIndex cannot be less than zero.");
            }

            if (startIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than the length of the array.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            }

            if (startIndex > array.Length - length)
            {
                throw new ArgumentOutOfRangeException("length", "index and length must refer to a location within the array.");
            }

            if (length == 0)
            {
                return new T[0];
            }

            List<T> result = new List<T>();

            for (int i = startIndex; i < startIndex + length; i++)
            {
                result.Add(array[i]);
            }

            return result.ToArray();
        }
    }
}
