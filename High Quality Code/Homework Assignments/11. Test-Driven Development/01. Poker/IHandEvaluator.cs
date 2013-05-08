// ********************************
// <copyright file="IHandEvaluator.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker
{
    using Poker.Enums;

    /// <summary>
    /// Defines methods that a value type or class implements
    /// to evaluate poker hands.
    /// </summary>
    /// <remarks>The list of poker hands can be found at
    /// http://en.wikipedia.org/wiki/List_of_poker_hands.
    /// </remarks>
    public interface IHandEvaluator
    {
        /// <summary>
        /// Checks if <paramref name="hand"/> is a valid poker hand.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if the hand is valid, otherwise - false.</returns>
        bool IsValid(IHand hand);

        /// <summary>
        /// Gets the category of the specified hand.
        /// </summary>
        /// <param name="hand">The hand to evaluate.</param>
        /// <returns>The hand category.</returns>
        HandCategory GetCategory(IHand hand);

        /// <summary>
        /// Compares two poker hands.
        /// </summary>
        /// <param name="hand1">The first hand.</param>
        /// <param name="hand2">The second hand.</param>
        /// <returns>Less than zero if <paramref name="hand1"/> ranks lower than
        /// <paramref name="hand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="hand1"/> ranks higher than
        /// <paramref name="hand2"/>.</returns>
        int CompareHands(IHand hand1, IHand hand2);
    }
}
