// ********************************
// <copyright file="BattleshipException.cs" company="Anonymous Solutions Inc.">
// Copyright (c) 2013 Anonymous Solutions Inc. All rights reserved.
// </copyright>
//
// ********************************
namespace Battleships
{
    using System;

    /// <summary>
    /// A custom exception class for the application.
    /// </summary>
    public class BattleshipException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BattleshipException"/> class.
        /// </summary>
        public BattleshipException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleshipException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception which caused this exception.</param>
        public BattleshipException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleshipException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public BattleshipException(string message)
            : this(message, null)
        {
        }
    }
}
