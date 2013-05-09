// ********************************
// <copyright file="Delta.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace MatrixTraversal
{
    using System;

    /// <summary>
    /// Represents a change of the position while traversing the matrix.
    /// </summary>
    public class Delta
    {
        /// <summary>
        /// The direction of the delta.
        /// </summary>
        private Direction direction;

        /// <summary>
        /// Initializes static members of the <see cref="Delta"/> class.
        /// </summary>
        static Delta()
        {
            DirectionsCount = Enum.GetValues(typeof(Direction)).Length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Delta"/> class.
        /// </summary>
        /// <param name="direction">The direction of the delta.</param>
        public Delta(Direction direction)
        {
            this.Direction = direction;
        }

        /// <summary>
        /// Gets the number of possible directions.
        /// </summary>
        public static int DirectionsCount { get; private set; }

        /// <summary>
        /// Gets or sets the direction of the delta. This also sets its
        /// Row and Col properties.
        /// </summary>
        /// <value>Gets or sets the value of the direction field.</value>
        public Direction Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;

                switch (value)
                {
                    case Direction.Southeast:
                        {
                            this.Row = 1;
                            this.Col = 1;
                            break;
                        }

                    case Direction.South:
                        {
                            this.Row = 1;
                            this.Col = 0;
                            break;
                        }

                    case Direction.Southwest:
                        {
                            this.Row = 1;
                            this.Col = -1;
                            break;
                        }

                    case Direction.West:
                        {
                            this.Row = 0;
                            this.Col = -1;
                            break;
                        }

                    case Direction.Northwest:
                        {
                            this.Row = -1;
                            this.Col = -1;
                            break;
                        }

                    case Direction.North:
                        {
                            this.Row = -1;
                            this.Col = 0;
                            break;
                        }

                    case Direction.Northeast:
                        {
                            this.Row = -1;
                            this.Col = 1;
                            break;
                        }

                    default:
                        {
                            this.Row = 0;
                            this.Col = 1;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Gets the row direction of the delta.
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// Gets the col direction of the delta.
        /// </summary>
        public int Col { get; private set; }

        /// <summary>
        /// Updates the direction using the next value in the
        /// <see cref="Direction"/> enumeration. If the last value is 
        /// reached, update starts from the beginning.
        /// </summary>
        public void UpdateDirectionClockwise()
        {
            if ((int)this.Direction == DirectionsCount - 1)
            {
                this.Direction = 0;
            }
            else
            {
                this.Direction++;
            }
        }
    }
}
