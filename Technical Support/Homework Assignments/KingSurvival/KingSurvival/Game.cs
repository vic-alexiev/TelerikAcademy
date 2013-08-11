// ********************************
// <copyright file="Game.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvival
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Used to initialize the game and perform the game loop.
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// For testing purposes only. Plays the game with I/O redirected to/from files.
        /// </summary>
        /// <param name="inputBytes">The content of the input file.</param>
        /// <param name="outputBytes">The content of the output file.</param>
        public static void RunWithIORedirected(byte[] inputBytes, byte[] outputBytes)
        {
            Stream inputStream = new MemoryStream(inputBytes);

            // fixes the "memory stream not expandable" problem
            Stream outputStream = new MemoryStream();
            outputStream.Write(outputBytes, 0, outputBytes.Length);

            using (StreamReader reader = new StreamReader(inputStream, Encoding.ASCII))
            {
                using (StreamWriter writer = new StreamWriter(outputStream, Encoding.ASCII))
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Run();
                }
            }
        }

        /// <summary>
        /// For testing purposes only. Plays the game with I/O redirected to/from files.
        /// </summary>
        /// <param name="inputFilePath">The path of the input file.</param>
        /// <param name="outputFilePath">The path of the output file.</param>
        /// <example>
        /// This example shows how to call the <see cref="RunWithIORedirected(string, string)"/> method.
        /// <code>
        /// class TestClass
        /// {
        ///     static void Main()
        ///     {
        ///         RunWithIORedirected(
        ///             Path.Combine(Environment.CurrentDirectory, "SampleInput.in"),
        ///             Path.Combine(Environment.CurrentDirectory, "SampleOutput.out"));
        ///     }
        /// }
        /// </code>
        /// </example>
        public static void RunWithIORedirected(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Run();
                }
            }
        }

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        private static void Main()
        {
            Run();
        }

        /// <summary>
        /// Starts the game loop.
        /// </summary>
        private static void Run()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            Console.WriteLine(
                "KING SURVIVAL refactored by IRIDIUM TEAM{0}{0}" +
                "The king has to reach the top row of the {0}" +
                "chessboard without being caught by the pawns.{0}" +
                "The valid commands are:{0}" +
                chessboardManager.GetValidCommands(), Environment.NewLine);

            bool kingsTurn = true;

            while (true)
            {
                if (chessboardManager.KingWins())
                {
                    Console.WriteLine("King wins in {0} moves.", chessboardManager.KingMovesCount);
                    break;
                }
                else if (chessboardManager.KingLoses())
                {
                    Console.WriteLine("King loses in {0} moves.", chessboardManager.KingMovesCount);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(chessboardManager);

                    string command;
                    bool moveSuccessful = false;
                    string actor = kingsTurn ? "King" : "Pawn";

                    do
                    {
                        Console.Write("{0}'s turn: ", actor);

                        command = Console.ReadLine();
                        command = command.Trim().ToUpper();

                        if (kingsTurn)
                        {
                            moveSuccessful = chessboardManager.TryMoveKing(command);
                        }
                        else
                        {
                            moveSuccessful = chessboardManager.TryMovePawn(command);
                        }

                        if (!moveSuccessful)
                        {
                            Console.WriteLine("Invalid move.");
                        }
                    }
                    while (!moveSuccessful);

                    kingsTurn = !kingsTurn;
                }
            }
        }

        /// <summary>
        /// Used when redirecting Console.In property to a file 
        /// because Console.ReadLine() throws an exception in that case.
        /// </summary>
        /// <param name="line">A line read from the <see cref="System.IO.TextReader"/> object.</param>
        /// <returns>True if reading can continue, false if EOF reached.</returns>
        /// <remarks>"Console class members that work normally when the underlying stream 
        /// is directed to a console might throw an exception if the stream is redirected, 
        /// for example, to a file." (The MSDN article about the Console class.)</remarks>
        private static bool TryReadLine(out string line)
        {
            line = string.Empty;
            StringBuilder result = new StringBuilder();
            int character;

            do
            {
                character = Console.Read();

                if (character > 0)
                {
                    result.Append((char)character);
                }
                else if (result.Length > 0)
                {
                    break;
                }
                else
                {
                    return false;
                }
            }
            while (character != 13);

            result.Replace("\r", string.Empty);
            result.Replace("\n", string.Empty);

            line = result.ToString();
            return true;
        }
    }
}