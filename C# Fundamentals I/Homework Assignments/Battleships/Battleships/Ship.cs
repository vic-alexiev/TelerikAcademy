// ********************************
// <copyright file="Ship.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    using Battleships.Enums;

    /// <summary>
    /// Represents a ship.
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        /// <param name="type">The ship type.</param>
        public Ship(ShipType type)
            : this(new Bow(0, 0), type, ShipDirection.Horizontal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        /// <param name="bow">The ship's bow.</param>
        /// <param name="type">The ship type.</param>
        /// <param name="direction">The ship direction.</param>
        public Ship(Bow bow, ShipType type, ShipDirection direction)
        {
            this.Bow = bow;
            this.Type = type;
            this.IsSunk = false;
            this.Direction = direction;
            this.Size = this.GetSize(type);
        }

        /// <summary>
        /// Gets or sets the coordinates of the ship's bow.
        /// </summary>
        public Bow Bow { get; set; }

        /// <summary>
        /// Gets the ship's size.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Gets the ship's type.
        /// </summary>
        public ShipType Type { get; private set; }

        /// <summary>
        /// Gets or sets the ship's direction.
        /// </summary>
        public ShipDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the ship is sunk.
        /// </summary>
        public bool IsSunk { get; set; }

        private int GetSize(ShipType type)
        {
            switch (type)
            {
                case ShipType.AircraftCarrier:
                    return 6;
                case ShipType.Battleship:
                    return 5;
                case ShipType.Submarine:
                    return 4;
                case ShipType.Destroyer:
                    return 4;
                case ShipType.PatrolBoat:
                    return 2;
                default:
                    {
                        throw new BattleshipException("Unknown ShipType.");
                    }
            }
        }
    }
}
