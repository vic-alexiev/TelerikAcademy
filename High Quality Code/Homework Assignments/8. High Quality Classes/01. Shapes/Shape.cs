// ********************************
// <copyright file="Shape.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Shapes
{
    using System;

    /// <summary>
    /// Represents a geometric shape.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Calculates the perimeter.
        /// </summary>
        /// <returns>The perimeter.</returns>
        public abstract double CalcPerimeter();

        /// <summary>
        /// Calculates the area.
        /// </summary>
        /// <returns>The area.</returns>
        public abstract double CalcArea();
    }
}
