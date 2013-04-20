// ********************************
// <copyright file="ChronologyUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Utils
{
    using System;

    /// <summary>
    /// Contains methods extending those defined in the struct <see cref="System.DateTime"/>.
    /// </summary>
    public static class ChronologyUtils
    {
        /// <summary>
        /// Checks if the value of this instance is earlier than the specified <see cref="System.DateTime"/> value.
        /// </summary>
        /// <param name="thisValue">This instance.</param>
        /// <param name="value">The object to compare to the current instance.</param>
        /// <returns>True if this instance is earlier than <paramref name="value"/>, otherwise - false.</returns>
        public static bool IsEarlierThan(this DateTime thisValue, DateTime value)
        {
            return thisValue < value;
        }
    }
}
