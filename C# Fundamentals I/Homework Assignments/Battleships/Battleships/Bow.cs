// ********************************
// <copyright file="Bow.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    /// <summary>
    /// Represents the bow of a ship.
    /// </summary>
    public struct Bow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bow" /> struct with the specified coordinates.
        /// </summary>
        /// <param name="row">The row coordinate of the bow.</param>
        /// <param name="col">The column coordinate of the bow.</param>
        public Bow(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        /// <summary>
        /// Gets or sets the row coordinate of the bow.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the column coordinate of the bow.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Compares two <see cref="T:Bow" /> objects. The result specifies 
        /// whether the values of the <see cref="P:Bow.Row" /> and <see cref="P:Bow.Col" /> 
        /// properties of the two <see cref="T:Bow" /> objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="T:Bow" /> object to compare.</param>
        /// <param name="right">The right <see cref="T:Bow" /> object to compare.</param>
        /// <returns>True if the <see cref="P:Bow.Row" /> and <see cref="P:Bow.Col" /> values of 
        /// <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, false.</returns>
        public static bool operator ==(Bow left, Bow right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="T:Bow" /> objects. The result specifies whether the values of 
        /// the <see cref="P:Bow.Row" /> or <see cref="P:Bow.Col" /> properties of the two 
        /// <see cref="T:Bow" /> objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="T:Bow" /> object to compare.</param>
        /// <param name="right">The right <see cref="T:Bow" /> object to compare.</param>
        /// <returns>True if the values of either the <see cref="P:Bow.Row" /> property or 
        /// the <see cref="P:Bow.Col" /> property of <paramref name="left" /> and 
        /// <paramref name="right" /> differ; otherwise, false.</returns>
        public static bool operator !=(Bow left, Bow right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Specifies whether this <see cref="T:Bow" /> contains the same coordinates 
        /// as the specified <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object" /> to test.</param>
        /// <returns>True if <paramref name="obj" /> is a <see cref="T:Bow" /> 
        /// and has the same coordinates as this <see cref="T:Bow" />.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Bow))
            {
                return false;
            }

            Bow bow = (Bow)obj;
            if (bow.Row != this.Row)
            {
                return false;
            }

            return bow.Col == this.Col;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="T:Bow" />.
        /// </summary>
        /// <returns>An integer value that specifies a hash value 
        /// for this <see cref="T:Bow" />.</returns>
        public override int GetHashCode()
        {
            int prime = 83;
            int result = 1;

            unchecked
            {
                result = result * prime + this.Row.GetHashCode();
                result = result * prime + this.Col.GetHashCode();
            }

            return result;
        }
    }
}
