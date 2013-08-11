// ********************************
// <copyright file="ChessboardManagerTest.cs" company="Telerik Academy">
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
    /// Used to test the <see cref="ChessboardManager"/> class functionality.
    /// </summary>
    [TestClass]
    public class ChessboardManagerTest
    {
        #region TryMoveKing & TryMovePawn Tests

        [TestMethod]
        public void TestTryMoveKing_InvalidCommand1()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryMoveKing("qwerty");

            Assert.IsFalse(success, "Move king command returns success for invalid commands.");
        }

        [TestMethod]
        public void TestTryMoveKing_InvalidCommand2()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryMoveKing("KDR");

            Assert.IsFalse(success, "Move king to an invalid position returns success.");
        }

        [TestMethod]
        public void TestTryMovePawn_InvalidCommand1()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryMovePawn(null);

            Assert.IsFalse(success, "Move pawn command returns success for invalid commands.");
        }

        [TestMethod]
        public void TestTryMovePawn_InvalidCommand2()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryMovePawn("ADL");

            Assert.IsFalse(success, "Move pawn to an invalid position returns success.");
        }

        [TestMethod]
        public void TestTryMoveKing_CommandKingUpLeft1()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryMoveKing("KUL");

            Assert.IsTrue(success, "Command execution fails for the valid command \"KUL\".");
        }

        [TestMethod]
        public void TestTryMoveKing_CommandKingUpLeft2()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            ChessPiece chessPieceBefore = chessboardManager.GetChessPiece('K');

            bool success = chessboardManager.TryMoveKing("KUL");
            Assert.IsTrue(success);

            ChessPiece chessPieceAfter = chessboardManager.GetChessPiece('K');

            Assert.AreEqual(chessPieceBefore.Row - 1, chessPieceAfter.Row, "King position is incorrect.");
            Assert.AreEqual(chessPieceBefore.Col - 1, chessPieceAfter.Col, "King position is incorrect.");
        }

        [TestMethod]
        public void TestTryMovePawn_CommandPawnDownRight1()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            bool success = chessboardManager.TryMovePawn("ADR");

            Assert.IsTrue(success, "Command execution fails for the valid command \"ADR\".");
        }

        [TestMethod]
        public void TestTryMovePawn_CommandPawnDownRight2()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            ChessPiece chessPieceBefore = chessboardManager.GetChessPiece('A');

            bool success = chessboardManager.TryMovePawn("ADR");
            Assert.IsTrue(success);

            ChessPiece chessPieceAfter = chessboardManager.GetChessPiece('A');

            Assert.AreEqual(chessPieceBefore.Row + 1, chessPieceAfter.Row, "Pawn position is incorrect.");
            Assert.AreEqual(chessPieceBefore.Col + 1, chessPieceAfter.Col, "Pawn position is incorrect.");
        }

        #endregion

        #region KingMovesCount Tests

        [TestMethod]
        public void TestKingMovesCount()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");

            chessboardManager.TryMovePawn("CDR");

            chessboardManager.TryMoveKing("KUR");

            Assert.AreEqual(
                7,
                chessboardManager.KingMovesCount,
                "The moves made by the king are not counted correctly.");
        }

        #endregion

        #region KingWins Tests

        [TestMethod]
        public void TestKingWins_Case1()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");

            chessboardManager.TryMovePawn("CDR");

            chessboardManager.TryMoveKing("KUR");

            Assert.IsTrue(
                chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        [TestMethod]
        public void TestKingWins_Case2()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMovePawn("BDL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMovePawn("BDL");
            chessboardManager.TryMoveKing("KUL");

            Assert.AreEqual(7, chessboardManager.KingMovesCount, "King moves are not counted correctly.");

            Assert.IsTrue(
                chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        [TestMethod]
        public void TestKingWins_Case3()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMoveKing("KDL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMoveKing("KDR");

            // the king: (5, 1)
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMovePawn("DDR");
            chessboardManager.TryMoveKing("KUL");

            // pawn C: (1, 5)
            chessboardManager.TryMovePawn("CDR");

            // pawn B: (1, 3)
            chessboardManager.TryMovePawn("BDR");

            // the king: (2, 0)
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMovePawn("DDL");

            // the king: (1, 1)
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");

            Assert.IsTrue(
                chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        [TestMethod]
        public void TestKingWins_PawnsCannotMoveAnyFurther()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            // A reaches line 7 
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");

            // B reaches line 7 
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDL");
            chessboardManager.TryMovePawn("BDL");

            // C reaches line 7 
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDR");
            chessboardManager.TryMovePawn("CDR");
            chessboardManager.TryMovePawn("CDL");

            // D gets blocked at (6, 0) by C which is at (7, 1)
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");

            // The king does not need to reach row 0 to win. 
            Assert.IsTrue(
                chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        [TestMethod]
        public void TestKingWins_PawnsCanMoveAndKingNotAtRow0()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADR");

            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDR");
            chessboardManager.TryMovePawn("BDL");

            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDL");
            chessboardManager.TryMovePawn("CDR");
            chessboardManager.TryMovePawn("CDR");

            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");

            // the king does not reach row 0
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");

            Assert.IsFalse(
                chessboardManager.KingWins(),
                "The check whether the king wins doesn't work correctly.");
        }

        #endregion

        #region KingLoses Tests

        [TestMethod]
        public void TestKingLoses_ReturnsTrue()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            // move the king to (2, 2)
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");

            // move pawn A to (3, 1)
            chessboardManager.TryMovePawn("ADR");
            chessboardManager.TryMovePawn("ADL");
            chessboardManager.TryMovePawn("ADR");

            // move pawn B to (1, 1)
            chessboardManager.TryMovePawn("BDL");

            // move pawn C to (1, 3)
            chessboardManager.TryMovePawn("CDL");

            // move pawn D to (3, 3)
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");
            chessboardManager.TryMovePawn("DDL");

            Assert.IsTrue(
                chessboardManager.KingLoses(),
                "The check whether the king loses doesn't work correctly.");
        }

        [TestMethod]
        public void TestKingLoses_ReturnsFalse()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            // move the king to (2, 2)
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUL");
            chessboardManager.TryMoveKing("KUR");
            chessboardManager.TryMoveKing("KUR");

            // move pawn A to (1, 1)
            chessboardManager.TryMovePawn("ADR");

            // move pawn B to (1, 3)
            chessboardManager.TryMovePawn("BDR");

            // move pawn C to (1, 5)
            chessboardManager.TryMovePawn("CDR");

            // move pawn D to (1, 7)
            chessboardManager.TryMovePawn("DDR");

            Assert.IsFalse(
                chessboardManager.KingLoses(),
                "The check whether the king loses doesn't work correctly.");
        }

        #endregion

        #region GetChessPiece Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetChessPiece_ThrowsException()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            ChessPiece chessPiece = chessboardManager.GetChessPiece('E');
        }

        #endregion

        #region ToString Tests

        [TestMethod]
        public void TestToString()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            string expectedString =
                "    0 1 2 3 4 5 6 7\r\n" +
                "   -----------------\r\n" +
                "0 | A - B - C - D - |\r\n" +
                "1 | - + - + - + - + |\r\n" +
                "2 | + - + - + - + - |\r\n" +
                "3 | - + - + - + - + |\r\n" +
                "4 | + - + - + - + - |\r\n" +
                "5 | - + - + - + - + |\r\n" +
                "6 | + - + - + - + - |\r\n" +
                "7 | - + - K - + - + |\r\n" +
                "   -----------------\r\n";

            Assert.AreEqual(
                expectedString,
                chessboardManager.ToString(),
                "Converting to string doesn't work correctly.");
        }

        #endregion

        #region GetValidCommands Tests

        [TestMethod]
        public void TestGetValidCommands()
        {
            ChessboardManager chessboardManager = new ChessboardManager();

            string validCommands = chessboardManager.GetValidCommands();

            string expectedCommands =
                "King: KUL, KUR, KDL, KDR\r\n" +
                "Pawns: ADL, ADR, BDL, BDR, CDL, CDR, DDL, DDR\r\n";

            Assert.AreEqual(expectedCommands, validCommands, "The valids commands are not those expected.");
        }

        #endregion
    }
}