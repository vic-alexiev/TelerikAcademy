using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestAddPositiveIntegersAsArrays
    {
        [TestMethod]
        public void TestAddPositiveIntegers1()
        {
            string a = "6895";
            string b = "0177";

            string sum = AddPositiveIntegersAsArrays.AddPositiveIntegers(a, b);

            string expectedSum = "7072";

            Assert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddPositiveIntegers3_ThrowsException()
        {
            string a = "-2354";
            string b = "896";

            string sum = AddPositiveIntegersAsArrays.AddPositiveIntegers(a, b);

            Assert.Fail();
        }
    }
}
