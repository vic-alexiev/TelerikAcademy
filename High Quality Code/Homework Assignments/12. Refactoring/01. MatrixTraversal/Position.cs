// ********************************
// <copyright file="Position.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace MatrixTraversal
{
    /// <summary>
    /// Represents the current position during matrix traversal.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="row">The row coordinate.</param>
        /// <param name="col">The col coordinate.</param>
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Gets or sets the row coordinate of the position.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the col coordinate of the position.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Updates the coordinates of the position by adding
        /// the specified delta.
        /// </summary>
        /// <param name="delta">The delta used for the update.</param>
        public void Update(Delta delta)
        {
            this.Row += delta.Row;
            this.Col += delta.Col;
        }
    }
}
