// ********************************
// <copyright file="ChessPieceTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace KingSurvivalUnitTests
{
    using System;
    using KingSurvival;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="ChessPiece"/> class functionality.
    /// </summary>
    [TestClass]
    public class ChessPieceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_WhitespaceCharacterThrowsException()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.King, ' ', 3, 3);
        }

        [TestMethod]
        public void TestConstructor_CreateKingWithValidParameters()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.King, 'K', 3, 7);

            Assert.AreEqual(ChessPieceType.King, chessPiece.Type);
            Assert.AreEqual('K', chessPiece.Character);
            Assert.AreEqual(3, chessPiece.Row);
            Assert.AreEqual(7, chessPiece.Col);
        }

        [TestMethod]
        public void TestConstructor_CreatePawnWithValidParameters()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.Pawn, 'A', 7, 7);

            Assert.AreEqual(ChessPieceType.Pawn, chessPiece.Type);
            Assert.AreEqual('A', chessPiece.Character);
            Assert.AreEqual(7, chessPiece.Row);
            Assert.AreEqual(7, chessPiece.Col);
        }

        [TestMethod]
        public void TestChessPieceClone()
        {
            ChessPiece chessPiece = new ChessPiece(ChessPieceType.Pawn, 'A', 7, 7);

            ChessPiece newChessPiece = (ChessPiece)chessPiece.Clone();

            Assert.IsFalse(object.ReferenceEquals(chessPiece, newChessPiece));
            Assert.IsTrue(chessPiece.Row == newChessPiece.Row);
            Assert.IsTrue(chessPiece.Col == newChessPiece.Col);
            Assert.IsTrue(chessPiece.Character == newChessPiece.Character);
            Assert.IsTrue(chessPiece.Type == newChessPiece.Type);
        }
    }
}