// ********************************
// <copyright file="StatisticsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using Statistics;

/// <summary>
/// A class which demonstrates the use of <see cref="Statistics.StatisticalUtils"/>.
/// </summary>
internal class StatisticsDemo
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    private static void Main()
    {
        double[] numbers = new double[] { 67.9, 12.1, 34.5 };

        double max = StatisticalUtils.Max(numbers);
        ConsolePrinter.PrintLine(max);

        double min = StatisticalUtils.Min(numbers);
        ConsolePrinter.PrintLine(min);

        double average = StatisticalUtils.Average(numbers);
        ConsolePrinter.PrintLine(average);
    }
}
