using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestStatisticalMethods
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMin1()
        {
            int min = StatisticalMethods.Min(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMin2()
        {
            int min = StatisticalMethods.Min();

            Assert.Fail();
        }

        [TestMethod]
        public void TestMin3()
        {
            int min = StatisticalMethods.Min(-902);

            Assert.AreEqual(-902, min);
        }

        [TestMethod]
        public void TestMin4()
        {
            int min = StatisticalMethods.Min(7, 6, 0, 9);

            Assert.AreEqual(0, min);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMax1()
        {
            int min = StatisticalMethods.Max(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMax2()
        {
            int max = StatisticalMethods.Max();

            Assert.Fail();
        }

        [TestMethod]
        public void TestMax3()
        {
            int min = StatisticalMethods.Max(23452);

            Assert.AreEqual(23452, min);
        }

        [TestMethod]
        public void TestMax4()
        {
            int max = StatisticalMethods.Max(7, 6, 0, 9);

            Assert.AreEqual(9, max);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAverage1()
        {
            double average = StatisticalMethods.Average(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAverage2()
        {
            double average = StatisticalMethods.Average();

            Assert.Fail();
        }

        [TestMethod]
        public void TestAverage3()
        {
            double average = StatisticalMethods.Average(34);

            Assert.AreEqual(34, average);
        }

        [TestMethod]
        public void TestAverage4()
        {
            double average = StatisticalMethods.Average(7, 6, 0, 9);

            Assert.AreEqual(5.5, average);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSum1()
        {
            int sum = StatisticalMethods.Sum(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSum2()
        {
            int sum = StatisticalMethods.Sum();

            Assert.Fail();
        }

        [TestMethod]
        public void TestSum3()
        {
            int sum = StatisticalMethods.Sum(-98);

            Assert.AreEqual(-98, sum);
        }

        [TestMethod]
        public void TestSum4()
        {
            int sum = StatisticalMethods.Sum(7, 6, 0, 9);

            Assert.AreEqual(22, sum);
        }







        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProduct1()
        {
            int product = StatisticalMethods.Product(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestProduct2()
        {
            int product = StatisticalMethods.Product();

            Assert.Fail();
        }

        [TestMethod]
        public void TestProduct3()
        {
            int product = StatisticalMethods.Product(-42);

            Assert.AreEqual(-42, product);
        }

        [TestMethod]
        public void TestProduct4()
        {
            int product = StatisticalMethods.Product(7, 6, 1, 9);

            Assert.AreEqual(378, product);
        }
    }
}
