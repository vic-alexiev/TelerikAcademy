// ********************************
// <copyright file="ConsolePrinter.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;

/// <summary>
/// Used to print formatted values to the console.
/// </summary>
public static class ConsolePrinter
{
    /// <summary>
    /// Prints <paramref name="value"/> to the console with the specified precision.
    /// </summary>
    /// <param name="value">The value to print.</param>
    /// <param name="decimals">The number of decimal places in the displayed value.</param>
    public static void PrintNumber(double value, int decimals)
    {
        string format = "{0:F" + decimals + "}";
        Console.WriteLine(format, value);
    }

    /// <summary>
    /// Multiplies <paramref name="value"/> by 100 and displays it with a percent symbol.
    /// </summary>
    /// <param name="value">The value to print.</param>
    /// <param name="decimals">The number of decimal places in the displayed value.</param>
    public static void PrintPercent(double value, int decimals)
    {
        string format = "{0:P" + decimals + "}";
        Console.WriteLine(format, value);
    }

    /// <summary>
    /// Displays a new string that left/right-aligns the characters in the 
    /// string representation of <paramref name="value"/> by padding them 
    /// with spaces on the left/right, for a specified total length.
    /// </summary>
    /// <param name="value">The value to print.</param>
    /// <param name="totalWidth">The number of characters in the resulting string, equal to 
    /// the number of original characters plus any additional padding spaces.</param>
    /// <remarks>The type of alignment depends on the sign of <paramref name="totalWidth"/>. 
    /// If it is positive, the string is right-aligned, if negative - left-aligned.</remarks>
    public static void PrintAligned(object value, int totalWidth)
    {
        string format = "{0," + totalWidth + "}";
        Console.WriteLine(format, value);
    }
}
