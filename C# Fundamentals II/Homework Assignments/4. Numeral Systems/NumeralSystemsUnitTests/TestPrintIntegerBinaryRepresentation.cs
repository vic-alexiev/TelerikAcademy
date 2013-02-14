using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumeralSystemsUnitTests
{
    [TestClass]
    public class TestPrintIntegerBinaryRepresentation
    {
        [TestMethod]
        public void TestGetBinaryRepresentation1()
        {
            string binary = PrintIntegerBinaryRepresentation.GetBinaryRepresentation(32767);

            string expectedBinary = "0111111111111111";

            Assert.AreEqual(expectedBinary, binary);
        }

        [TestMethod]
        public void TestGetBinaryRepresentation2()
        {
            string binary = PrintIntegerBinaryRepresentation.GetBinaryRepresentation(0);

            string expectedBinary = "0000000000000000";

            Assert.AreEqual(expectedBinary, binary);
        }

        [TestMethod]
        public void TestGetBinaryRepresentation3()
        {
            string binary = PrintIntegerBinaryRepresentation.GetBinaryRepresentation(-1721);

            string expectedBinary = "1111100101000111";

            Assert.AreEqual(expectedBinary, binary);
        }
    }
}
