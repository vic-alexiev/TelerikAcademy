using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestReverseNumberDigits
    {
        [TestMethod]
        public void TestIsInteger1()
        {
            bool isInteger = ReverseNumberDigits.IsInteger("2793562347856293476");

            bool expectedAnswer = true;

            Assert.AreEqual(expectedAnswer, isInteger);
        }

        [TestMethod]
        public void TestIsInteger2()
        {
            bool isInteger = ReverseNumberDigits.IsInteger("-27935623478562234234234545345365469199889");

            bool expectedAnswer = true;

            Assert.AreEqual(expectedAnswer, isInteger);
        }

        [TestMethod]
        public void TestIsInteger3()
        {
            bool isInteger = ReverseNumberDigits.IsInteger("+27785629");

            bool expectedAnswer = true;

            Assert.AreEqual(expectedAnswer, isInteger);
        }

        [TestMethod]
        public void TestIsInteger4()
        {
            bool isInteger = ReverseNumberDigits.IsInteger("+277abc629");

            bool expectedAnswer = false;

            Assert.AreEqual(expectedAnswer, isInteger);
        }

        [TestMethod]
        public void TestReverseInteger1()
        {
            string reversedInteger = ReverseNumberDigits.ReverseInteger("+123456789");

            string expectedString = "+987654321";

            Assert.AreEqual(expectedString, reversedInteger);
        }

        [TestMethod]
        public void TestReverseInteger2()
        {
            string reversedInteger = ReverseNumberDigits.ReverseInteger("-975312468");

            string expectedString = "-864213579";

            Assert.AreEqual(expectedString, reversedInteger);
        }

        [TestMethod]
        public void TestReverseInteger3()
        {
            string reversedInteger = ReverseNumberDigits.ReverseInteger("4456897234263475");

            string expectedString = "5743624327986544";

            Assert.AreEqual(expectedString, reversedInteger);
        }

        [TestMethod]
        public void TestReverseIntegerAsInteger1()
        {
            int reversedInteger = ReverseNumberDigits.ReverseInteger(92387352);

            int expectedInteger = 25378329;

            Assert.AreEqual(expectedInteger, reversedInteger);
        }

        [TestMethod]
        public void TestReverseIntegerAsInteger2()
        {
            int reversedInteger = ReverseNumberDigits.ReverseInteger(0);

            int expectedInteger = 0;

            Assert.AreEqual(expectedInteger, reversedInteger);
        }

        [TestMethod]
        public void TestReverseIntegerAsInteger3()
        {
            int reversedInteger = ReverseNumberDigits.ReverseInteger(-87958);

            int expectedInteger = -85978;

            Assert.AreEqual(expectedInteger, reversedInteger);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestReverseIntegerAsInteger4()
        {
            int reversedInteger = ReverseNumberDigits.ReverseInteger(1234567899);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestReverseIntegerAsInteger5()
        {
            int reversedInteger = ReverseNumberDigits.ReverseInteger(-1234567899);

            Assert.Fail();
        }
    }
}
