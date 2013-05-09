// ********************************
// <copyright file="CardTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace PokerUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using Poker.Enums;

    /// <summary>
    /// Used to test the <see cref="Card"/> class.
    /// </summary>
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestCardToString1()
        {
            Card card = new Card(CardRank.Seven, CardSuit.Diamonds);
            Assert.AreEqual("7♦", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString2()
        {
            Card card = new Card(CardRank.Ace, CardSuit.Hearts);
            Assert.AreEqual("A♥", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString3()
        {
            Card card = new Card(CardRank.Two, CardSuit.Clubs);
            Assert.AreEqual("2♣", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString4()
        {
            Card card = new Card(CardRank.Queen, CardSuit.Spades);
            Assert.AreEqual("Q♠", card.ToString(), "Card conversion to string is incorrect.");
        }

        [TestMethod]
        public void TestCardToString5()
        {
            Card card = new Card(CardRank.Ten, CardSuit.Spades);
            Assert.AreEqual("10♠", card.ToString(), "Card conversion to string is incorrect.");
        }
    }
}
