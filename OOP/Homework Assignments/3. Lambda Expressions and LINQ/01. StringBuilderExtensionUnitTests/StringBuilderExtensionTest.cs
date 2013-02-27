using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace StringBuilderExtensionUnitTests
{
    [TestClass]
    public class StringBuilderExtensionTest
    {
        [TestMethod]
        public void TestSubstring1()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("0123456789");

            StringBuilder result = stringBuilder.Substring(2, 5);

            Assert.AreEqual("23456", result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSubstring2_ThrowsException()
        {
            StringBuilder stringBuilder = new StringBuilder();

            StringBuilder result = stringBuilder.Substring(2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSubstring3_ThrowsException()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("0123456789");

            StringBuilder result = stringBuilder.Substring(2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSubstring4_ThrowsException()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("0123456789");

            StringBuilder result = stringBuilder.Substring(-2, 5);
        }

        [TestMethod]
        public void TestSubstring5()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("0123456789");

            StringBuilder result = stringBuilder.Substring(0, 10);

            Assert.AreEqual("0123456789", result.ToString());
        }

        [TestMethod]
        public void TestSubstring6()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("0123456789");

            StringBuilder result = stringBuilder.Substring(0, 0);

            Assert.AreEqual(String.Empty, result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSubstring7_ThrowsException()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("0123456789");

            StringBuilder result = stringBuilder.Substring(0, 11);
        }
    }
}
