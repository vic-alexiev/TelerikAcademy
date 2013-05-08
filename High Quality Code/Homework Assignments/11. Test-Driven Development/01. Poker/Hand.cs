// ********************************
// <copyright file="Hand.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using Poker.Enums;

    /// <summary>
    /// Represents a poker hand.
    /// </summary>
    public class Hand : IHand
    {
        /// <summary>
        /// A lookup table for the card ranks.
        /// </summary>
        private static Dictionary<string, CardRank> cardRanks;

        /// <summary>
        /// A lookup table for the card suits.
        /// </summary>
        private static Dictionary<char, CardSuit> cardSuits;

        /// <summary>
        /// Initializes static members of the <see cref="Hand"/> class.
        /// </summary>
        static Hand()
        {
            cardRanks = new Dictionary<string, CardRank>();
            cardRanks["2"] = CardRank.Two;
            cardRanks["3"] = CardRank.Three;
            cardRanks["4"] = CardRank.Four;
            cardRanks["5"] = CardRank.Five;
            cardRanks["6"] = CardRank.Six;
            cardRanks["7"] = CardRank.Seven;
            cardRanks["8"] = CardRank.Eight;
            cardRanks["9"] = CardRank.Nine;
            cardRanks["10"] = CardRank.Ten;
            cardRanks["J"] = CardRank.Jack;
            cardRanks["K"] = CardRank.King;
            cardRanks["Q"] = CardRank.Queen;
            cardRanks["A"] = CardRank.Ace;

            cardSuits = new Dictionary<char, CardSuit>();
            cardSuits['♣'] = CardSuit.Clubs;
            cardSuits['♦'] = CardSuit.Diamonds;
            cardSuits['♥'] = CardSuit.Hearts;
            cardSuits['♠'] = CardSuit.Spades;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand"/> class.
        /// </summary>
        /// <param name="cards">The cards in the hand.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when
        /// <paramref name="cards"/> is null.</exception>
        public Hand(ICard[] cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards", "cards cannot be null.");
            }

            this.Cards = cards;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand"/> class.
        /// </summary>
        /// <param name="cardNames">A string of card names (shorthand notation), 
        /// space-separated</param>
        /// <exception cref="System.ArgumentException">Thrown when
        /// <paramref name="cardNames"/> is null, empty or contains only
        /// whitespace characters.</exception>
        public Hand(string cardNames)
        {
            if (string.IsNullOrWhiteSpace(cardNames))
            {
                throw new ArgumentException("cardNames cannot be null or empty.", "cardNames");
            }

            string[] names = cardNames.Trim().Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            this.Cards = new ICard[names.Length];

            for (int i = 0; i < this.Cards.Length; i++)
            {
                int nameLength = names[i].Length;
                CardRank rank = cardRanks[names[i].Substring(0, nameLength - 1)];
                CardSuit suit = cardSuits[names[i][nameLength - 1]];
                this.Cards[i] = new Card(rank, suit);
            }
        }

        /// <summary>
        /// Gets the cards in the hand.
        /// </summary>
        public ICard[] Cards { get; private set; }

        /// <summary>
        /// Sorts (the cards in) the hand in ascending order.
        /// </summary>
        public void Sort()
        {
            Array.Sort(this.Cards);
        }

        /// <summary>
        /// Returns the string representations of the cards in the hand,
        /// space-separated.
        /// </summary>
        /// <returns>A string containing the string representations 
        /// of the cards in the hand.</returns>
        public override string ToString()
        {
            this.Sort();
            return string.Join<ICard>(" ", this.Cards);
        }
    }
}
