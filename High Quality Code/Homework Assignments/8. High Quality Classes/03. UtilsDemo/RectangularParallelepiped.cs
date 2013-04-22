// ********************************
// <copyright file="RectangularParallelepiped.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Utils;

/// <summary>
/// Represents a rectangular parallelepiped.
/// </summary>
public class RectangularParallelepiped
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RectangularParallelepiped"/> class.
    /// </summary>
    /// <param name="width">The length along the x-axis.</param>
    /// <param name="height">The length along the y-axis.</param>
    /// <param name="depth">The length along the z-axis.</param>
    /// <exception cref="System.ArgumentException">Thrown when <paramref name="width"/>,
    /// <paramref name="height"/> or <paramref name="depth"/> is negative.</exception>
    public RectangularParallelepiped(double width, double height, double depth)
    {
        if (width < 0 || height < 0 || depth < 0)
        {
            throw new ArgumentException("Dimensions cannot be negative.");
        }

        this.Width = width;
        this.Height = height;
        this.Depth = depth;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the width (length along the x-axis) of the 
    /// rectangular parallelepiped.
    /// </summary>
    public double Width { get; private set; }

    /// <summary>
    /// Gets the height (length along the y-axis) of the 
    /// rectangular parallelepiped.
    /// </summary>
    public double Height { get; private set; }

    /// <summary>
    /// Gets the depth (length along the z-axis) of the 
    /// rectangular parallelepiped.
    /// </summary>
    public double Depth { get; private set; }

    #endregion

    #region Public Methods

    /// <summary>
    /// Calculates the volume of the rectangular parallelepiped.
    /// </summary>
    /// <returns>The volume.</returns>
    public double CalcVolume()
    {
        double volume = this.Width * this.Height * this.Depth;
        return volume;
    }

    /// <summary>
    /// Calculates the length of the body diagonal of the parallelepiped.
    /// </summary>
    /// <returns>The length of the diagonal.</returns>
    public double CalcBodyDiagonal()
    {
        double distance = GeometryUtils.CalcDistanceToOrigin3D(this.Width, this.Height, this.Depth);
        return distance;
    }

    /// <summary>
    /// Calculates the length of the diagonal lying in the x,y-plane.
    /// </summary>
    /// <returns>The length of the diagonal.</returns>
    public double CalcDiagonalXY()
    {
        double distance = GeometryUtils.CalcDistanceToOrigin2D(this.Width, this.Height);
        return distance;
    }

    /// <summary>
    /// Calculates the length of the diagonal lying in the x,z-plane.
    /// </summary>
    /// <returns>The length of the diagonal.</returns>
    public double CalcDiagonalXZ()
    {
        double distance = GeometryUtils.CalcDistanceToOrigin2D(this.Width, this.Depth);
        return distance;
    }

    /// <summary>
    /// Calculates the length of the diagonal lying in the y,z-plane.
    /// </summary>
    /// <returns>The length of the diagonal.</returns>
    public double CalcDiagonalYZ()
    {
        double distance = GeometryUtils.CalcDistanceToOrigin2D(this.Height, this.Depth);
        return distance;
    }

    #endregion
}
