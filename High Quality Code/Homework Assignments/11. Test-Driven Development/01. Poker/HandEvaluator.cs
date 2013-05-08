// ********************************
// <copyright file="HandEvaluator.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Poker.Enums;

    /// <summary>
    /// Defines methods which evaluate poker hands.
    /// </summary>
    /// <seealso cref="http://nsayer.blogspot.com/2007/07/algorithm-for-evaluating-poker-hands.html"/>
    public class HandEvaluator : IHandEvaluator
    {
        #region Fields

        /// <summary>
        /// Keeps the hand size.
        /// </summary>
        public const int HandSize = 5;

        /// <summary>
        /// Keeps the card ranks in a hand and their occurrences.
        /// </summary>
        private Dictionary<CardRank, int> histogram = new Dictionary<CardRank, int>();

        /// <summary>
        /// An array of all the card ranks which are used as keys in the histogram.
        /// </summary>
        private CardRank[] cardRanks = new CardRank[]
        {
            CardRank.Two,
            CardRank.Three,
            CardRank.Four,
            CardRank.Five,
            CardRank.Six,
            CardRank.Seven,
            CardRank.Eight,
            CardRank.Nine,
            CardRank.Ten,
            CardRank.Jack,
            CardRank.Queen,
            CardRank.King,
            CardRank.Ace
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HandEvaluator"/> class.
        /// </summary>
        public HandEvaluator()
        {
            this.ClearHistogram();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if <paramref name="hand"/> is a valid poker hand.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if the hand is valid, otherwise - false.</returns>
        public bool IsValid(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            ICard[] cards = hand.Cards;

            if (cards.Length != HandSize)
            {
                return false;
            }

            for (int i = 0; i < cards.Length - 1; i++)
            {
                for (int j = i + 1; j < cards.Length; j++)
                {
                    if (cards[i].Equals(cards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the category of the specified hand.
        /// </summary>
        /// <param name="hand">The hand to evaluate.</param>
        /// <returns>The hand category.</returns>
        /// <exception cref="System.ArgumentException">Thrown when
        /// <paramref name="hand"/> is invalid.</exception>
        public HandCategory GetCategory(IHand hand)
        {
            if (!this.IsValid(hand))
            {
                string message =
                    string.Format("Invalid hand. A hand always consists of {0} different cards.", HandSize);
                throw new ArgumentException(message, "hand");
            }

            var cardRanksOrderedByCountDescending = this.GetCardRanksOrderedByCountDescending(hand);

            if (cardRanksOrderedByCountDescending[0].Value == 4)
            {
                return HandCategory.FourOfAKind;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 3 &&
                cardRanksOrderedByCountDescending[1].Value == 2)
            {
                return HandCategory.FullHouse;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 3 &&
                cardRanksOrderedByCountDescending[1].Value == 1)
            {
                return HandCategory.ThreeOfAKind;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 2 &&
                cardRanksOrderedByCountDescending[1].Value == 2)
            {
                return HandCategory.TwoPair;
            }

            if (cardRanksOrderedByCountDescending[0].Value == 2 &&
                cardRanksOrderedByCountDescending[1].Value == 1 &&
                cardRanksOrderedByCountDescending[2].Value == 1)
            {
                return HandCategory.OnePair;
            }

            bool flush = this.CheckFlush(hand);

            bool straight = this.CheckStraight(hand);

            if (straight && flush)
            {
                return HandCategory.StraightFlush;
            }

            if (straight)
            {
                return HandCategory.Straight;
            }

            if (flush)
            {
                return HandCategory.Flush;
            }

            return HandCategory.HighCard;
        }

        /// <summary>
        /// Compares two poker hands.
        /// </summary>
        /// <param name="hand1">The first hand.</param>
        /// <param name="hand2">The second hand.</param>
        /// <returns>Less than zero if <paramref name="hand1"/> ranks lower than
        /// <paramref name="hand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="hand1"/> ranks higher than
        /// <paramref name="hand2"/>.</returns>
        public int CompareHands(IHand hand1, IHand hand2)
        {
            HandCategory category1 = this.GetCategory(hand1);
            HandCategory category2 = this.GetCategory(hand2);

            if (category1 < category2)
            {
                // hand1 ranks lower than hand2
                return -1;
            }

            if (category1 > category2)
            {
                // hand1 ranks above hand2
                return 1;
            }

            hand1.Sort();
            hand2.Sort();

            // hand1 and hand2 are of the same type
            switch (category1)
            {
                case HandCategory.StraightFlush:
                case HandCategory.Straight:
                    {
                        return this.CompareStraightHands(hand1, hand2);
                    }

                case HandCategory.FourOfAKind:
                    {
                        return this.CompareFourOfAKindHands(hand1, hand2);
                    }

                case HandCategory.FullHouse:
                    {
                        return this.CompareFullHouseHands(hand1, hand2);
                    }

                case HandCategory.Flush:
                    {
                        return this.CompareHighCardHands(hand1, hand2);
                    }

                case HandCategory.ThreeOfAKind:
                    {
                        return this.CompareThreeOfAKindHands(hand1, hand2);
                    }

                case HandCategory.TwoPair:
                    {
                        return this.CompareTwoPairHands(hand1, hand2);
                    }

                case HandCategory.OnePair:
                    {
                        return this.CompareOnePairHands(hand1, hand2);
                    }

                default:
                    {
                        return this.CompareHighCardHands(hand1, hand2);
                    }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Compares two One pair hands.
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>One pair is a hand that contains two cards of one rank, plus three cards 
        /// which are not of this rank nor the same as each other. Higher-ranking pairs defeat lower-ranking pairs; 
        /// if two hands have the same pair, the non-paired cards (the kickers) are compared in descending order 
        /// to determine the winner.</remarks>
        private int CompareOnePairHands(IHand sortedHand1, IHand sortedHand2)
        {
            ICard hand1PairFirstCard;
            ICard hand1HighestKicker;
            ICard hand1MiddleKicker;
            ICard hand1LowestKicker;

            this.GetCardsInOnePair(
                sortedHand1,
                out hand1PairFirstCard,
                out hand1HighestKicker,
                out hand1MiddleKicker,
                out hand1LowestKicker);

            ICard hand2PairFirstCard;
            ICard hand2HighestKicker;
            ICard hand2MiddleKicker;
            ICard hand2LowestKicker;

            this.GetCardsInOnePair(
                sortedHand2,
                out hand2PairFirstCard,
                out hand2HighestKicker,
                out hand2MiddleKicker,
                out hand2LowestKicker);

            int pairCompareResult = hand1PairFirstCard.CompareTo(hand2PairFirstCard);
            if (pairCompareResult != 0)
            {
                return pairCompareResult;
            }

            int highestKickerCompareResult = hand1HighestKicker.CompareTo(hand2HighestKicker);
            if (highestKickerCompareResult != 0)
            {
                return highestKickerCompareResult;
            }

            int middleKickerCompareResult = hand1MiddleKicker.CompareTo(hand2MiddleKicker);
            if (middleKickerCompareResult != 0)
            {
                return middleKickerCompareResult;
            }

            return hand1LowestKicker.CompareTo(hand2LowestKicker);
        }

        /// <summary>
        /// Gets the cards in a One pair hand.
        /// </summary>
        /// <param name="sortedHand">The one pair hand sorted.</param>
        /// <param name="pairFirstCard">The first card of the pair.</param>
        /// <param name="highestKicker">The highest kicker.</param>
        /// <param name="middleKicker">The middle kicker.</param>
        /// <param name="lowestKicker">The lowest kicker.</param>
        private void GetCardsInOnePair(IHand sortedHand, out ICard pairFirstCard, out ICard highestKicker, out ICard middleKicker, out ICard lowestKicker)
        {
            pairFirstCard = sortedHand.Cards[0];
            int pairFirstCardIndex = 0;
            for (int i = 1; i < sortedHand.Cards.Length - 1; i++)
            {
                if (sortedHand.Cards[i].CompareTo(sortedHand.Cards[i + 1]) == 0)
                {
                    pairFirstCard = sortedHand.Cards[i];
                    pairFirstCardIndex = i;
                    break;
                }
            }

            highestKicker = sortedHand.Cards[4];
            int highestKickerIndex = 4;
            if (pairFirstCardIndex == 3)
            {
                highestKicker = sortedHand.Cards[2];
                highestKickerIndex = 2;
            }

            if (highestKickerIndex == 4)
            {
                middleKicker = sortedHand.Cards[3];
                if (pairFirstCardIndex == 2)
                {
                    middleKicker = sortedHand.Cards[1];
                }
            }
            else
            {
                middleKicker = sortedHand.Cards[1];
            }

            lowestKicker = sortedHand.Cards[0];
            if (pairFirstCardIndex == 0)
            {
                lowestKicker = sortedHand.Cards[2];
            }
        }

        /// <summary>
        /// Compares two Two pair hands.
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>A hand that contains two cards of the same rank, plus two cards of another rank 
        /// (that match each other but not the first pair), plus any card not of either rank, 
        /// is called two pair. To rank two hands both containing two pair, the higher-ranking pair 
        /// of each is first compared, and the higher pair wins. If both hands have the same top pair, 
        /// then the second pair of each is compared. If both hands have the same two pairs, 
        /// the kicker determines the winner.</remarks>
        private int CompareTwoPairHands(IHand sortedHand1, IHand sortedHand2)
        {
            ICard hand1Kicker;
            ICard hand1HigherPairFirstCard;
            ICard hand1LowerPairFirstCard;
            this.GetCardsInTwoPair(sortedHand1, out hand1Kicker, out hand1HigherPairFirstCard, out hand1LowerPairFirstCard);

            ICard hand2Kicker;
            ICard hand2HigherPairFirstCard;
            ICard hand2LowerPairFirstCard;
            this.GetCardsInTwoPair(sortedHand2, out hand2Kicker, out hand2HigherPairFirstCard, out hand2LowerPairFirstCard);

            int higherPairCompareResult = hand1HigherPairFirstCard.CompareTo(hand2HigherPairFirstCard);
            if (higherPairCompareResult != 0)
            {
                return higherPairCompareResult;
            }

            int lowerPairCompareResult = hand1LowerPairFirstCard.CompareTo(hand2LowerPairFirstCard);
            if (lowerPairCompareResult != 0)
            {
                return lowerPairCompareResult;
            }

            return hand1Kicker.CompareTo(hand2Kicker);
        }

        /// <summary>
        /// Gets the cards in a Two pair hand.
        /// </summary>
        /// <param name="sortedHand">The two pair hand sorted.</param>
        /// <param name="kicker">The kicker.</param>
        /// <param name="higherPairFirstCard">The first card of the higher pair.</param>
        /// <param name="lowerPairFirstCard">The first card of the lower pair.</param>
        private void GetCardsInTwoPair(IHand sortedHand, out ICard kicker, out ICard higherPairFirstCard, out ICard lowerPairFirstCard)
        {
            kicker = sortedHand.Cards[0];
            int kickerIndex = 0;

            if (kicker.CompareTo(sortedHand.Cards[1]) == 0)
            {
                kicker = sortedHand.Cards[2];
                kickerIndex = 2;
                if (kicker.CompareTo(sortedHand.Cards[3]) == 0)
                {
                    kicker = sortedHand.Cards[4];
                    kickerIndex = 4;
                }
            }

            if (kickerIndex == 0)
            {
                higherPairFirstCard = sortedHand.Cards[3];
                lowerPairFirstCard = sortedHand.Cards[1];
            }
            else if (kickerIndex == 2)
            {
                higherPairFirstCard = sortedHand.Cards[3];
                lowerPairFirstCard = sortedHand.Cards[0];
            }
            else
            {
                higherPairFirstCard = sortedHand.Cards[2];
                lowerPairFirstCard = sortedHand.Cards[0];
            }
        }

        /// <summary>
        /// Compares two Three of a kind hands.
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>Three of a kind is a hand that contains three cards of the same rank, 
        /// plus two cards which are not of this rank nor the same as each other.
        /// A higher-valued three-of-a-kind defeats a lower-valued three-of-kind. 
        /// If two hands contain three of a kind of the same value, 
        /// the kickers are compared to break the tie.</remarks>
        private int CompareThreeOfAKindHands(IHand sortedHand1, IHand sortedHand2)
        {
            // Cards[2] in a sorted hand is guaranteed to be one of the group of three
            int groupOfThreeCompareResult = sortedHand1.Cards[2].CompareTo(sortedHand2.Cards[2]);

            if (groupOfThreeCompareResult != 0)
            {
                return groupOfThreeCompareResult;
            }

            ICard hand1HigherUnmatchedCard;
            ICard hand1LowerUnmatchedCard;
            this.GetUnmatchedCardsInThreeOfAKind(sortedHand1, out hand1HigherUnmatchedCard, out hand1LowerUnmatchedCard);

            ICard hand2HigherUnmatchedCard;
            ICard hand2LowerUnmatchedCard;
            this.GetUnmatchedCardsInThreeOfAKind(sortedHand2, out hand2HigherUnmatchedCard, out hand2LowerUnmatchedCard);

            int higherUnmatchedCardCompareResult = hand1HigherUnmatchedCard.CompareTo(hand2HigherUnmatchedCard);
            if (higherUnmatchedCardCompareResult != 0)
            {
                return higherUnmatchedCardCompareResult;
            }

            return hand1LowerUnmatchedCard.CompareTo(hand2LowerUnmatchedCard);
        }

        /// <summary>
        /// Gets the unmatched cards in a Three of a kind.
        /// </summary>
        /// <param name="sortedHand">The three-of-a-kind hand sorted.</param>
        /// <param name="higherUnmatchedCard">The higher unmatched card.</param>
        /// <param name="lowerUnmatchedCard">The lower unmatched card.</param>
        private void GetUnmatchedCardsInThreeOfAKind(IHand sortedHand, out ICard higherUnmatchedCard, out ICard lowerUnmatchedCard)
        {
            int groupOfThreeEndIndex = 2;

            if (sortedHand.Cards[3].CompareTo(sortedHand.Cards[2]) == 0)
            {
                groupOfThreeEndIndex = 3;
            }

            if (sortedHand.Cards[4].CompareTo(sortedHand.Cards[2]) == 0)
            {
                groupOfThreeEndIndex = 4;
            }

            if (groupOfThreeEndIndex == 2)
            {
                higherUnmatchedCard = sortedHand.Cards[4];
                lowerUnmatchedCard = sortedHand.Cards[3];
            }
            else if (groupOfThreeEndIndex == 3)
            {
                higherUnmatchedCard = sortedHand.Cards[4];
                lowerUnmatchedCard = sortedHand.Cards[0];
            }
            else
            {
                higherUnmatchedCard = sortedHand.Cards[1];
                lowerUnmatchedCard = sortedHand.Cards[0];
            }
        }

        /// <summary>
        /// Compares two High card or Flush hands (the algorithm is the same).
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>A high-card is a hand made of any five cards not matching any other hand category.
        /// A flush is a poker hand where all five cards are of the same suit, but not in sequence.
        /// Two high-card hands are ranked by comparing the highest-ranking card. If those are equal, 
        /// then the next highest-ranking card from each hand is compared, and so on 
        /// until a difference is found.</remarks>
        private int CompareHighCardHands(IHand sortedHand1, IHand sortedHand2)
        {
            for (int i = sortedHand1.Cards.Length - 1; i >= 0; i--)
            {
                int compareResult = sortedHand1.Cards[i].CompareTo(sortedHand2.Cards[i]);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }

            return 0;
        }

        /// <summary>
        /// Compares two Full house hands.
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>A full house is a hand that contains three matching cards of one rank 
        /// and two matching cards of another rank. Between two full houses, the one with 
        /// the higher-ranking three cards wins. If two hands have the same three cards, 
        /// the hand with the higher pair wins.</remarks>
        private int CompareFullHouseHands(IHand sortedHand1, IHand sortedHand2)
        {
            // Cards[2] in a sorted hand is guaranteed to be one of the group of three
            int groupOfThreeCompareResult = sortedHand1.Cards[2].CompareTo(sortedHand2.Cards[2]);

            if (groupOfThreeCompareResult != 0)
            {
                return groupOfThreeCompareResult;
            }

            ICard hand1PairFirstCard = sortedHand1.Cards[3];

            if (hand1PairFirstCard.CompareTo(sortedHand1.Cards[2]) == 0)
            {
                hand1PairFirstCard = sortedHand1.Cards[0];
            }

            ICard hand2PairFirstCard = sortedHand2.Cards[3];

            if (hand2PairFirstCard.CompareTo(sortedHand2.Cards[2]) == 0)
            {
                hand2PairFirstCard = sortedHand2.Cards[0];
            }

            return hand1PairFirstCard.CompareTo(hand2PairFirstCard);
        }

        /// <summary>
        /// Compares two Four of a kind hands.
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>Four of a kind (quads) is a hand that contains all four cards of one rank 
        /// and any other (unmatched) card. Quads with higher-ranking cards defeat 
        /// lower-ranking ones. If the hands contain the same quad, the unmatched card acts 
        /// as a kicker. If two hands have the same kicker, they tie and the pot is split.</remarks>
        private int CompareFourOfAKindHands(IHand sortedHand1, IHand sortedHand2)
        {
            // Cards[1] in a sorted hand is guaranteed to be one of the quad
            int quadCompareResult = sortedHand1.Cards[1].CompareTo(sortedHand2.Cards[1]);
            if (quadCompareResult != 0)
            {
                return quadCompareResult;
            }

            ICard hand1UnmatchedCard = sortedHand1.Cards[0];

            if (hand1UnmatchedCard.CompareTo(sortedHand1.Cards[1]) == 0)
            {
                hand1UnmatchedCard = sortedHand1.Cards[4];
            }

            ICard hand2UnmatchedCard = sortedHand2.Cards[0];

            if (hand2UnmatchedCard.CompareTo(sortedHand2.Cards[1]) == 0)
            {
                hand2UnmatchedCard = sortedHand2.Cards[4];
            }

            return hand1UnmatchedCard.CompareTo(hand2UnmatchedCard);
        }

        /// <summary>
        /// Compares two straight hands.
        /// </summary>
        /// <param name="sortedHand1">The first hand sorted.</param>
        /// <param name="sortedHand2">The second hand sorted.</param>
        /// <returns>Less than zero if <paramref name="sortedHand1"/> ranks lower than
        /// <paramref name="sortedHand2"/>, zero if the hands are of equal value,
        /// greater than zero if <paramref name="sortedHand1"/> ranks higher than
        /// <paramref name="sortedHand2"/>.</returns>
        /// <remarks>A straight is a poker hand that contains five cards of sequential rank.
        /// A straight flush is a hand that contains five cards in sequence, all of the same suit.
        /// Two straights are ranked by comparing the highest card of each.
        /// Two straights with the same high card are of equal value, suits are not used 
        /// to separate them. Aces can play low in straights and straight flushes.</remarks>
        private int CompareStraightHands(IHand sortedHand1, IHand sortedHand2)
        {
            CardRank hand1HighestRank = sortedHand1.Cards[4].Rank;

            if (sortedHand1.Cards[4].Rank == CardRank.Ace &&
                sortedHand1.Cards[3].Rank == CardRank.Five)
            {
                // a wheel
                hand1HighestRank = CardRank.Five;
            }

            CardRank hand2HighestRank = sortedHand2.Cards[4].Rank;

            if (sortedHand2.Cards[4].Rank == CardRank.Ace &&
                sortedHand2.Cards[3].Rank == CardRank.Five)
            {
                // a wheel
                hand2HighestRank = CardRank.Five;
            }

            return hand1HighestRank.CompareTo(hand2HighestRank);
        }

        /// <summary>
        /// Sets all the values in the histogram dictionary to zero.
        /// </summary>
        private void ClearHistogram()
        {
            foreach (CardRank rank in this.cardRanks)
            {
                this.histogram[rank] = 0;
            }
        }

        /// <summary>
        /// Returns an array of <see cref="KeyValuePair"/> objects
        /// which keeps the occurrences of each rank in the specified hand.
        /// </summary>
        /// <param name="hand">The hand to be analyzed.</param>
        /// <returns>An array of <see cref="KeyValuePair"/> objects 
        /// which keeps the occurrences of each rank in the hand.</returns>
        private KeyValuePair<CardRank, int>[] GetCardRanksOrderedByCountDescending(IHand hand)
        {
            this.ClearHistogram();

            foreach (ICard card in hand.Cards)
            {
                this.histogram[card.Rank]++;
            }

            return this.histogram.OrderByDescending(pair => pair.Value).ToArray();
        }

        /// <summary>
        /// Checks if all five cards are of the same suit.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if flush, otherwise - false.</returns>
        private bool CheckFlush(IHand hand)
        {
            ICard[] cards = hand.Cards;

            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[0].Suit != cards[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the hand contains five cards of sequential rank.
        /// </summary>
        /// <param name="hand">The hand to check.</param>
        /// <returns>True if straight, otherwise - false.</returns>
        private bool CheckStraight(IHand hand)
        {
            hand.Sort();

            if ((hand.Cards[4].Rank - hand.Cards[0].Rank) == 4)
            {
                return true;
            }

            if (hand.Cards[4].Rank == CardRank.Ace &&
                hand.Cards[3].Rank == CardRank.Five)
            {
                // a wheel: A, 2, 3, 4, 5
                return true;
            }

            return false;
        }

        #endregion
    }
}
