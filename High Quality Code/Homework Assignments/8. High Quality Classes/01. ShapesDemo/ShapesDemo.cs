// ********************************
// <copyright file="ShapesDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Shapes;

/// <summary>
/// Demonstrates the use of various <see cref="Shape"/> objects.
/// </summary>
internal class ShapesDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        Circle circle = new Circle(5);
        Console.WriteLine(
            "I am a circle. My perimeter is {0:f2}. My area is {1:f2}.",
            circle.CalcPerimeter(),
            circle.CalcArea());

        Rectangle rectangle = new Rectangle(2, 3);
        Console.WriteLine(
            "I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.",
            rectangle.CalcPerimeter(),
            rectangle.CalcArea());
    }
}
