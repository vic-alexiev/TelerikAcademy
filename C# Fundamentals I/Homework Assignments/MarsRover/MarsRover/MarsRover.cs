using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MarsRover
{
    enum RotationType
    {
        Left,
        Right
    }

    enum MotionType
    {
        Forward,
        Backwards
    }

    public class MarsRover
    {
        #region Private Fields

        private static int gridSize = 5;

        // four points representing the four directions
        private static Point[] directions = 
        { 
            // North
            new Point(0, 1),
            // East
            new Point(1, 0),
            // South
            new Point(0, -1),
            // West
            new Point(-1, 0) 
        };

        #endregion

        #region Helper Methods

        /// <summary>
        /// Returns the index of the next direction based on
        /// the current direction index and the rotation type.
        /// </summary>
        /// <param name="currentDirection"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        private static int GetNextDirection(int currentDirection, RotationType rotation)
        {
            int directionsCount = directions.Length;

            if (rotation == RotationType.Right)
            {
                // get the index of the next element in the array
                return (currentDirection + 1) % directionsCount;
            }
            else // RotationType.Left
            {
                if (currentDirection == 0)
                {
                    return directionsCount - 1;
                }
                else
                {
                    // get the index of the previous element in the array
                    return currentDirection - 1;
                }
            }
        }

        /// <summary>
        /// Checks if the next position of the rover
        /// will be in the grid.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="currentDirection"></param>
        /// <param name="motionType"></param>
        /// <returns></returns>
        private static bool CanMove(Point location, int currentDirection, MotionType motionType)
        {
            int sign = 1;
            if (motionType == MotionType.Backwards)
            {
                sign = -1;
            }

            int newX = location.X + sign * directions[currentDirection].X;
            int newY = location.Y + sign * directions[currentDirection].Y;

            if (0 <= newX && newX < gridSize
                && 0 <= newY && newY < gridSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the new location of the rover
        /// based on its previous location, direction and motion type (forward or backwards).
        /// </summary>
        /// <param name="location"></param>
        /// <param name="currentDirection"></param>
        /// <param name="motionType"></param>
        /// <returns></returns>
        private static Point Move(Point location, int currentDirection, MotionType motionType)
        {
            int sign = 1;
            if (motionType == MotionType.Backwards)
            {
                sign = -1;
            }

            Point newLocation = new Point(
                location.X + sign * directions[currentDirection].X,
                location.Y + sign * directions[currentDirection].Y);

            return newLocation;
        }

        /// <summary>
        /// Checks if the command sequence contains valid characters (R, L, F, B).
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        private static bool IsCommandSequenceValid(string commands)
        {
            if (String.IsNullOrEmpty(commands))
            {
                return false;
            }

            string pattern = @"^[RLFB]*$";
            Match match = Regex.Match(commands, pattern);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Run Method

        /// <summary>
        /// Processes the commands sequence and returns true if all the commands
        /// have been executed successfully. If the rover is at the end of the grid, 
        /// the next "move forward" command won't get executed since we cannot move outside the grid.
        /// </summary>
        /// <param name="commands">The commands sequence.</param>
        /// <param name="endX">The x-coordinate of the rover's final location.</param>
        /// <param name="endY">The y-coordinate of the rover's final location.</param>
        /// <param name="lastSuccessIndex">The index of the last successfully executed command.</param>
        /// <returns></returns>
        public static bool Run(string commands, out int endX, out int endY, out int lastSuccessIndex)
        {
            if (!IsCommandSequenceValid(commands))
            {
                throw new InvalidCommandsException(String.Format("The specified command sequence ({0}) contains invalid characters.", commands), commands);
            }

            // initially the rover is facing North
            int currentDirection = 0;

            // current location of the rover - initially (0, 0)
            Point currentLocation = new Point(0, 0);

            int commandIndex = 0;
            foreach (char command in commands)
            {
                commandIndex++;
                switch (command)
                {
                    case 'R':
                        {
                            currentDirection = GetNextDirection(currentDirection, RotationType.Right);
                            break;
                        }
                    case 'L':
                        {
                            currentDirection = GetNextDirection(currentDirection, RotationType.Left);
                            break;
                        }
                    case 'B':
                    case 'F':
                        {
                            MotionType motionType;

                            if (command == 'F')
                            {
                                motionType = MotionType.Forward;
                            }
                            else
                            {
                                motionType = MotionType.Backwards;
                            }

                            if (CanMove(currentLocation, currentDirection, motionType))
                            {
                                currentLocation = Move(currentLocation, currentDirection, motionType);
                            }
                            else
                            {
                                // cannot execute the command - the rover is at the end of the grid 
                                // and cannot move any further
                                lastSuccessIndex = commandIndex - 1;
                                endX = currentLocation.X;
                                endY = currentLocation.Y;
                                return false;
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            // the rover has executed all the commands successfully
            lastSuccessIndex = commandIndex;
            endX = currentLocation.X;
            endY = currentLocation.Y;
            return true;
        }

        #endregion
    }
}
