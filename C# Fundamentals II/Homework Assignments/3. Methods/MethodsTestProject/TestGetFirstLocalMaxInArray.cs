using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestGetFirstLocalMaxInArray
    {
        [TestMethod]
        public void TestGetFirstLocalMax1()
        {
            int firstLocalMaxIndex = GetFirstLocalMaxInArray.GetIndexOfFirstLocalMax(new int[] { 6, 6, 6, 6, 6 });

            int expectedIndex = -1;

            Assert.AreEqual(expectedIndex, firstLocalMaxIndex);
        }

        [TestMethod]
        public void TestGetFirstLocalMax2()
        {
            int firstLocalMaxIndex = GetFirstLocalMaxInArray.GetIndexOfFirstLocalMax(new int[] { 6, 7, 9, 10, 10 });

            int expectedIndex = -1;

            Assert.AreEqual(expectedIndex, firstLocalMaxIndex);
        }

        [TestMethod]
        public void TestGetFirstLocalMax3()
        {
            int firstLocalMaxIndex = GetFirstLocalMaxInArray.GetIndexOfFirstLocalMax(new int[] { 6, 7, 9, 0, -1 });

            int expectedIndex = 2;

            Assert.AreEqual(expectedIndex, firstLocalMaxIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetFirstLocalMax4_ThrowsException()
        {
            int firstLocalMaxIndex = GetFirstLocalMaxInArray.GetIndexOfFirstLocalMax((int[])null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetFirstLocalMax5_ThrowsException()
        {
            int firstLocalMaxIndex = GetFirstLocalMaxInArray.GetIndexOfFirstLocalMax(new int[0]);

            Assert.Fail();
        }

        [TestMethod]
        public void TestGetFirstLocalMax6()
        {
            int firstLocalMaxIndex = GetFirstLocalMaxInArray.GetIndexOfFirstLocalMax(new decimal[] { -245.98M, 6.79M, 5.234M, 9.0M, 0, -1 });

            int expectedIndex = 1;

            Assert.AreEqual(expectedIndex, firstLocalMaxIndex);
        }
    }
}
