// ********************************
// <copyright file="Move.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    /// <summary>
    /// Represents a move made by a chess piece on the board.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class.
        /// </summary>
        /// <param name="deltaRow">The row-offset caused by the move.</param>
        /// <param name="deltaCol">The col-offset caused by the move.</param>
        public Move(int deltaRow, int deltaCol)
        {
            this.DeltaRow = deltaRow;
            this.DeltaCol = deltaCol;
        }

        /// <summary>
        /// Gets the row-coordinate offset in position caused by the move.
        /// </summary>
        public int DeltaRow { get; private set; }

        /// <summary>
        /// Gets the col-coordinate offset in position caused by the move.
        /// </summary>
        public int DeltaCol { get; private set; }
    }
}