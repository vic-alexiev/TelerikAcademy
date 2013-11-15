// ********************************
// <copyright file="BowTest.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace BattleshipsTests
{
    using Battleships;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="Bow"/> struct functionality.
    /// </summary>
    [TestClass]
    public class BowTest
    {
        [TestMethod]
        public void TestConstructor_CreateBowWithValidParameters()
        {
            Bow bow = new Bow(10, 20);

            Assert.AreEqual(10, bow.Row);
            Assert.AreEqual(20, bow.Col);
        }

        [TestMethod]
        public void TestGetHashCode_ShouldReturnRowAndColXORed()
        {
            Bow bow = new Bow(10, 20);

            Assert.AreEqual(30, bow.GetHashCode());
        }

        [TestMethod]
        public void TestEquals_ShouldCompareOnlyTheValuesOfRowAndCol()
        {
            Bow bow1 = new Bow(10, 20);
            Bow bow2 = new Bow(10, 20);
            Bow bow3 = new Bow(7, 9);

            Assert.IsTrue(bow1.Equals(bow2));
            Assert.IsFalse(bow1.Equals(bow3));
        }

        [TestMethod]
        public void TestEquals_CompareDifferentTypesOfObjects()
        {
            Bow bow = new Bow(10, 20);
            int row = 10;

            Assert.IsFalse(bow.Equals(row));
        }

        [TestMethod]
        public void TestEqualityOperator_ShouldCompareOnlyTheValuesOfRowAndCol()
        {
            Bow bow1 = new Bow(10, 20);
            Bow bow2 = new Bow(10, 20);
            Bow bow3 = new Bow(7, 9);

            Assert.IsTrue(bow1 == bow2);
            Assert.IsFalse(bow1 == bow3);
        }

        [TestMethod]
        public void TestInequalityOperator_ShouldCompareOnlyTheValuesOfRowAndCol()
        {
            Bow bow1 = new Bow(10, 20);
            Bow bow2 = new Bow(10, 20);
            Bow bow3 = new Bow(7, 9);

            Assert.IsFalse(bow1 != bow2);
            Assert.IsTrue(bow1 != bow3);
        }
    }
}
