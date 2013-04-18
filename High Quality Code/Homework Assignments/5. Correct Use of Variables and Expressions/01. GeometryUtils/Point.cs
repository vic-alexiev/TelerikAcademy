// ********************************
// <copyright file="Point.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace GeometryUtils
{
    /// <summary>
    /// Represents a point in the 2D Euclidean plane.
    /// </summary>
    public class Point
    {
        #region Private Fields

        /// <summary>
        /// The x-coordinate of this <see cref="GeometryUtils.Point"/>.
        /// </summary>
        private double x;

        /// <summary>
        /// The y-coordinate of this <see cref="GeometryUtils.Point"/>.
        /// </summary>
        private double y;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GeometryUtils.Point"/> class.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the x-coordinate of this <see cref="GeometryUtils.Point"/>.</summary>
        /// <returns>The x-coordinate of this <see cref="GeometryUtils.Point"/>.</returns>
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        /// <summary>Gets or sets the y-coordinate of this <see cref="GeometryUtils.Point"/>.</summary>
        /// <returns>The y-coordinate of this <see cref="GeometryUtils.Point"/>.</returns>
        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts the coordinates of this <see cref="GeometryUtils.Point"/>.
        /// to their string representation. 
        /// </summary>
        /// <returns>A string which contains the coordinates
        /// of this <see cref="GeometryUtils.Point"/>.</returns>
        public override string ToString()
        {
            return string.Format("({0:N4}, {1:N4})", this.x, this.y);
        }

        #endregion
    }
}
