// ********************************
// <copyright file="Rectangle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Shapes
{
    using System;

    /// <summary>
    /// Represents a rectangle.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="width"/> 
        /// or <paramref name="height"/> is negative.</exception>        
        public Rectangle(double width, double height)
        {
            if (width < 0)
            {
                throw new ArgumentException("Width cannot be negative.");
            }

            if (height < 0)
            {
                throw new ArgumentException("Height cannot be negative.");
            }

            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Calculates the perimeter of the rectangle.
        /// </summary>
        /// <returns>The perimeter.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>The area.</returns>
        public override double CalcArea()
        {
            double area = this.Width * this.Height;
            return area;
        }
    }
}
