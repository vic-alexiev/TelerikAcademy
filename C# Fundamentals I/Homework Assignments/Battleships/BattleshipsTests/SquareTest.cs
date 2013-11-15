// ********************************
// <copyright file="SquareTest.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace BattleshipsTests
{
    using Battleships;
    using Battleships.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="Square"/> class functionality.
    /// </summary>
    [TestClass]
    public class SquareTest
    {
        [TestMethod]
        public void TestConstructor_CreateSquareWithShipNull()
        {
            Square square = new Square(null, SquareState.EmptyNoShot);

            Assert.AreEqual(null, square.Ship);
            Assert.AreEqual(SquareState.EmptyNoShot, square.State);
        }

        [TestMethod]
        public void TestConstructor_CreateSquareWithShipProvided()
        {
            Ship ship = new Ship(ShipType.Battleship);
            Square square = new Square(ship, SquareState.EmptyNoShot);

            Assert.AreSame(ship, square.Ship);
            Assert.AreEqual(SquareState.EmptyNoShot, square.State);
        }
    }
}
