// ********************************
// <copyright file="HandTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace PokerUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using Poker.Enums;

    /// <summary>
    /// Used to test the <see cref="Hand"/> class.
    /// </summary>
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHandConstructor1_ThrowsException()
        {
            ICard[] cards = null;
            IHand hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandConstructor2_ThrowsException()
        {
            string cardNames = null;
            IHand hand = new Hand(cardNames);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandConstructor3_ThrowsException()
        {
            string cardNames = string.Empty;
            IHand hand = new Hand(cardNames);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHandConstructor4_ThrowsException()
        {
            string cardNames = "   ";
            IHand hand = new Hand(cardNames);
        }

        [TestMethod]
        public void TestHandToString1()
        {
            ICard[] cards = new ICard[0];
            IHand hand = new Hand(cards);

            Assert.AreEqual(string.Empty, hand.ToString(), "Hand constructor does not work correctly.");
        }

        [TestMethod]
        public void TestHandToString2()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardRank.Nine, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Hearts),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Five, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            Assert.AreEqual("2♥ 5♦ 9♠ J♣ A♦", hand.ToString(), "Hand conversion to string does not work correctly.");
        }

        [TestMethod]
        public void TestHandToString3()
        {
            ICard[] cards = new ICard[1]
            {
                new Card(CardRank.Jack, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            Assert.AreEqual("J♣", hand.ToString(), "Hand conversion to string does not work correctly.");
        }
    }
}
