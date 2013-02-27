using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IEnumerableExtensionUnitTests
{
    [TestClass]
    public class IEnumerableExtensionTest
    {
        [TestMethod]
        public void TestMin1()
        {
            float[] floatArray = new float[] { 3.141592f, -90.12f, 4.789f, 0.177f };
            float minFloat = floatArray.Min();

            Assert.AreEqual(-90.12f, minFloat);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMin2_ThrowsException()
        {
            float[] floatArray = new float[0];
            float minFloat = floatArray.Min();
        }

        [TestMethod]
        public void TestMin3()
        {
            string[] stringsArray = new string[] { "ala", "bala", "porto", "kala", "aaalaaa" };
            string minString = stringsArray.Min();

            Assert.AreEqual("aaalaaa", minString);
        }

        [TestMethod]
        public void TestMax1()
        {
            double[] doubleArray = new double[] { 9.23423, 2.718281828, -18.39, 7.61, -10.11 };
            double maxDouble = doubleArray.Max();

            Assert.AreEqual(9.23423, maxDouble);
        }

        [TestMethod]
        public void TestSum1()
        {
            decimal[] decimalArray = new decimal[] { 23, 8.14M, 0.1023M, -13 };
            decimal sum = decimalArray.Sum();

            Assert.AreEqual(18.2423M, sum);
        }

        [TestMethod]
        public void TestProduct1()
        {
            long[] longArray = new long[] { 13, 90, -10, 4, 76 };
            long product = longArray.Product();

            Assert.AreEqual(-3556800, product);
        }

        [TestMethod]
        public void TestAverage1()
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6 };
            decimal average = intArray.Average();

            Assert.AreEqual(3.5M, average);
        }
    }
}
