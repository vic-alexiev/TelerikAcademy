// ********************************
// <copyright file="Square.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    using Battleships.Enums;

    /// <summary>
    /// Represents a grid square.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="ship">The ship occupying the square.</param>
        /// <param name="state">The square state.</param>
        public Square(Ship ship, SquareState state)
        {
            this.Ship = ship;
            this.State = state;
        }

        /// <summary>
        /// Gets or sets the ship occupying the square.
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// Gets or sets the state of the square.
        /// </summary>
        public SquareState State { get; set; }
    }
}
