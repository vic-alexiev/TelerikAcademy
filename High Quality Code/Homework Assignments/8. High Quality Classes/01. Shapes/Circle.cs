// ********************************
// <copyright file="Circle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Shapes
{
    using System;

    /// <summary>
    /// Represents a circle.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="radius"/> is negative.</exception>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius cannot be negative.");
            }

            this.Radius = radius;
        }

        /// <summary>
        /// Gets the radius.
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Calculates the perimeter of the circle.
        /// </summary>
        /// <returns>The perimeter.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculates the area of the circle.
        /// </summary>
        /// <returns>The area.</returns>
        public override double CalcArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }
}
