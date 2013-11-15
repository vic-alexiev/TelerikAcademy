// ********************************
// <copyright file="GameEngineTest.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace BattleshipsTests
{
    using System.IO;
    using System.Text;
    using Battleships;
    using Battleships.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Used to test the <see cref="GameEngine"/> class functionality.
    /// </summary>
    [TestClass]
    public class GameEngineTest
    {
        private static Ship[] ships;

        /// <summary>
        /// Initializes static members of the <see cref="GameEngineTest"/> class.
        /// </summary>
        static GameEngineTest()
        {
            Ship battleship = new Ship(new Bow(0, 6), ShipType.Battleship, ShipDirection.Vertical);
            Ship destroyer1 = new Ship(new Bow(2, 2), ShipType.Destroyer, ShipDirection.Vertical);
            Ship destroyer2 = new Ship(new Bow(8, 6), ShipType.Destroyer, ShipDirection.Horizontal);

            ships = new Ship[] { battleship, destroyer1, destroyer2 };
        }

        [TestMethod]
        public void TestRunWithIORedirected()
        {
            string inputFilePath = "../../Resources/SampleInput.in";
            string outputFilePath = "../../Resources/SampleOutput.out";
            string expectedOutputFilePath = "../../Resources/ExpectedOutput.out";

            GridManager gridManager = new GridManager(ships);
            IIOManager ioManager = new ConsoleManager();
            GameEngine.RunWithIORedirected(gridManager, ioManager, inputFilePath, outputFilePath);

            string actualOutput = File.ReadAllText(outputFilePath, Encoding.ASCII);
            string expectedOutput = File.ReadAllText(expectedOutputFilePath, Encoding.ASCII);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestDisplayShotResult_Hit()
        {
            var gridManager = new GridManager(ships);
            var ioManagerMocked = new Mock<IIOManager>();

            GameEngine.DisplayShotResult(gridManager, ioManagerMocked.Object, ShotResult.Hit);

            ioManagerMocked.Verify(x => x.WriteLine("\t*** Hit ***"), Times.Once);
            ioManagerMocked.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void TestDisplayShotResult_ShipSunk()
        {
            var gridManager = new GridManager(ships);
            var ioManagerMocked = new Mock<IIOManager>();

            GameEngine.DisplayShotResult(gridManager, ioManagerMocked.Object, ShotResult.ShipSunk);

            ioManagerMocked.Verify(x => x.WriteLine("\t*** Sunk ***"), Times.Once);
            ioManagerMocked.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void TestDisplayShotResult_AllShipsSunk()
        {
            var gridManager = new GridManager(ships);
            var ioManagerMocked = new Mock<IIOManager>();

            GameEngine.DisplayShotResult(gridManager, ioManagerMocked.Object, ShotResult.AllShipsSunk);

            ioManagerMocked.Verify(
                x => x.WriteLine(
                "Well done! You completed the game in {0} shots.",
                gridManager.ShotsCount),
                Times.Once);
            ioManagerMocked.Verify(x => x.WriteLine(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void TestDisplayShotResult_Miss()
        {
            var gridManager = new GridManager(ships);
            var ioManagerMocked = new Mock<IIOManager>();

            GameEngine.DisplayShotResult(gridManager, ioManagerMocked.Object, ShotResult.Miss);

            ioManagerMocked.Verify(x => x.WriteLine("\t*** Miss ***"), Times.Once);
            ioManagerMocked.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void TestDisplayShotResult_Error()
        {
            var gridManager = new GridManager(ships);
            var ioManagerMocked = new Mock<IIOManager>();

            GameEngine.DisplayShotResult(gridManager, ioManagerMocked.Object, ShotResult.Error);

            ioManagerMocked.Verify(x => x.WriteLine("\t*** Error ***"), Times.Once);
            ioManagerMocked.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}
