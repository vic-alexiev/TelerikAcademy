// ********************************
// <copyright file="IHand.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker
{
    /// <summary>
    /// Defines properties and methods that a value type or class implements
    /// to represent a poker hand.
    /// </summary>
    public interface IHand
    {
        /// <summary>
        /// Gets the cards in the hand.
        /// </summary>
        ICard[] Cards { get; }

        /// <summary>
        /// Sorts (the cards in) the hand in ascending order.
        /// </summary>
        void Sort();

        /// <summary>
        /// Returns the string representations of the cards in the hand,
        /// space-separated.
        /// </summary>
        /// <returns>A string containing the string representations 
        /// of the cards in the hand.</returns>
        string ToString();
    }
}
