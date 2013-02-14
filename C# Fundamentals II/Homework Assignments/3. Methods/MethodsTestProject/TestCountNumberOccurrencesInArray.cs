using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestCountNumberOccurrencesInArray
    {
        [TestMethod]
        public void TestCount1()
        {
            int count = CountNumberOccurrencesInArray.Count(new int[] { 1, 2, 3, 6, 9, 0, 6 }, 6);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void TestCount2()
        {
            int count = CountNumberOccurrencesInArray.Count(new double[] { -234, 0.0, 3.3453, 3.1415, 2.718, 1.618, 0.0, -234.000000 }, -234);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void TestCount3()
        {
            int count = CountNumberOccurrencesInArray.Count(null, 6);

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void TestCount4()
        {
            int count = CountNumberOccurrencesInArray.Count(new decimal[0], -234);

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, count);
        }
    }
}
