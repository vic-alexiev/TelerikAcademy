// ********************************
// <copyright file="Rectangle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace GeometryUtils
{
    using System;

    /// <summary>
    /// Represents a rectangle.
    /// </summary>
    public class Rectangle
    {
        #region Private Fields

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        private double width;

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        private double height;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GeometryUtils.Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the width of this <see cref="GeometryUtils.Rectangle"/>.
        /// </summary>
        /// <value>Gets or sets the value of the width field.</value>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive.");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of this <see cref="GeometryUtils.Rectangle"/>.
        /// </summary>
        /// <value>Gets or sets the value of the height field.</value>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }

                this.height = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the string representation of this <see cref="GeometryUtils.Rectangle"/>
        /// </summary>
        /// <returns>A string containing the width and height of the rectangle.</returns>
        public override string ToString()
        {
            return string.Format("Rectangle(width: {0:N4}, height: {1:N4})", this.width, this.height);
        }

        #endregion
    }
}
