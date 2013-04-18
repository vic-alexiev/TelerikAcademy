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
internal class ConsolePrinter
{
    /// <summary>
    /// Prints <paramref name="value"/> to the console.
    /// </summary>
    /// <param name="value">The value to print.</param>
    public void Print(bool value)
    {
        Console.WriteLine(value);
    }
}
