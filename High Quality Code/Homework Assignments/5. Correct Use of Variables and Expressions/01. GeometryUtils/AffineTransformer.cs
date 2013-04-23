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

        /// <summary>
        /// Gets the bounding box of a rectangle rotated at a specified angle.
        /// </summary>
        /// <param name="rectangle">The rectangle to rotate.</param>
        /// <param name="angleInRadians">The angle of rotation (measured in radians).</param>
        /// <returns>The bounding box of the rotated rectangle.</returns>
        /// <remarks>The width and height of the bounding box are calculated using the following formulae:
        /// w' = w * abs(cos( alpha )) + h * abs(sin( alpha ))
        /// h' = h * abs(cos( alpha )) + w * abs(sin( alpha )),
        /// where w and h are the width and height of the rectangle and alpha - the angle of rotation.
        /// </remarks>
        /// <seealso cref="http://unlogic.co.uk/posts/bounding-box-of-rotated-image.html"/>
        public static Rectangle GetBoundingBoxAfterRotation(Rectangle rectangle, double angleInRadians)
        {
            double width = (rectangle.Width * Math.Abs(Math.Cos(angleInRadians))) +
                (rectangle.Height * Math.Abs(Math.Sin(angleInRadians)));
            double height = (rectangle.Height * Math.Abs(Math.Cos(angleInRadians))) +
                (rectangle.Width * Math.Abs(Math.Sin(angleInRadians)));

            return new Rectangle(width, height);
        }
    }
}
