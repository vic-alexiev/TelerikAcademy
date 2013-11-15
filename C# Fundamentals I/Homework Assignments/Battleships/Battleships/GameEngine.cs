// ********************************
// <copyright file="GameEngine.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    using System;
    using System.IO;
    using Battleships.Enums;

    public static class GameEngine
    {
        /// <summary>
        /// For testing purposes only. Plays the game with I/O redirected to/from files.
        /// </summary>
        /// <param name="gridManager">The <see cref="GridManager" /> which handles the game.</param>
        /// <param name="ioManager">An object specifying how the I/O should be handled.</param>
        /// <param name="inputFilePath">The path of the input file.</param>
        /// <param name="outputFilePath">The path of the output file.</param>
        /// <example>
        /// This example shows how to call the <see cref="RunWithIORedirected(GridManager, string, string)"/> method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         GridManager gridManager = new GridManager();
        ///         
        ///         RunWithIORedirected(
        ///             gridManager,
        ///             Path.Combine(Environment.CurrentDirectory, "SampleInput.in"),
        ///             Path.Combine(Environment.CurrentDirectory, "SampleOutput.out"));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void RunWithIORedirected(
            GridManager gridManager,
            IIOManager ioManager,
            string inputFilePath,
            string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    ioManager.SetIn(reader);
                    ioManager.SetOut(writer);
                    Run(gridManager, ioManager);
                }
            }
        }

        /// <summary>
        /// Starts the game loop.
        /// </summary>
        /// <param name="gridManager">The <see cref="GridManager" /> which handles the game.</param>
        /// <param name="ioManager">An object specifying how the I/O should be handled.</param>
        public static void Run(GridManager gridManager, IIOManager ioManager)
        {
            ioManager.WriteLine(
                "\t\tBATTLESHIP by ANONYMOUS SOLUTIONS INC.{0}{0}" +
                "You are given a square {1}x{1} grid. The individual squares in the grid{0}" +
                "are identified by letter and number, e.g. A5. Several ships have been{0}" +
                "secretly arranged. Each ship occupies a number of consecutive squares{0}" +
                "on the grid, arranged either horizontally or vertically. The ships can{0}" +
                "touch each other and cannot overlap. The fleet consists of {2} ship(s).{0}" +
                "Your task is to sink them all.{0}",
                Environment.NewLine,
                GridManager.GridSize,
                gridManager.ShipsCount);

            ioManager.WriteLine(gridManager.DisplayShips(false));

            while (true)
            {
                ioManager.Write("Enter target square to shoot at: ");

                string command = ioManager.ReadLine();
                if (command == GridManager.BackdoorCommand)
                {
                    ioManager.WriteLine(gridManager.DisplayShips(true));
                }
                else
                {
                    ShotResult shotResult = gridManager.ShootTarget(command);

                    DisplayShotResult(gridManager, ioManager, shotResult);
                    if (shotResult == ShotResult.AllShipsSunk)
                    {
                        return;
                    }

                    ioManager.WriteLine(gridManager.DisplayShips(false));
                }
            }
        }

        /// <summary>
        /// Displays a string depending on the specified ShotResult.
        /// </summary>
        /// <param name="gridManager">The <see cref="GridManager" /> which handles the game.</param>
        /// <param name="ioManager">An object specifying how the I/O should be handled.</param>
        /// <param name="value">The value to display.</param>
        public static void DisplayShotResult(GridManager gridManager, IIOManager ioManager, ShotResult value)
        {
            switch (value)
            {
                case ShotResult.Hit:
                    {
                        ioManager.WriteLine("\t*** Hit ***");
                        break;
                    }
                case ShotResult.ShipSunk:
                    {
                        ioManager.WriteLine("\t*** Sunk ***");
                        break;
                    }
                case ShotResult.AllShipsSunk:
                    {
                        ioManager.WriteLine("Well done! You completed the game in {0} shots.", gridManager.ShotsCount);
                        break;
                    }
                case ShotResult.Miss:
                    {
                        ioManager.WriteLine("\t*** Miss ***");
                        break;
                    }
                case ShotResult.Error:
                    {
                        ioManager.WriteLine("\t*** Error ***");
                        break;
                    }
                default:
                    {
                        throw new BattleshipException("Unknown ShotResult.");
                    }
            }
        }
    }
}
