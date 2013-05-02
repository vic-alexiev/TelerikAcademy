// ********************************
// <copyright file="StringUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Miscellanea
{
    using System;
    using System.Text;

    /// <summary>
    /// Contains methods for operations with string objects.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Retrieves the last <paramref name="length"/> characters
        /// from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The string whose ending is retrieved.</param>
        /// <param name="length">The number of characters to extract.</param>
        /// <returns>A string which is equivalent to the last <paramref name="length"/>
        /// characters of the specified string.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="value"/>
        /// is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="length"/>
        /// is less than zero or greater than the size of the specified array.</exception>
        public static string ExtractEnding(string value, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "value cannot be null.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            }

            if (length > value.Length)
            {
                throw new ArgumentOutOfRangeException("length", "length cannot be greater than the length of the string.");
            }

            StringBuilder result = new StringBuilder();

            for (int i = value.Length - length; i < value.Length; i++)
            {
                result.Append(value[i]);
            }

            return result.ToString();
        }
    }
}
