// ********************************
// <copyright file="GridManager.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Battleships.Enums;

    /// <summary>
    /// Used to process user input (target to shoot at) and update the state of the ships on the grid.
    /// </summary>
    public class GridManager
    {
        #region Public Constants

        public const int GridSize = 10;
        public const string BackdoorCommand = "show";

        #endregion

        #region Private Fields

        private const char RowZeroKey = 'A';
        private const char HitCharacter = 'X';
        private const char MissCharacter = '-';
        private const char NoShotCharacter = '.';

        private Ship[] ships;
        private Square[,] grid;
        private int shotsCount = 0;
        private Random randomGenerator = new Random();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridManager"/> class.
        /// </summary>
        public GridManager()
        {
            this.InitGrid();

            this.ships = new Ship[]
            {
                new Ship(ShipType.Battleship),
                new Ship(ShipType.Destroyer),
                new Ship(ShipType.Destroyer)
            };
            this.ArrangeShips(this.ships);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridManager"/> class.
        /// For testing purposes only.
        /// </summary>
        /// <param name="arrangedShips">An array of ships with predefined positions.</param>
        public GridManager(Ship[] arrangedShips)
        {
            if (arrangedShips == null || arrangedShips.Count() == 0)
            {
                throw new BattleshipException("The Ships collection cannot be null or empty.");
            }

            foreach (Ship ship in arrangedShips)
            {
                if (ship == null)
                {
                    throw new BattleshipException("The Ship object cannot be null.");
                }

                if (ship.Size > GridSize)
                {
                    throw new BattleshipException(
                        string.Format(
                        "Ship with type = {0} is too big for the grid (GridSize = {1}).",
                        ship.Type,
                        GridSize));
                }
            }

            this.InitGrid();

            this.ships = arrangedShips;
            this.PlaceShips(this.ships);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of ships to shoot at.
        /// </summary>
        public int ShipsCount
        {
            get
            {
                return this.ships.Length;
            }
        }

        /// <summary>
        /// Gets the number of shots the user has made.
        /// Errors (invalid target coordinates) are not included.
        /// </summary>
        public int ShotsCount
        {
            get
            {
                return this.shotsCount;
            }
        }

        /// <summary>
        /// Gets the grid. For testing purposes only.
        /// </summary>
        public Square[,] Grid
        {
            get
            {
                return this.grid;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the string representation of the grid - hits, misses and no-shots.
        /// </summary>
        /// <param name="backdoorMode">Specifies whether the exact positions of the ships should be displayed.</param>
        /// <returns>The grid and the ships (hits/misses/no-shots) on it as a string.</returns>
        public string DisplayShips(bool backdoorMode)
        {
            char hitCharacter = backdoorMode ? ' ' : HitCharacter;
            char missCharacter = backdoorMode ? ' ' : MissCharacter;
            char emptyNoShotCharacter = backdoorMode ? ' ' : NoShotCharacter;
            char occupiedNoShotCharacter = backdoorMode ? HitCharacter : NoShotCharacter;

            StringBuilder result = new StringBuilder();
            StringBuilder colNumbersBuilder = new StringBuilder();
            StringBuilder dashedLineBuilder = new StringBuilder();

            for (int col = 1; col <= this.grid.GetLength(1); col++)
            {
                colNumbersBuilder.Append(" " + (col < 10 ? col : 0));
                dashedLineBuilder.Append("--");
            }

            dashedLineBuilder.Append("-");

            result.AppendLine("   " + colNumbersBuilder);
            result.AppendLine("   " + dashedLineBuilder);

            for (int row = 0; row < this.grid.GetLength(0); row++)
            {
                char rowKey = (char)(RowZeroKey + row);
                result.Append(rowKey + " | ");

                for (int col = 0; col < this.grid.GetLength(1); col++)
                {
                    Square square = this.grid[row, col];
                    switch (square.State)
                    {
                        case SquareState.Hit:
                            {
                                result.Append(hitCharacter + " ");
                                break;
                            }
                        case SquareState.Miss:
                            {
                                result.Append(missCharacter + " ");
                                break;
                            }
                        case SquareState.EmptyNoShot:
                            {
                                result.Append(emptyNoShotCharacter + " ");
                                break;
                            }
                        case SquareState.OccupiedNoShot:
                            {
                                result.Append(occupiedNoShotCharacter + " ");
                                break;
                            }
                        default:
                            {
                                throw new BattleshipException("Unknown SquareState.");
                            }
                    }
                }

                result.AppendLine("|");
            }

            result.AppendLine("   " + dashedLineBuilder);
            return result.ToString();
        }

        /// <summary>
        /// Makes a shot at the target square and returns the result.
        /// The shot can result in a hit, a miss, a final hit for a ship (the ship is sunk)
        /// or a final hit for all ships (all ships are sunk).
        /// </summary>
        /// <param name="coordinates">The coordinates of the target square, e.g. "A5".</param>
        /// <returns>The result of the attack.</returns>
        public ShotResult ShootTarget(string coordinates)
        {
            if (!this.ValidateCoordinates(coordinates))
            {
                return ShotResult.Error;
            }

            this.shotsCount++;

            int row;
            int col;
            this.ParseCoordinates(coordinates, out row, out col);

            Square square = this.grid[row, col];
            switch (square.State)
            {
                case SquareState.Hit:
                    {
                        return ShotResult.Hit;
                    }
                case SquareState.Miss:
                    {
                        return ShotResult.Miss;
                    }
                case SquareState.EmptyNoShot:
                    {
                        square.State = SquareState.Miss;
                        return ShotResult.Miss;
                    }
                case SquareState.OccupiedNoShot:
                    {
                        square.State = SquareState.Hit;

                        // get the ship being attacked
                        Ship shipHit = square.Ship;

                        if (this.IsWholeShipSunk(shipHit))
                        {
                            shipHit.IsSunk = true;
                            if (this.AreAllShipsSunk())
                            {
                                return ShotResult.AllShipsSunk;
                            }

                            return ShotResult.ShipSunk;
                        }

                        return ShotResult.Hit;
                    }
                default:
                    {
                        throw new BattleshipException("Unknown SquareState.");
                    }
            }
        }

        /// <summary>
        /// Converts the specified coordinates into valid user input.
        /// For testing purposes only.
        /// </summary>
        /// <param name="row">The row coordinate.</param>
        /// <param name="col">The column coordinate.</param>
        /// <returns>The coordinates as a string, e.g. (0, 4) => "A5".</returns>
        public string GetMatchingInput(int row, int col)
        {
            char rowKey = (char)(RowZeroKey + row);
            int colKey = col + 1;
            return string.Format("{0}{1}", rowKey, colKey);
        }

        #endregion

        #region Private Methods

        private void InitGrid()
        {
            this.grid = new Square[GridSize, GridSize];

            for (int row = 0; row < this.grid.GetLength(0); row++)
            {
                for (int col = 0; col < this.grid.GetLength(1); col++)
                {
                    this.grid[row, col] = new Square(null, SquareState.EmptyNoShot);
                }
            }
        }

        private void ArrangeShips(IEnumerable<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                ship.Direction = (ShipDirection)this.randomGenerator.Next(0, 2);
                if (!this.TryPlaceShip(ship))
                {
                    // change the direction using bitwise XOR
                    ship.Direction = ship.Direction ^ ShipDirection.Vertical;
                    if (!this.TryPlaceShip(ship))
                    {
                        throw new BattleshipException("The given fleet cannot be placed on the grid.");
                    }
                }
            }
        }

        /// <summary>
        /// Transforms the user coordinates into a square on the grid.
        /// </summary>
        /// <param name="coordinates">The coordinates as specified by the user, e.g. "A5".</param>
        /// <param name="row">The square row.</param>
        /// <param name="col">The square column.</param>
        private void ParseCoordinates(string coordinates, out int row, out int col)
        {
            row = coordinates[0] - RowZeroKey;
            col = int.Parse(coordinates.Substring(1)) - 1;
        }

        private bool ValidateCoordinates(string coordinates)
        {
            if (string.IsNullOrWhiteSpace(coordinates) ||
                (coordinates.Length < 2 && coordinates.Length > 3))
            {
                return false;
            }

            int colKey;
            if (!int.TryParse(coordinates.Substring(1), out colKey))
            {
                return false;
            }

            char rowKey = coordinates[0];

            if (rowKey >= RowZeroKey && rowKey < RowZeroKey + this.grid.GetLength(0) &&
                colKey > 0 && colKey <= this.grid.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private bool TryPlaceShip(Ship ship)
        {
            int maxRow;
            int maxCol;
            this.CalcMaxPossibleSquare(ship, out maxRow, out maxCol);

            int maxTries = maxRow * maxCol;

            // keeps the squares already tried for the bow
            HashSet<Bow> bowsTried = new HashSet<Bow>();

            do
            {
                do
                {
                    // try a random square for the bow
                    ship.Bow = new Bow(
                        this.randomGenerator.Next(0, maxRow),
                        this.randomGenerator.Next(0, maxCol));
                }
                while (bowsTried.Contains(ship.Bow));

                // mark the square as tried; in this way, if it is already occupied
                // by another ship, we make sure that we will not try it again
                // if the random generator suggests it next time.
                bowsTried.Add(ship.Bow);

                if (!this.IsAreaOccupied(ship))
                {
                    this.OccupyArea(ship);
                    return true;
                }
            }
            while (bowsTried.Count < maxTries);

            return false;
        }

        private void PlaceShips(IEnumerable<Ship> ships)
        {
            foreach (Ship ship in ships)
            {
                this.OccupyArea(ship);
            }
        }

        private void CalcMaxPossibleSquare(Ship ship, out int maxRow, out int maxCol)
        {
            if (ship.Direction == ShipDirection.Horizontal)
            {
                maxRow = this.grid.GetLength(0);
                maxCol = this.grid.GetLength(1) - ship.Size + 1;
            }
            else
            {
                maxRow = this.grid.GetLength(0) - ship.Size + 1;
                maxCol = this.grid.GetLength(1);
            }
        }

        private bool IsAreaOccupied(Ship ship)
        {
            IEnumerable<Square> squaresForShip = this.GetSquaresForShip(ship);

            return squaresForShip.Any(s => s.Ship != null);
        }

        private void OccupyArea(Ship ship)
        {
            IEnumerable<Square> squares = this.GetSquaresForShip(ship);

            foreach (Square square in squares)
            {
                square.Ship = ship;
                square.State = SquareState.OccupiedNoShot;
            }
        }

        private bool IsWholeShipSunk(Ship ship)
        {
            IEnumerable<Square> squaresOccupied = this.GetSquaresForShip(ship);

            return squaresOccupied.All(s => s.State == SquareState.Hit);
        }

        private bool AreAllShipsSunk()
        {
            return this.ships.All(s => s.IsSunk == true);
        }

        private IEnumerable<Square> GetSquaresForShip(Ship ship)
        {
            int deltaRow = ship.Direction == ShipDirection.Horizontal ? 0 : 1;
            int deltaCol = ship.Direction == ShipDirection.Horizontal ? 1 : 0;

            Square[] squares = new Square[ship.Size];

            for (int i = 0; i < ship.Size; i++)
            {
                int row = ship.Bow.Row + (i * deltaRow);
                int col = ship.Bow.Col + (i * deltaCol);

                squares[i] = this.grid[row, col];
            }

            return squares;
        }

        #endregion
    }
}
