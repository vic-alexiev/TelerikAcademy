using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestPolynomialAddition
    {
        [TestMethod]
        public void TestAddPolynomials1()
        {
            int[] a = new int[] { -7, -3, 8 };
            int[] b = new int[] { 5, 3, -2 };

            int[] result = PolynomialAddition.AddPolynomials(a, b);

            int[] expectedResult = new int[] { -2, 0, 6 };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAddPolynomials2()
        {
            int[] a = new int[] { -5, 6 };
            int[] b = new int[] { 5, -6 };

            int[] result = PolynomialAddition.AddPolynomials(a, b);

            int[] expectedResult = new int[] { 0 };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAddPolynomials3()
        {
            int[] a = new int[] { -2, 0, 0, 7 };
            int[] b = new int[] { 1, -5, 0, 0, 1 };

            int[] result = PolynomialAddition.AddPolynomials(a, b);

            int[] expectedResult = new int[] { -1, -5, 0, 7, 1 };

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
