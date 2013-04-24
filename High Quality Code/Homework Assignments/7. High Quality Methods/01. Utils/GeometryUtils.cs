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
    /// Contains methods useful for solving geometrical problems.
    /// </summary>
    public static class GeometryUtils
    {
        #region Public Methods

        /// <summary>
        /// Calculates the area of a triangle whose sides have lengths 
        /// <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.
        /// </summary>
        /// <param name="a">The length of side a.</param>
        /// <param name="b">The length of side b.</param>
        /// <param name="c">The length of side c.</param>
        /// <returns>The area of the triangle.</returns>
        /// <exception cref="System.ArgumentException">Thrown when
        /// at least one of the arguments is less than or equal to zero
        /// or when the lengths don't satisfy the triangle inequality theorem.</exception>
        /// <remarks>The triangle area is calculated using Heron's formula.</remarks>
        /// <seealso cref="http://en.wikipedia.org/wiki/Heron%27s_formula"/>
        /// <seealso cref="http://en.wikipedia.org/wiki/Triangle_inequality_theorem"/>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Side lengths must be positive.");
            }

            if (!FormTriangle(a, b, c))
            {
                throw new ArgumentException(
                    "A triangle cannot be constructed from three line segments " +
                    "if any of them is longer than the sum of the other two.");
            }

            // calculate the semiperimeter
            double s = (a + b + c) / 2;

            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        /// <summary>
        /// Calculates the distance between two points specified by their coordinates
        /// (x1, y1) and (x2, y2).
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>The distance between the two points.</returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            return distance;
        }

        /// <summary>
        /// Checks if the line defined by the points (x1, y1) and (x2, y2)
        /// is horizontal (parallel to the x-axis).
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>True if the line is horizontal, otherwise - false.</returns>
        public static bool IsLineHorizontal(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("The points shouldn't coincide. A single point cannot define a line.");
            }

            return y1 == y2;
        }

        /// <summary>
        /// Checks if the line defined by the points (x1, y1) and (x2, y2)
        /// is vertical (parallel to the y-axis).
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>True if the line is vertical, otherwise - false.</returns>
        public static bool IsLineVertical(double x1, double y1, double x2, double y2)
        {
            if (PointsCoincide(x1, y1, x2, y2))
            {
                throw new ArgumentException("The points shouldn't coincide. A single point cannot define a line.");
            }

            return x1 == x2;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if a, b and c can be the sides of a triangle.
        /// The triangle inequality theorem is used.
        /// </summary>
        /// <param name="a">The length of side a.</param>
        /// <param name="b">The length of side b.</param>
        /// <param name="c">The length of side c.</param>
        /// <returns>True if a triangle can be constructed, otherwise - false.</returns>
        private static bool FormTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        /// <summary>
        /// Checks if the points (x1, y1) and (x2, y2) coincide.
        /// </summary>
        /// <param name="x1">The x-coordinate of the first point.</param>
        /// <param name="y1">The y-coordinate of the first point.</param>
        /// <param name="x2">The x-coordinate of the second point.</param>
        /// <param name="y2">The y-coordinate of the second point.</param>
        /// <returns>True if the points coincide, otherwise - false.</returns>
        private static bool PointsCoincide(double x1, double y1, double x2, double y2)
        {
            return x1 == x2 && y1 == y2;
        }

        #endregion
    }
}
