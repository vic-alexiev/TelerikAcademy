// ********************************
// <copyright file="ChessPiece.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;

    /// <summary>
    /// Represents a chess piece.
    /// </summary>
    public class ChessPiece : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPiece"/> class.
        /// </summary>
        /// <param name="type">The chess piece type.</param>
        /// <param name="character">The chess piece character.</param>
        /// <param name="row">The row-position on the chessboard.</param>
        /// <param name="col">The col-position on the chessboard.</param>
        public ChessPiece(ChessPieceType type, char character, int row, int col)
        {
            if (char.IsWhiteSpace(character))
            {
                throw new ArgumentException("character cannot be whitespace.", "character");
            }

            this.Character = character;
            this.Type = type;
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Gets the chess piece type.
        /// </summary>
        public ChessPieceType Type { get; private set; }

        /// <summary>
        /// Gets the chess piece character.
        /// </summary>
        public char Character { get; private set; }

        /// <summary>
        /// Gets or sets the number of moves made by the chess piece.
        /// </summary>
        public int MovesMade { get; set; }

        /// <summary>
        /// Gets or sets the row-coordinate on the chessboard.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the col-coordinate on the chessboard.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Performs a deep copy of the <see cref="ChessPiece"/> object.
        /// </summary>
        /// <returns>A copy of the object being cloned.</returns>
        public object Clone()
        {
            ChessPiece clone = new ChessPiece(this.Type, this.Character, this.Row, this.Col);
            clone.MovesMade = this.MovesMade;
            return clone;
        }
    }
}