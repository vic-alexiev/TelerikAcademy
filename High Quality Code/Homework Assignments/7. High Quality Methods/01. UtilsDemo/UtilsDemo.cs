// ********************************
// <copyright file="UtilsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Utils;

/// <summary>
/// Used to demonstrate the use of methods from the 
/// <see cref="Utils"/> namespace.
/// </summary>
internal class UtilsDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        Console.WriteLine(GeometryUtils.CalcTriangleArea(3, 4, 5));

        Console.WriteLine(LanguageUtils.DigitToText(5));

        Console.WriteLine(StatisticalUtils.Max(5, -1, 3, 2, 14, 2, 3));

        ConsolePrinter.PrintNumber(1.3, 2);
        ConsolePrinter.PrintPercent(0.75, 0);
        ConsolePrinter.PrintAligned(2.30, 8);

        Console.WriteLine(GeometryUtils.CalcDistance(3, -1, 3, 2.5));
        Console.WriteLine("Horizontal? " + GeometryUtils.IsLineHorizontal(3, -1, 3, 2.5));
        Console.WriteLine("Vertical? " + GeometryUtils.IsLineVertical(3, -1, 3, 2.5));

        Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", DateOfBirth = new DateTime(1992, 03, 17) };

        Student stella = new Student() { FirstName = "Stella", LastName = "Markova", DateOfBirth = new DateTime(1993, 11, 3) };

        Console.WriteLine(
            "Is {0} older than {1}? -> {2}",
            peter.FirstName,
            stella.FirstName,
            peter.DateOfBirth.IsEarlierThan(stella.DateOfBirth));
    }

    /// <summary>
    /// Represents a student.
    /// </summary>
    private class Student
    {
        /// <summary>
        /// Gets or sets student's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets student's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets student's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
