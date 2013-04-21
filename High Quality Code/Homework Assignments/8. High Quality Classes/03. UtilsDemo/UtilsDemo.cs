// ********************************
// <copyright file="UtilsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Utils;

/// <summary>
/// Demonstrates the use of <see cref="FileUtils"/> and 
/// <see cref="GeometryUtils"/> methods.
/// </summary>
internal class UtilsDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        Console.WriteLine(FileUtils.GetExtension("example"));
        Console.WriteLine(FileUtils.GetExtension("example.pdf"));
        Console.WriteLine(FileUtils.GetExtension("example.new.pdf"));

        Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
        Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
        Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

        Console.WriteLine(
            "Distance in the 2D space = {0:f2}",
            GeometryUtils.CalcDistance2D(1, -2, 3, 4));
        Console.WriteLine(
            "Distance in the 3D space = {0:f2}",
            GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

        RectangularParallelepiped prism = new RectangularParallelepiped(3, 4, 5);

        Console.WriteLine("Volume = {0:f2}", prism.CalcVolume());
        Console.WriteLine("Body Diagonal = {0:f2}", prism.CalcBodyDiagonal());
        Console.WriteLine("Diagonal XY = {0:f2}", prism.CalcDiagonalXY());
        Console.WriteLine("Diagonal XZ = {0:f2}", prism.CalcDiagonalXZ());
        Console.WriteLine("Diagonal YZ = {0:f2}", prism.CalcDiagonalYZ());
    }
}
