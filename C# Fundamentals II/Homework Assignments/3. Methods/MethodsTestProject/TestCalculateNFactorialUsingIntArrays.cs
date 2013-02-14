using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestCalculateNFactorialUsingIntArrays
    {
        [TestMethod]
        public void TestMultiplyPositiveIntegers1()
        {
            int[] a = new int[] { 9, 6, 3, 4 };
            int[] b = new int[] { 3, 7, 9, 1 };

            int[] c = CalculateNFactorialUsingIntArrays.MultiplyPositiveIntegers(a, b);

            int[] expectedResult = new int[] { 7, 3, 0, 0, 2, 6, 8 };

            CollectionAssert.AreEqual(expectedResult, c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFactorial11()
        {
            int[] c = CalculateNFactorialUsingIntArrays.Factorial1(-10);

            Assert.Fail();
        }

        [TestMethod]
        public void TestFactorial12()
        {
            int[] c = CalculateNFactorialUsingIntArrays.Factorial1(21);

            int[] expectedResult = new int[] { 0, 0, 0, 0, 4, 4, 9, 0, 7, 1, 7, 1, 2, 4, 9, 0, 9, 0, 1, 5 };

            CollectionAssert.AreEqual(expectedResult, c);
        }
    }
}
