// ********************************
// <copyright file="PokerDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Poker;
using Poker.Enums;

/// <summary>
/// Demonstrates the use of Poker classes.
/// </summary>
internal class PokerDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        try
        {
            IHandEvaluator handEvaluator = new HandEvaluator();

            ICard[] cards = new ICard[]
                {
                    new Card(CardRank.Queen, CardSuit.Hearts),
                    new Card(CardRank.Queen, CardSuit.Spades),
                    new Card(CardRank.Ten, CardSuit.Hearts),
                    new Card(CardRank.Queen, CardSuit.Diamonds),
                    new Card(CardRank.Queen, CardSuit.Clubs)
                };

            IHand hand = new Hand(cards);

            Console.WriteLine(handEvaluator.GetCategory(hand) == HandCategory.FourOfAKind);

            IHand handFromString = new Hand("7♠ 5♣ 4♦ 3♦ 2♣");
            Console.WriteLine(handFromString);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine(aex.Message);
        }
    }
}
