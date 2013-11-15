// ********************************
// <copyright file="GridManagerTest.cs" company="Anonymous Solutions Inc.">
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
    /// Used to test the <see cref="GridManager"/> class functionality.
    /// </summary>
    [TestClass]
    public class GridManagerTest
    {
        private static Ship[] ships;

        /// <summary>
        /// Initializes static members of the <see cref="GridManagerTest"/> class.
        /// </summary>
        static GridManagerTest()
        {
            Ship ship1 = new Ship(new Bow(0, 6), ShipType.AircraftCarrier, ShipDirection.Vertical);
            Ship ship2 = new Ship(new Bow(2, 2), ShipType.Battleship, ShipDirection.Vertical);
            Ship ship3 = new Ship(new Bow(8, 6), ShipType.Destroyer, ShipDirection.Horizontal);
            Ship ship4 = new Ship(new Bow(7, 6), ShipType.PatrolBoat, ShipDirection.Horizontal);
            Ship ship5 = new Ship(new Bow(0, 8), ShipType.Submarine, ShipDirection.Vertical);

            ships = new Ship[] { ship1, ship2, ship3, ship4, ship5 };
        }

        [TestMethod]
        [ExpectedException(typeof(BattleshipException))]
        public void TestConstructor_NoShipsProvided()
        {
            GridManager gridManager = new GridManager(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BattleshipException))]
        public void TestConstructor_ShipsEqualToNullProvided()
        {
            Ship[] testShips = new Ship[] { null };
            GridManager gridManager = new GridManager(testShips);
        }

        [TestMethod]
        public void TestConstructor_ShipsShouldBePlacedCorrectly()
        {
            GridManager gridManager = new GridManager(ships);

            Square[,] grid = gridManager.Grid;

            foreach (Ship ship in ships)
            {
                int deltaRow = ship.Direction == ShipDirection.Horizontal ? 0 : 1;
                int deltaCol = ship.Direction == ShipDirection.Horizontal ? 1 : 0;

                for (int i = 0; i < ship.Size; i++)
                {
                    int row = ship.Bow.Row + (i * deltaRow);
                    int col = ship.Bow.Col + (i * deltaCol);

                    Assert.AreSame(ship, grid[row, col].Ship);
                    Assert.AreEqual(SquareState.OccupiedNoShot, grid[row, col].State);
                }
            }
        }

        [TestMethod]
        public void TestDisplayShips_BackdoorMode()
        {
            GridManager gridManager = new GridManager(ships);

            string gridAsString = gridManager.DisplayShips(true);

            string expectedString = 
                "    1 2 3 4 5 6 7 8 9 0\r\n" + 
                "   ---------------------\r\n" + 
                "A |             X   X   |\r\n" + 
                "B |             X   X   |\r\n" + 
                "C |     X       X   X   |\r\n" + 
                "D |     X       X   X   |\r\n" + 
                "E |     X       X       |\r\n" + 
                "F |     X       X       |\r\n" + 
                "G |     X               |\r\n" + 
                "H |             X X     |\r\n" + 
                "I |             X X X X |\r\n" + 
                "J |                     |\r\n" + 
                "   ---------------------\r\n";

            Assert.AreEqual(expectedString, gridAsString);
        }

        [TestMethod]
        public void TestDisplayShips_NormalMode()
        {
            GridManager gridManager = new GridManager(ships);

            gridManager.ShootTarget("D4");
            gridManager.ShootTarget("G3");
            gridManager.ShootTarget("I7");

            string gridAsString = gridManager.DisplayShips(false);

            string expectedString =
                "    1 2 3 4 5 6 7 8 9 0\r\n" +
                "   ---------------------\r\n" +
                "A | . . . . . . . . . . |\r\n" +
                "B | . . . . . . . . . . |\r\n" +
                "C | . . . . . . . . . . |\r\n" +
                "D | . . . - . . . . . . |\r\n" +
                "E | . . . . . . . . . . |\r\n" +
                "F | . . . . . . . . . . |\r\n" +
                "G | . . X . . . . . . . |\r\n" +
                "H | . . . . . . . . . . |\r\n" +
                "I | . . . . . . X . . . |\r\n" +
                "J | . . . . . . . . . . |\r\n" +
                "   ---------------------\r\n";

            Assert.AreEqual(expectedString, gridAsString);
        }

        [TestMethod]
        public void TestShootTarget_InvalidUserInput()
        {
            GridManager gridManager = new GridManager();

            ShotResult shotResult = gridManager.ShootTarget(null);
            Assert.AreEqual(ShotResult.Error, shotResult);

            shotResult = gridManager.ShootTarget(string.Empty);
            Assert.AreEqual(ShotResult.Error, shotResult);

            shotResult = gridManager.ShootTarget("   ");
            Assert.AreEqual(ShotResult.Error, shotResult);

            shotResult = gridManager.ShootTarget("A");
            Assert.AreEqual(ShotResult.Error, shotResult);

            shotResult = gridManager.ShootTarget("BBBB");
            Assert.AreEqual(ShotResult.Error, shotResult);
        }

        [TestMethod]
        public void TestShootTarget_Hit()
        {
            GridManager gridManager = new GridManager(ships);

            string input = gridManager.GetMatchingInput(ships[0].Bow.Row, ships[0].Bow.Col);
            ShotResult shotResult = gridManager.ShootTarget(input);

            Assert.AreEqual(ShotResult.Hit, shotResult);
        }

        [TestMethod]
        public void TestShootTarget_HitTwice()
        {
            GridManager gridManager = new GridManager(ships);

            string input = gridManager.GetMatchingInput(ships[0].Bow.Row, ships[0].Bow.Col);

            ShotResult shotResult = gridManager.ShootTarget(input);
            shotResult = gridManager.ShootTarget(input);

            Assert.AreEqual(ShotResult.Hit, shotResult);
        }

        [TestMethod]
        public void TestShootTarget_Miss()
        {
            GridManager gridManager = new GridManager(ships);

            string input = gridManager.GetMatchingInput(0, 0);
            ShotResult shotResult = gridManager.ShootTarget(input);

            Assert.AreEqual(ShotResult.Miss, shotResult);
        }

        [TestMethod]
        public void TestShootTarget_MissTwice()
        {
            GridManager gridManager = new GridManager(ships);

            string input = gridManager.GetMatchingInput(0, 0);

            ShotResult shotResult = gridManager.ShootTarget(input);
            shotResult = gridManager.ShootTarget(input);

            Assert.AreEqual(ShotResult.Miss, shotResult);
        }

        [TestMethod]
        public void TestShootTarget_ShipSunk()
        {
            GridManager gridManager = new GridManager(ships);

            ShotResult shotResult = ShotResult.Error;
            Ship ship = ships[0];

            int deltaRow = ship.Direction == ShipDirection.Horizontal ? 0 : 1;
            int deltaCol = ship.Direction == ShipDirection.Horizontal ? 1 : 0;

            for (int i = 0; i < ship.Size; i++)
            {
                int row = ship.Bow.Row + (i * deltaRow);
                int col = ship.Bow.Col + (i * deltaCol);

                string input = gridManager.GetMatchingInput(row, col);

                shotResult = gridManager.ShootTarget(input);
            }

            Assert.AreEqual(ShotResult.ShipSunk, shotResult);
        }

        [TestMethod]
        public void TestShootTarget_AllShipsSunk()
        {
            GridManager gridManager = new GridManager(ships);
            ShotResult shotResult = ShotResult.Error;

            foreach (Ship ship in ships)
            {
                int deltaRow = ship.Direction == ShipDirection.Horizontal ? 0 : 1;
                int deltaCol = ship.Direction == ShipDirection.Horizontal ? 1 : 0;

                for (int i = 0; i < ship.Size; i++)
                {
                    int row = ship.Bow.Row + (i * deltaRow);
                    int col = ship.Bow.Col + (i * deltaCol);

                    string input = gridManager.GetMatchingInput(row, col);

                    shotResult = gridManager.ShootTarget(input);
                }
            }

            Assert.AreEqual(ShotResult.AllShipsSunk, shotResult);
        }
    }
}
