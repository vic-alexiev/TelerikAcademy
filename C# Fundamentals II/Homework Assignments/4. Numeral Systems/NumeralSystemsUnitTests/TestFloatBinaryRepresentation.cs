using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeralSystemsUnitTests
{
    [TestClass]
    public class TestFloatBinaryRepresentation
    {
        [TestMethod]
        public void TestFloatBinaryRepresentation1()
        {
            FloatBinaryRepresentation bin = new FloatBinaryRepresentation(-27.25f);

            char expectedSign = '1';
            string expectedExponent = "10000011";
            string expectedMantissa = "10110100000000000000000";

            Assert.AreEqual(expectedSign, bin.Sign);
            Assert.AreEqual(expectedExponent, bin.Exponent);
            Assert.AreEqual(expectedMantissa, bin.Mantissa);
        }

        [TestMethod]
        public void TestFloatBinaryRepresentation2()
        {
            FloatBinaryRepresentation bin = new FloatBinaryRepresentation(0.15625f);

            char expectedSign = '0';
            string expectedExponent = "01111100";
            string expectedMantissa = "01000000000000000000000";

            Assert.AreEqual(expectedSign, bin.Sign);
            Assert.AreEqual(expectedExponent, bin.Exponent);
            Assert.AreEqual(expectedMantissa, bin.Mantissa);
        }

        [TestMethod]
        public void TestFloatBinaryRepresentation3()
        {
            FloatBinaryRepresentation bin = new FloatBinaryRepresentation(-999.999f);

            char expectedSign = '1';
            string expectedExponent = "10001000";
            string expectedMantissa = "11110011111111111110000";

            Assert.AreEqual(expectedSign, bin.Sign);
            Assert.AreEqual(expectedExponent, bin.Exponent);
            Assert.AreEqual(expectedMantissa, bin.Mantissa);
        }

        [TestMethod]
        public void TestFloatBinaryRepresentation4()
        {
            FloatBinaryRepresentation bin = new FloatBinaryRepresentation(0.000001f);

            char expectedSign = '0';
            string expectedExponent = "01101011";
            string expectedMantissa = "00001100011011110111101";

            Assert.AreEqual(expectedSign, bin.Sign);
            Assert.AreEqual(expectedExponent, bin.Exponent);
            Assert.AreEqual(expectedMantissa, bin.Mantissa);
        }

        [TestMethod]
        public void TestFloatBinaryRepresentation5()
        {
            FloatBinaryRepresentation bin = new FloatBinaryRepresentation(0f);

            char expectedSign = '0';
            string expectedExponent = "00000000";
            string expectedMantissa = "00000000000000000000000";

            Assert.AreEqual(expectedSign, bin.Sign);
            Assert.AreEqual(expectedExponent, bin.Exponent);
            Assert.AreEqual(expectedMantissa, bin.Mantissa);
        }
    }
}
