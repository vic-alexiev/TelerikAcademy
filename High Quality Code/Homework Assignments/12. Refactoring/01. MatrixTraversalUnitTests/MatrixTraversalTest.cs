// ********************************
// <copyright file="MatrixTraversalTest.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace MatrixTraversalUnitTests
{
    using System;
    using MatrixTraversal;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the matrix traversal functionality.
    /// </summary>
    [TestClass]
    public class MatrixTraversalTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixConstructor1_ThrowsException()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrixConstructor2_ThrowsException()
        {
            Matrix matrix = new Matrix(Matrix.MaxSize + 1);
        }

        [TestMethod]
        public void TestMatrixTraverse1()
        {
            Matrix matrix = new Matrix(1);

            matrix.Traverse();

            Assert.AreEqual("  1", matrix.ToString(), "Traversing 1x1 matrix is incorrect.");
        }

        [TestMethod]
        public void TestMatrixTraverse2()
        {
            Matrix matrix = new Matrix(2);

            matrix.Traverse();

            Assert.AreEqual("  1  4\r\n  3  2", matrix.ToString(), "Traversing 2x2 matrix is incorrect.");
        }

        [TestMethod]
        public void TestMatrixTraverse3()
        {
            Matrix matrix = new Matrix(3);

            matrix.Traverse();

            Assert.AreEqual("  1  7  8\r\n  6  2  9\r\n  5  4  3", matrix.ToString(), "Traversing 3x3 matrix is incorrect.");
        }

        [TestMethod]
        public void TestMatrixTraverse4()
        {
            Matrix matrix = new Matrix(6);

            matrix.Traverse();

            Assert.AreEqual(
                "  1 16 17 18 19 20\r\n" +
                " 15  2 27 28 29 21\r\n" +
                " 14 31  3 26 30 22\r\n" +
                " 13 36 32  4 25 23\r\n" +
                " 12 35 34 33  5 24\r\n" +
                " 11 10  9  8  7  6",
                matrix.ToString(),
                "Traversing 6x6 matrix is incorrect.");
        }
    }
}
