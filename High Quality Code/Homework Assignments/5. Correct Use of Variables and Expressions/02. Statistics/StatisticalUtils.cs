// ********************************
// <copyright file="StatisticalUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Statistics
{
    using System;

    /// <summary>
    /// Contains methods which perform statistical calculations.
    /// </summary>
    public static class StatisticalUtils
    {
        /// <summary>
        /// Returns the maximum value in <paramref name="array"/>.
        /// </summary>
        /// <param name="array">A sequence of values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        public static double Max(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Sequence is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Sequence contains no elements.");
            }

            double max = double.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Returns the minimum value in <paramref name="array"/>.
        /// </summary>
        /// <param name="array">A sequence of values to determine the minimum value of.</param>
        /// <returns>The minimum value in the sequence.</returns>
        public static double Min(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Sequence is null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Sequence contains no elements.");
            }

            double min = double.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Computes the average of a sequence of values.
        /// </summary>
        /// <param name="array">A sequence of values to determine the average value of.</param>
        /// <returns>The average value of the elements in the sequence.</returns>
        public static double Average(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Sequence is null.");
            }

            int arrayLength = array.Length;

            if (arrayLength == 0)
            {
                throw new ArgumentException("Sequence contains no elements.");
            }

            double sum = 0;

            for (int i = 0; i < arrayLength; i++)
            {
                sum += array[i];
            }

            double average = sum / arrayLength;
            return average;
        }
    }
}
