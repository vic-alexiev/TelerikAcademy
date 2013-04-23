// ********************************
// <copyright file="GeometryUtilsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace GeometryUtilsDemo
{
    using System;
    using GeometryUtils;

    /// <summary>
    /// A class which demonstrates the use of affine transformations.
    /// </summary>
    internal class GeometryUtilsDemo
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        private static void Main()
        {
            Point point = new Point(1, 0);
            double theta = Math.PI / 2;
            Point pointRotated = AffineTransformer.RotatePoint(point, theta);
            Console.WriteLine(pointRotated);

            Rectangle rectangle = new Rectangle(20, 10);
            Rectangle boundingBox = AffineTransformer.GetBoundingBoxAfterRotation(rectangle, theta / 3);
            Console.WriteLine(boundingBox);
        }
    }
}
