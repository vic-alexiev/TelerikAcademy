// ********************************
// <copyright file="HandCategory.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker.Enums
{
    /// <summary>
    /// Specifies constants that define poker hand categories.
    /// </summary>
    public enum HandCategory : int
    {
        /// <summary>
        /// Hand category HighCard.
        /// </summary>
        HighCard = 0,

        /// <summary>
        /// Hand category OnePair.
        /// </summary>
        OnePair = 1,

        /// <summary>
        /// Hand category TwoPair.
        /// </summary>
        TwoPair = 2,

        /// <summary>
        /// Hand category ThreeOfAKind.
        /// </summary>
        ThreeOfAKind = 3,

        /// <summary>
        /// Hand category Straight.
        /// </summary>
        Straight = 4,

        /// <summary>
        /// Hand category Flush.
        /// </summary>
        Flush = 5,

        /// <summary>
        /// Hand category FullHouse.
        /// </summary>
        FullHouse = 6,

        /// <summary>
        /// Hand category FourOfAKind.
        /// </summary>
        FourOfAKind = 7,

        /// <summary>
        /// Hand category StraightFlush.
        /// </summary>
        StraightFlush = 8
    }
}
