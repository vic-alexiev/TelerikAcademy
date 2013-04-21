// ********************************
// <copyright file="GeometryUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Utils
{
    using System;

    /// <summary>
    /// Contains methods which are useful when working with geometric objects.
    /// </summary>
    public static class GeometryUtils
    {
        /// <summary>
        /// Returns the distance between two points in the 2D Euclidean space.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>The distance.</returns>
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            return distance;
        }

        /// <summary>
        /// Returns the distance from a given point (x, y) to the origin O(0, 0).
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <returns>The distance.</returns>
        public static double CalcDistanceToOrigin2D(double x, double y)
        {
            double distance = CalcDistance2D(0, 0, x, y);
            return distance;
        }

        /// <summary>
        /// Returns the distance between two points in the 3D Euclidean space.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="z1">The z-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <param name="z2">The z-coordinate of the second point.</param>
        /// <returns>The distance.</returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)) + ((z1 - z2) * (z1 - z2)));
            return distance;
        }

        /// <summary>
        /// Returns the distance from a given point (x, y, z) to the origin O(0, 0, 0).
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="z">The z-coordinate of the point.</param>
        /// <returns>The distance.</returns>
        public static double CalcDistanceToOrigin3D(double x, double y, double z)
        {
            double distance = CalcDistance3D(0, 0, 0, x, y, z);
            return distance;
        }
    }
}
