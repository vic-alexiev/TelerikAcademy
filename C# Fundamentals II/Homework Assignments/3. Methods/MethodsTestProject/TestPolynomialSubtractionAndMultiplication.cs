using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestPolynomialSubtractionAndMultiplication
    {
        [TestMethod]
        public void TestMultiplyPolynomials1()
        {
            int[] a = new int[] { 1, 1, 0, 1 };
            int[] b = new int[] { 1, 0, -1 };

            int[] result = PolynomialSubtractionAndMultiplication.MultiplyPolynomials(a, b);

            int[] expectedResult = new[] { 1, 1, -1, 0, 0, -1 };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestMultiplyPolynomials2()
        {
            int[] a = new int[] { 2, 1 };
            int[] b = new int[] { -17, 4, 3, 1 };

            int[] result = PolynomialSubtractionAndMultiplication.MultiplyPolynomials(a, b);

            int[] expectedResult = new[] { -34, -9, 10, 5, 1 };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSubtractPolynomials1()
        {
            int[] a = new int[] { 6, 0, -1, 0, 1 };
            int[] b = new int[] { 7, 0, 1, -9 };

            int[] result = PolynomialSubtractionAndMultiplication.SubtractPolynomials(a, b);

            int[] expectedResult = new[] { -1, 0, -2, 9, 1 };

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
