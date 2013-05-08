// ********************************
// <copyright file="ICard.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker
{
    using System;
    using Poker.Enums;

    /// <summary>
    /// Defines properties and methods that a value type or class implements 
    /// to represent a poker card.
    /// </summary>
    public interface ICard : IComparable<ICard>, IEquatable<ICard>
    {
        /// <summary>
        /// Gets the rank of the card.
        /// </summary>
        CardRank Rank { get; }

        /// <summary>
        /// Gets the suit of the card.
        /// </summary>
        CardSuit Suit { get; }

        /// <summary>
        /// Returns the string representation of the card.
        /// </summary>
        /// <returns>The string representation of the <see cref="ICard"/> object.</returns>
        string ToString();
    }
}
