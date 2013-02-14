using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiscUtil;
using System;

namespace MethodsTestProject
{
    [TestClass]
    public class TestGenericStatisticalMethods
    {
        [TestMethod]
        public void TestMin1()
        {
            int min = GenericStatisticalMethods.Min(7, 8, -9, 5, -5);

            int expectedMin = -9;

            Assert.AreEqual(expectedMin, min);
        }

        [TestMethod]
        public void TestMax1()
        {
            int max = GenericStatisticalMethods.Max(7, 8, -9, 5, -5);

            int expectedMax = 8;

            Assert.AreEqual(expectedMax, max);
        }

        [TestMethod]
        public void TestMax2()
        {
            decimal max = GenericStatisticalMethods.Max<decimal>(17, 28.0M, -9.0M, 5, -5);

            decimal expectedMax = 28;

            Assert.AreEqual(expectedMax, max);
        }

        [TestMethod]
        public void TestAccumulate1()
        {
            int sum = GenericStatisticalMethods.Accumulate(Operator.Add, 0, 8, 9, 12, -69, 23);

            int expectedSum = -17;

            Assert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void TestAccumulate2()
        {
            long product = GenericStatisticalMethods.Accumulate<long>(Operator.Multiply, 1, 23, -15, 50, 7);

            int expectedProduct = -120750;

            Assert.AreEqual(expectedProduct, product);
        }

        [TestMethod]
        public void TestAverage1()
        {
            double average = GenericStatisticalMethods.Average<double>(1, 2, 3, 4, 5, 6);

            double expectedAverage = 3.5;

            Assert.AreEqual(expectedAverage, average);
        }
    }
}
