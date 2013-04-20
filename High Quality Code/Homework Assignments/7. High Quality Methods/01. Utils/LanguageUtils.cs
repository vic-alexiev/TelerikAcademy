// ********************************
// <copyright file="LanguageUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Utils
{
    using System;

    /// <summary>
    /// Contains methods useful for displaying data as English text.
    /// </summary>
    public static class LanguageUtils
    {
        /// <summary>
        /// Converts <paramref name="value"/> to an English word.
        /// </summary>
        /// <param name="value">The digit (0...9) to translate.</param>
        /// <returns>An English word.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// <paramref name="value"/> is not a digit.</exception>
        public static string DigitToText(int value)
        {
            switch (value)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("value was not in the range [0...9].");
            }
        }
    }
}
