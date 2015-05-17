using FruitWars.Enums;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FruitWars
{
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
            bool anotherGame;
            do
            {
                anotherGame = false;

                int playersCount = 2;
                string[] warriorCharacters = new string[playersCount];
                for (int i = 0; i < playersCount; i++)
                {
                    warriorCharacters[i] = ReadWarriorCharacter(ioManager, i);
                }

                gridManager.ArrangeGameObjects(warriorCharacters);
                ioManager.WriteLine(gridManager.DisplayGrid());

                int currentPlayerIndex = 0;
                while (true)
                {
                    MoveResult result;
                    do
                    {
                        result = MakeValidMove(gridManager, ioManager, currentPlayerIndex);

                        ioManager.WriteLine(gridManager.DisplayGrid(result));
                        if (result == MoveResult.DrawnBattle ||
                            result == MoveResult.Battle)
                        {
                            if (ReadAnotherGameResponse(ioManager) == "n")
                            {
                                return;
                            }
                            else
                            {
                                anotherGame = true;
                                break;
                            }
                        }

                    } while (result == MoveResult.MoreMoves);

                    if (anotherGame) break;

                    gridManager.RefreshWarriorsRemainingMoves();

                    if (result == MoveResult.NoMoreMoves)
                    {
                        currentPlayerIndex = (++currentPlayerIndex) % playersCount;
                    }
                }
            } while (anotherGame);
        }

        private static string ReadAnotherGameResponse(IIOManager ioManager)
        {
            string anotherGameResponse;
            do
            {
                ioManager.Write("Do you want another game? (y/n)");
                anotherGameResponse = ioManager.ReadLine();

            } while (!Regex.IsMatch(anotherGameResponse, "^[yn]$"));
            return anotherGameResponse;
        }

        private static MoveResult MakeValidMove(GridManager gridManager, IIOManager ioManager, int playerIndex)
        {
            MoveResult result;
            Direction direction;
            do
            {
                ioManager.Write(string.Format("{0}Player {1}, please make a move.", Environment.NewLine, playerIndex + 1));
                direction = ReadDirection(ioManager);

            } while ((result = gridManager.TryMove(direction, playerIndex)) == MoveResult.InvalidDirection);
            return result;
        }

        private static string ReadWarriorCharacter(IIOManager ioManager, int playerIndex)
        {
            string character;
            do
            {
                ioManager.Write(string.Format("Player {0}, please select a warrior. Turtle, monkey or pigeon? (t/m/p)", playerIndex + 1));
                character = ioManager.ReadLine();

            } while (!Regex.IsMatch(character, "^[tmp]$"));
            return character;
        }

        private static Direction ReadDirection(IIOManager ioManager)
        {
            ConsoleKeyInfo key;
            do
            {
                key = ioManager.ReadKey();
            } while (
                key.Key != ConsoleKey.LeftArrow &&
                key.Key != ConsoleKey.UpArrow &&
                key.Key != ConsoleKey.RightArrow &&
                key.Key != ConsoleKey.DownArrow);
            return GetDirection(key.Key);
        }

        private static Direction GetDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                default:
                    return Direction.Up;
            }
        }
    }
}
