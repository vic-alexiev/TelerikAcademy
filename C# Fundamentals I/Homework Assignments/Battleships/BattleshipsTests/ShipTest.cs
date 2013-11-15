// ********************************
// <copyright file="ShipTest.cs" company="Anonymous Solutions Inc.">
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
    /// Used to test the <see cref="Ship"/> class functionality.
    /// </summary>
    [TestClass]
    public class ShipTest
    {
        [TestMethod]
        public void TestConstructor_NoBowAndDirectionProvided()
        {
            Ship ship = new Ship(ShipType.AircraftCarrier);

            Assert.AreEqual(6, ship.Size);
            Assert.AreEqual(0, ship.Bow.Row);
            Assert.AreEqual(0, ship.Bow.Col);
            Assert.AreEqual(false, ship.IsSunk);
            Assert.AreEqual(ShipType.AircraftCarrier, ship.Type);
            Assert.AreEqual(ShipDirection.Horizontal, ship.Direction);
        }

        [TestMethod]
        public void TestConstructor_BowAndDirectionProvided()
        {
            Ship ship = new Ship(new Bow(0, 6), ShipType.Destroyer, ShipDirection.Vertical);

            Assert.AreEqual(4, ship.Size);
            Assert.AreEqual(0, ship.Bow.Row);
            Assert.AreEqual(6, ship.Bow.Col);
            Assert.AreEqual(false, ship.IsSunk);
            Assert.AreEqual(ShipType.Destroyer, ship.Type);
            Assert.AreEqual(ShipDirection.Vertical, ship.Direction);
        }
    }
}
