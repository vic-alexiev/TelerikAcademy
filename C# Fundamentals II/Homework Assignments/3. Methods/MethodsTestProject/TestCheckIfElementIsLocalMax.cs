using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestCheckIfElementIsLocalMax
    {
        [TestMethod]
        public void TestIsLocalMax1()
        {
            bool localMax = CheckIfElementIsLocalMax.IsLocalMax(new int[] { 1, 5, 7, 6, 9, 90, 234, -346 }, 6);

            bool expectedAnswer = true;

            Assert.AreEqual(expectedAnswer, localMax);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIsLocalMax2_ThrowsException()
        {
            bool localMax = CheckIfElementIsLocalMax.IsLocalMax(new int[] { 1, 5 }, -235);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIsLocalMax3_ThrowsException()
        {
            bool localMax = CheckIfElementIsLocalMax.IsLocalMax(new int[] { 1, 5 }, 10);

            Assert.Fail();
        }

        [TestMethod]
        public void TestIsLocalMax4()
        {
            bool localMax = CheckIfElementIsLocalMax.IsLocalMax(new int[] { 1, 5 }, 0);

            bool expectedAnswer = false;

            Assert.AreEqual(expectedAnswer, localMax);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsLocalMax5_ThrowsException()
        {
            bool localMax = CheckIfElementIsLocalMax.IsLocalMax(new int[0], 25);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsLocalMax6_ThrowsException()
        {
            bool localMax = CheckIfElementIsLocalMax.IsLocalMax((int[])null, 1);

            Assert.Fail();
        }
    }
}
