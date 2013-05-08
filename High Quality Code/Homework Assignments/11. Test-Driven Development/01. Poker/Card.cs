// ********************************
// <copyright file="Card.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker
{
    using Poker.Enums;

    /// <summary>
    /// Represents a poker card.
    /// </summary>
    public class Card : ICard
    {
        #region Private Fields

        /// <summary>
        /// String representations of the card ranks.
        /// </summary>
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        /// <summary>
        /// Char representations of the card suits.
        /// </summary>
        private static readonly char[] Suits = { '♣', '♦', '♥', '♠' };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="rank">Card rank.</param>
        /// <param name="suit">Card suit.</param>
        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the rank of the card.
        /// </summary>
        public CardRank Rank { get; private set; }

        /// <summary>
        /// Gets the suit of the card.
        /// </summary>
        public CardSuit Suit { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the string representation of a card.
        /// </summary>
        /// <returns>The rank and suit of a card represented as a string.</returns>
        public override string ToString()
        {
            return Ranks[(int)this.Rank - 2] + Suits[(int)this.Suit];
        }

        /// <summary>
        /// Compares two <see cref="ICard"/> instances.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>Less than zero if this instance is of lower rank,
        /// zero if both cards are of the same rank, greater than zero if
        /// this instance is of higher rank.</returns>
        public int CompareTo(ICard other)
        {
            return this.Rank.CompareTo(other.Rank);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another 
        /// <see cref="ICard"/> object.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>True if objects are equal, otherwise - false.</returns>
        public bool Equals(ICard other)
        {
            return this.Rank == other.Rank && this.Suit == other.Suit;
        }

        #endregion
    }
}
