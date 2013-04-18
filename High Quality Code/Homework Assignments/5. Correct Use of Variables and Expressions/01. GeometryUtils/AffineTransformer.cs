// ********************************
// <copyright file="AffineTransformer.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace GeometryUtils
{
    using System;

    /// <summary>
    /// Performs affine transformations on geometric objects.
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Affine_transformation"/>
    public static class AffineTransformer
    {
        /// <summary>
        /// Rotates a point in the 2D Euclidean plane.
        /// </summary>
        /// <param name="point">The <see cref="GeometryUtils.Point"/> to rotate.</param>
        /// <param name="angleInRadians">The angle of rotation (theta).</param>
        /// <returns>A <see cref="GeometryUtils.Point"/> which is the result of
        /// rotating <paramref name="point"/> through an angle theta 
        /// counterclockwise about the origin.</returns>
        /// <remarks>If the point is at (x, y), the following formulae are used:
        /// x' = x * cos( theta ) - y * sin( theta )
        /// y' = x * sin( theta ) + y * cos( theta ),
        /// where (x', y') are the coordinates of the point after rotation.
        /// </remarks>
        /// <seealso cref="http://en.wikipedia.org/wiki/Rotation_(geometry)"/>
        public static Point RotatePoint(Point point, double angleInRadians)
        {
            double newX = (point.X * Math.Cos(angleInRadians)) - (point.Y * Math.Sin(angleInRadians));
            double newY = (point.X * Math.Sin(angleInRadians)) + (point.Y * Math.Cos(angleInRadians));

            return new Point(newX, newY);
        }
    }
}
