using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixUnitTests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            Matrix<int> m1 = new Matrix<int>(matrix1);

            int[,] matrixContents = m1.GetData();

            CollectionAssert.AreEqual(matrix1, matrixContents);
        }

        [TestMethod]
        public void TestMatrixAddition()
        {
            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            int[,] matrix2 = new int[,]
            {
                {4, 5, 6},
                {-1, 0, 7},
                {3, 2, 1}
            };

            Matrix<int> m1 = new Matrix<int>(matrix1);
            Matrix<int> m2 = new Matrix<int>(matrix2);

            Matrix<int> m3 = m1 + m2;

            int[,] resultContents = m3.GetData();

            int[,] expectedResultContents = new int[,]
            {
                {5, 7, 3},
                {1, 1, 10},
                {6, 3, 3}
            };

            CollectionAssert.AreEqual(expectedResultContents, resultContents);
        }

        [TestMethod]
        public void TestMatrixSubtraction()
        {
            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            int[,] matrix2 = new int[,]
            {
                {4, 5, 6},
                {-1, 0, 7},
                {3, 2, 1}
            };

            Matrix<int> m1 = new Matrix<int>(matrix1);
            Matrix<int> m2 = new Matrix<int>(matrix2);

            Matrix<int> m3 = m1 - m2;

            int[,] resultContents = m3.GetData();

            int[,] expectedResultContents = new int[,]
            {
                {-3, -3, -9},
                {3, 1, -4},
                {0, -1, 1}
            };

            CollectionAssert.AreEqual(expectedResultContents, resultContents);
        }

        [TestMethod]
        public void TestMatrixMultiplication()
        {
            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            int[,] matrix2 = new int[,]
            {
                {4, 5, 6},
                {-1, 0, 7},
                {3, 2, 1}
            };

            Matrix<int> m1 = new Matrix<int>(matrix1);
            Matrix<int> m2 = new Matrix<int>(matrix2);

            Matrix<int> m3 = m1 * m2;

            int[,] resultContents = m3.GetData();

            int[,] expectedResultContents = new int[,]
            {
                {-7, -1, 17},
                {16, 16, 22},
                {17, 19, 27}
            };

            CollectionAssert.AreEqual(expectedResultContents, resultContents);
        }

        [TestMethod]
        public void TestMatrixTransposition()
        {
            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            Matrix<int> m1 = new Matrix<int>(matrix1);
            Matrix<int> m2 = m1.Transpose();

            int[,] resultContents = m2.GetData();

            int[,] expectedResultContents = new int[,]
            {
                {1, 2, 3},
                {2, 1, 1},
                {-3, 3, 2}
            };

            CollectionAssert.AreEqual(expectedResultContents, resultContents);
        }

        [TestMethod]
        public void TestMatrixMultiplicationByConstant()
        {
            int[,] matrix1 = new int[,]
            {
                {1, 2, -3},
                {2, 1, 3},
                {3, 1, 2}
            };

            Matrix<int> m1 = new Matrix<int>(matrix1);
            Matrix<int> m2 = m1 * 5;

            int[,] resultContents = m2.GetData();

            int[,] expectedResultContents = new int[,]
            {
                {5, 10, -15},
                {10, 5, 15},
                {15, 5, 10}
            };

            CollectionAssert.AreEqual(expectedResultContents, resultContents);
        }
    }
}
