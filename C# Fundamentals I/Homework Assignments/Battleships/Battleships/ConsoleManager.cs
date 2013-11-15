// ********************************
// <copyright file="ConsoleManager.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    using System;
    using System.IO;

    /// <summary>
    /// Used to handle Console I/O operations.
    /// </summary>
    public class ConsoleManager : IIOManager
    {
        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(string value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator,
        /// to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed
        /// by the current line terminator, to the standard output stream using the specified
        /// format information.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg">An array of objects to write using format.</param>
        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines
        /// are available.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Sets the <see cref="System.Console.In"/> property to the specified 
        /// <see cref="System.IO.TextReader"/>.
        /// </summary>
        /// <param name="newIn">A stream that is the new standard input.</param>
        public void SetIn(TextReader newIn)
        {
            Console.SetIn(newIn);
        }

        /// <summary>
        /// Sets the <see cref="System.Console.Out"/> property to the specified 
        /// <see cref="System.IO.TextWriter"/> object.
        /// </summary>
        /// <param name="newOut">A stream that is the new standard output.</param>
        public void SetOut(TextWriter newOut)
        {
            Console.SetOut(newOut);
        }
    }
}
