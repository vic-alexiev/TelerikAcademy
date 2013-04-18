// ********************************
// <copyright file="ConsolePrinter.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;

/// <summary>
/// Used to print values to the console.
/// </summary>
internal static class ConsolePrinter
{
    /// <summary>
    /// Prints the parameter to the console.
    /// </summary>
    /// <param name="value">The value to print.</param>
    public static void PrintLine(double value)
    {
        Console.WriteLine(value);
    }
}
