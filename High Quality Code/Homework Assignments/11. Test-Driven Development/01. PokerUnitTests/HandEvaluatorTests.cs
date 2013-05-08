// ********************************
// <copyright file="HandEvaluatorTests.cs" company="Telerik Academy">
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
    /// Used to test the <see cref="HandEvaluator"/> functionality.
    /// </summary>
    [TestClass]
    public class HandEvaluatorTests
    {
        /// <summary>
        /// The <see cref="IHandEvaluator"/> object used to evaluate poker hands.
        /// </summary>
        private static IHandEvaluator handEvaluator;

        [ClassInitialize]
        public static void HandEvaluatorInit(TestContext context)
        {
            handEvaluator = new HandEvaluator();
        }

        [TestMethod]
        public void TestIsValid1()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardRank.Nine, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Hearts),
                new Card(CardRank.Jack, CardSuit.Clubs),
                new Card(CardRank.Two, CardSuit.Hearts),
                new Card(CardRank.Five, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);

            bool validHand = handEvaluator.IsValid(hand);

            Assert.AreEqual(false, validHand, "Hand validation does not work correctly.");
        }

        [TestMethod]
        public void TestIsValid2()
        {
            bool validHand = handEvaluator.IsValid(null);

            Assert.AreEqual(false, validHand, "Hand validation does not work correctly.");
        }

        [TestMethod]
        public void TestIsValid3()
        {
            ICard[] cards = new ICard[3]
            {
                new Card(CardRank.Nine, CardSuit.Spades),
                new Card(CardRank.Two, CardSuit.Hearts),
                new Card(CardRank.Jack, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            bool validHand = handEvaluator.IsValid(hand);

            Assert.AreEqual(false, validHand, "Hand validation does not work correctly.");
        }

        [TestMethod]
        public void TestGetCategory1_HighCard()
        {
            ICard[] cards = new ICard[5]
            {
                new Card(CardRank.Queen, CardSuit.Diamonds),
                new Card(CardRank.King, CardSuit.Hearts),
                new Card(CardRank.Two, CardSuit.Hearts),
                new Card(CardRank.Eight, CardSuit.Spades),
                new Card(CardRank.Nine, CardSuit.Clubs)
            };

            IHand hand = new Hand(cards);

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.HighCard, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory2_HighCard()
        {
            IHand hand = new Hand("K♥ J♥ 8♣ 7♦ 4♠");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.HighCard, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory3_HighCard()
        {
            IHand hand = new Hand("7♠ 5♣ 4♦ 3♦ 2♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.HighCard, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory4_OnePair()
        {
            IHand hand = new Hand("4♥ 4♠ K♠ 10♦ 5♠");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.OnePair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory5_TwoPair()
        {
            IHand hand = new Hand("J♥ J♣ 4♣ 4♠ 9♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.TwoPair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory6_TwoPair()
        {
            IHand hand = new Hand("10♠ 10♣ 8♥ 8♣ 4♠");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.TwoPair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory7_TwoPair()
        {
            IHand hand = new Hand("8♥ 8♣ 4♠ 4♣ 10♠");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.TwoPair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory8_TwoPair()
        {
            IHand hand = new Hand("10♠ 10♣ 4♠ 4♥ 8♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.TwoPair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory9_TwoPair()
        {
            IHand hand = new Hand("10♠ 10♣ 8♥ 8♣ A♦");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.TwoPair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory10_TwoPair()
        {
            IHand hand = new Hand("K♣ K♦ 9♠ 9♥ 5♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.TwoPair, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory11_ThreeOfAKind()
        {
            IHand hand = new Hand("2♦ 2♠ 2♣ K♠ 6♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.ThreeOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory12_ThreeOfAKind()
        {
            IHand hand = new Hand("Q♠ Q♥ Q♦ 7♠ 4♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.ThreeOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory13_ThreeOfAKind()
        {
            IHand hand = new Hand("J♠ J♣ J♦ A♦ K♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.ThreeOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory14_ThreeOfAKind()
        {
            IHand hand = new Hand("4♦ 4♣ 4♠ 9♦ 2♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.ThreeOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory15_ThreeOfAKind()
        {
            IHand hand = new Hand("4♦ 4♣ 4♠ 8♣ 7♦");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.ThreeOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory16_Straight()
        {
            IHand hand = new Hand("Q♣ J♠ 10♠ 9♥ 8♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Straight, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory17_Straight()
        {
            IHand hand = new Hand("10♣ 9♦ 8♥ 7♣ 6♠");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Straight, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory18_Straight()
        {
            IHand hand = new Hand("A♣ K♣ Q♦ J♠ 10♠");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Straight, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory19_Straight()
        {
            IHand hand = new Hand("5♠ 4♦ 3♦ 2♠ A♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Straight, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory20_NotStraight()
        {
            IHand hand = new Hand("3♠ 2♦ A♥ K♠ Q♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.HighCard, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory21_Flush()
        {
            IHand hand = new Hand("Q♣ 10♣ 7♣ 6♣ 4♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Flush, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory22_Flush()
        {
            IHand hand = new Hand("Q♦ 9♦ 7♦ 4♦ 3♦");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Flush, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory23_Flush()
        {
            IHand hand = new Hand("K♥ Q♥ 9♥ 5♥ 4♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.Flush, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory24_FullHouse()
        {
            IHand hand = new Hand("3♣ 3♠ 3♦ 6♣ 6♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FullHouse, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory25_FullHouse()
        {
            IHand hand = new Hand("7♠ 7♥ 7♦ 4♠ 4♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FullHouse, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory26_FullHouse()
        {
            IHand hand = new Hand("6♠ 6♥ 6♦ A♠ A♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FullHouse, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory27_FullHouse()
        {
            IHand hand = new Hand("5♥ 5♦ 5♠ Q♥ Q♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FullHouse, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory28_FullHouse()
        {
            IHand hand = new Hand("5♣ 5♦ 5♠ J♠ J♦");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FullHouse, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory29_FullHouse()
        {
            IHand hand = new Hand("Q♣ Q♦ Q♠ 9♥ 9♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FullHouse, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory30_FourOfAKind()
        {
            IHand hand = new Hand("9♣ 9♠ 9♦ 9♥ J♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FourOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory31_FourOfAKind()
        {
            IHand hand = new Hand("7♣ 7♠ 7♦ 7♥ J♥");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FourOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory32_FourOfAKind()
        {
            IHand hand = new Hand("7♣ 7♠ 7♦ 7♥ 10♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.FourOfAKind, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory33_StraightFlush()
        {
            IHand hand = new Hand("Q♣ J♣ 10♣ 9♣ 8♣");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.StraightFlush, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory34_StraightFlush()
        {
            IHand hand = new Hand("5♦ 4♦ 3♦ 2♦ A♦");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.StraightFlush, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        public void TestGetCategory35_StraightFlush()
        {
            IHand hand = new Hand("A♦ K♦ Q♦ J♦ 10♦");

            HandCategory category = handEvaluator.GetCategory(hand);

            Assert.AreEqual(HandCategory.StraightFlush, category, "Hand category is not identified correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetCategory36_ThrowsException()
        {
            IHand hand = new Hand("A♦ A♦ Q♦ J♦ 10♦");

            HandCategory category = handEvaluator.GetCategory(hand);
        }

        [TestMethod]
        public void TestCompareHands1_TwoPair_OnePair()
        {
            IHand hand1 = new Hand("2♦ 2♠ 3♦ 3♣ 4♠");
            IHand hand2 = new Hand("A♠ A♦ K♦ Q♥ J♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands2_StraightFlush()
        {
            IHand hand1 = new Hand("5♠ 4♠ 3♠ 2♠ A♠");
            IHand hand2 = new Hand("7♥ 6♥ 5♥ 4♥ 3♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult < 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands3_StraightFlush()
        {
            IHand hand1 = new Hand("J♣ 10♣ 9♣ 8♣ 7♣");
            IHand hand2 = new Hand("J♦ 10♦ 9♦ 8♦ 7♦");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult == 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands4_FourOfAKind()
        {
            IHand hand1 = new Hand("10♣ 10♦ 10♥ 10♠ 5♦");
            IHand hand2 = new Hand("6♦ 6♥ 6♠ 6♣ K♠");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands5_FourOfAKind()
        {
            IHand hand1 = new Hand("10♣ 10♦ 10♥ 10♠ Q♣");
            IHand hand2 = new Hand("10♣ 10♦ 10♥ 10♠ 5♦");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands6_FullHouse()
        {
            IHand hand1 = new Hand("10♠ 10♥ 10♦ 4♠ 4♦");
            IHand hand2 = new Hand("9♥ 9♣ 9♠ A♥ A♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands7_FullHouse()
        {
            IHand hand1 = new Hand("A♠ A♣ A♥ 4♦ 4♣");
            IHand hand2 = new Hand("A♠ A♥ A♦ 3♠ 3♦");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands8_Flush()
        {
            IHand hand1 = new Hand("A♥ Q♥ 10♥ 5♥ 3♥");
            IHand hand2 = new Hand("K♠ Q♠ J♠ 9♠ 6♠");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands9_Flush()
        {
            IHand hand1 = new Hand("A♦ K♦ 7♦ 6♦ 2♦");
            IHand hand2 = new Hand("A♥ Q♥ 10♥ 5♥ 3♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands10_Straight()
        {
            IHand hand1 = new Hand("8♠ 7♠ 6♥ 5♥ 4♠");
            IHand hand2 = new Hand("6♦ 5♠ 4♦ 3♥ 2♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands11_Straight()
        {
            IHand hand1 = new Hand("8♠ 7♠ 6♥ 5♥ 4♠");
            IHand hand2 = new Hand("8♥ 7♦ 6♣ 5♣ 4♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult == 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands12_ThreeOfAKind()
        {
            IHand hand1 = new Hand("Q♠ Q♣ Q♦ 5♠ 3♣");
            IHand hand2 = new Hand("5♣ 5♥ 5♦ Q♦ 10♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands13_ThreeOfAKind()
        {
            IHand hand1 = new Hand("8♣ 8♥ 8♦ A♣ 2♦");
            IHand hand2 = new Hand("8♠ 8♥ 8♦ 5♠ 3♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands14_TwoPair()
        {
            IHand hand1 = new Hand("K♥ K♦ 2♣ 2♦ J♥");
            IHand hand2 = new Hand("J♦ J♠ 10♠ 10♣ 9♠");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands15_TwoPair()
        {
            IHand hand1 = new Hand("9♣ 9♦ 7♦ 7♠ 6♥");
            IHand hand2 = new Hand("9♥ 9♠ 5♥ 5♦ K♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands16_TwoPair()
        {
            IHand hand1 = new Hand("4♠ 4♣ 3♠ 3♥ K♦");
            IHand hand2 = new Hand("4♥ 4♦ 3♦ 3♣ 10♠");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands17_OnePair()
        {
            IHand hand1 = new Hand("10♣ 10♠ 6♠ 4♥ 2♥");
            IHand hand2 = new Hand("9♥ 9♣ A♥ Q♦ 10♦");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands18_OnePair()
        {
            IHand hand1 = new Hand("2♦ 2♥ 8♠ 5♣ 4♣");
            IHand hand2 = new Hand("2♣ 2♠ 8♣ 5♥ 3♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands19_HighCard()
        {
            IHand hand1 = new Hand("A♦ 10♦ 9♠ 5♣ 4♣");
            IHand hand2 = new Hand("K♣ Q♦ J♣ 8♥ 7♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands20_HighCard()
        {
            IHand hand1 = new Hand("A♣ Q♣ 7♦ 5♥ 2♣");
            IHand hand2 = new Hand("A♦ 10♦ 9♠ 5♣ 4♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands21_OnePair()
        {
            IHand hand1 = new Hand("5♣ 10♣ 10♦ 7♥ J♣");
            IHand hand2 = new Hand("A♦ Q♦ 6♠ 6♣ 8♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands22_ThreeOfAKind()
        {
            IHand hand1 = new Hand("J♣ 9♣ 9♦ 9♥ 8♣");
            IHand hand2 = new Hand("J♦ 9♦ 9♠ 9♣ 6♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands23_HighCard()
        {
            IHand hand1 = new Hand("A♣ Q♣ 8♦ 6♥ 2♣");
            IHand hand2 = new Hand("A♦ Q♦ 8♠ 6♣ 2♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult == 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands24_ThreeOfAKind()
        {
            IHand hand1 = new Hand("J♠ Q♠ 6♥ 6♣ 6♠");
            IHand hand2 = new Hand("7♦ 10♠ 2♦ 2♥ 2♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands25_FourOfAKind()
        {
            IHand hand1 = new Hand("Q♣ Q♦ Q♠ Q♥ 9♣");
            IHand hand2 = new Hand("7♣ 7♦ 7♠ 7♥ 10♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands26_ThreeOfAKind_FourOfAKind()
        {
            IHand hand1 = new Hand("Q♠ Q♣ Q♦ 5♠ 3♣");
            IHand hand2 = new Hand("7♣ 7♦ 7♠ 7♥ 10♣");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult < 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands27_Straight()
        {
            IHand hand1 = new Hand("8♠ 7♠ 6♥ 5♥ 4♠");
            IHand hand2 = new Hand("A♥ 5♦ 4♣ 3♣ 2♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands28_OnePair()
        {
            IHand hand1 = new Hand("8♠ 8♦ 9♥ Q♥ K♠");
            IHand hand2 = new Hand("8♥ 8♣ 5♣ J♣ A♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult < 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands29_OnePair()
        {
            IHand hand1 = new Hand("8♠ 8♦ 9♥ Q♥ K♠");
            IHand hand2 = new Hand("8♥ 8♣ 5♣ J♣ K♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }

        [TestMethod]
        public void TestCompareHands30_OnePair()
        {
            IHand hand1 = new Hand("8♠ 8♦ 9♥ Q♥ K♠");
            IHand hand2 = new Hand("8♥ 8♣ 5♣ Q♣ K♥");

            int compareResult = handEvaluator.CompareHands(hand1, hand2);

            Assert.IsTrue(compareResult > 0, "Hand comparison does not work correctly.");
        }
    }
}
