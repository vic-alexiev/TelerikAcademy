using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumeralSystems;

namespace NumeralSystemsUnitTests
{
    [TestClass]
    public class TestConverter
    {
        [TestMethod]
        public void TestFromDecimalToBinary1()
        {
            string binary = Converter.FromDecimal(8753, 2);

            string expectedBinary = "10001000110001";

            Assert.AreEqual(expectedBinary, binary);
        }

        [TestMethod]
        public void TestFromDecimalToBinary2()
        {
            string binary = Converter.FromDecimal(0, 2);

            string expectedBinary = "0";

            Assert.AreEqual(expectedBinary, binary);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromDecimalToBinary3_ThrowsException()
        {
            string binary = Converter.FromDecimal(-1024, 2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromDecimal1_ThrowsException()
        {
            string binary = Converter.FromDecimal(1024, 100);

            Assert.Fail();
        }

        [TestMethod]
        public void TestFromDecimalToBinary4()
        {
            string binary = Converter.FromDecimal(4294967296, 2);

            string expectedBinary = "100000000000000000000000000000000";

            Assert.AreEqual(expectedBinary, binary);
        }

        [TestMethod]
        public void TestFromBinaryToDecimal1()
        {
            long decimalValue = Converter.ToDecimal("1010100111", 2);

            long expectedDecimalValue = 679;

            Assert.AreEqual(expectedDecimalValue, decimalValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromBinaryToDecimal2_ThrowsException()
        {
            long decimalValue = Converter.ToDecimal(" ", 2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromBinaryToDecimal3_ThrowsException()
        {
            long decimalValue = Converter.ToDecimal(null, 2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToDecimal1_ThrowsException()
        {
            long decimalValue = Converter.ToDecimal("01110", -18);

            Assert.Fail();
        }

        [TestMethod]
        public void TestFromBinaryToDecimal4()
        {
            long decimalValue = Converter.ToDecimal("0000000000", 2);

            long expectedDecimalValue = 0;

            Assert.AreEqual(expectedDecimalValue, decimalValue);
        }

        [TestMethod]
        public void TestFromDecimalToHexadecimal1()
        {
            string hexValue = Converter.FromDecimal(3402288846, 16);

            string expectedHexValue = "CACACECE";

            Assert.AreEqual(expectedHexValue, hexValue);
        }

        [TestMethod]
        public void TestFromDecimalToHexadecimal2()
        {
            string hexValue = Converter.FromDecimal(92835, 16);

            string expectedHexValue = "16AA3";

            Assert.AreEqual(expectedHexValue, hexValue);
        }

        [TestMethod]
        public void TestFromDecimalToHexadecimal3()
        {
            string hexValue = Converter.FromDecimal(17769, 16);

            string expectedHexValue = "4569";

            Assert.AreEqual(expectedHexValue, hexValue);
        }

        [TestMethod]
        public void TestFromHexadecimalToDecimal1()
        {
            long decimalValue = Converter.ToDecimal("14ff", 16);

            long expectedDecimalValue = 5375;

            Assert.AreEqual(expectedDecimalValue, decimalValue);
        }

        [TestMethod]
        public void TestFromHexadecimalToDecimal2()
        {
            long decimalValue = Converter.ToDecimal("0f0e0d", 16);

            long expectedDecimalValue = 986637;

            Assert.AreEqual(expectedDecimalValue, decimalValue);
        }

        [TestMethod]
        public void TestFromHexadecimalToBinary1()
        {
            string binValue = Converter.FromHexadecimalToBinary("abcd");

            string expectedBinValue = "1010101111001101";

            Assert.AreEqual(expectedBinValue, binValue);
        }

        [TestMethod]
        public void TestFromHexadecimalToBinary2()
        {
            string binValue = Converter.FromHexadecimalToBinary("000ff9");

            string expectedBinValue = "111111111001";

            Assert.AreEqual(expectedBinValue, binValue);
        }

        [TestMethod]
        public void TestFromHexadecimalToBinary3()
        {
            string binValue = Converter.FromHexadecimalToBinary("1DB2");

            string expectedBinValue = "1110110110010";

            Assert.AreEqual(expectedBinValue, binValue);
        }

        [TestMethod]
        public void TestFromBinaryToHexadecimal1()
        {
            string hexValue = Converter.FromBinaryToHexadecimal("0000111101101");

            string expectedHexValue = "1ED";

            Assert.AreEqual(expectedHexValue, hexValue);
        }

        [TestMethod]
        public void TestFromBinaryToHexadecimal2()
        {
            string hexValue = Converter.FromBinaryToHexadecimal("11111111");

            string expectedHexValue = "FF";

            Assert.AreEqual(expectedHexValue, hexValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromBinaryToHexadecimal3()
        {
            string hexValue = Converter.FromBinaryToHexadecimal("0121");

            Assert.Fail();
        }

        [TestMethod]
        public void TestFromBinaryToOctal1()
        {
            string octValue = Converter.FromBinaryToOctal("11010110");

            string expectedOctValue = "326";

            Assert.AreEqual(expectedOctValue, octValue);
        }

        [TestMethod]
        public void TestFromBinaryToOctal2()
        {
            string octValue = Converter.FromBinaryToOctal("0100010001");

            string expectedOctValue = "421";

            Assert.AreEqual(expectedOctValue, octValue);
        }

        [TestMethod]
        public void TestFromOctalToBinary1()
        {
            string binValue = Converter.FromOctalToBinary("7144");

            string expectedBinValue = "111001100100";

            Assert.AreEqual(expectedBinValue, binValue);
        }

        [TestMethod]
        public void TestFromOctalToBinary2()
        {
            string binValue = Converter.FromOctalToBinary("00123");

            string expectedBinValue = "1010011";

            Assert.AreEqual(expectedBinValue, binValue);
        }

        [TestMethod]
        public void TestFromArbitraryBaseToAnother1()
        {
            string value = Converter.FromArbitraryBaseToAnother("11200", 5, 10);

            string expectedValue = "800";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromArbitraryBaseToAnother2()
        {
            string value = Converter.FromArbitraryBaseToAnother("10023", 4, 10);

            string expectedValue = "267";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromArbitraryBaseToAnother3()
        {
            string value = Converter.FromArbitraryBaseToAnother("1579", 10, 12);

            string expectedValue = "AB7";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromArbitraryBaseToAnother4()
        {
            string value = Converter.FromArbitraryBaseToAnother("57896", 10, 5);

            string expectedValue = "3323041";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromArbitraryBaseToAnother5()
        {
            string value = Converter.FromArbitraryBaseToAnother("443", 5, 16);

            string expectedValue = "7B";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromArbitraryBaseToAnother6()
        {
            string value = Converter.FromArbitraryBaseToAnother("310", 8, 7);

            string expectedValue = "404";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromDecimalToRoman1()
        {
            string value = Converter.FromDecimalToRoman(1999);

            string expectedValue = "MCMXCIX";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromDecimalToRoman2()
        {
            string value = Converter.FromDecimalToRoman(2013);

            string expectedValue = "MMXIII";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromDecimalToRoman3_ThrowsException()
        {
            string value = Converter.FromDecimalToRoman(0);

            Assert.Fail();
        }

        [TestMethod]
        public void TestFromDecimalToRoman4()
        {
            string value = Converter.FromDecimalToRoman(2366);

            string expectedValue = "MMCCCLXVI";

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromRomanToDecimal1()
        {
            uint value = Converter.FromRomanToDecimal("MCMXCIX");

            uint expectedValue = 1999;

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        public void TestFromRomanToDecimal2()
        {
            uint value = Converter.FromRomanToDecimal("MIX");

            uint expectedValue = 1009;

            Assert.AreEqual(expectedValue, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromRomanToDecimal3_ThrowsException()
        {
            uint value = Converter.FromRomanToDecimal("TRTXOP");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFromRomanToDecimal4_ThrowsException()
        {
            uint value = Converter.FromRomanToDecimal(" ");

            Assert.Fail();
        }

        [TestMethod]
        public void TestFromRomanToDecimal5()
        {
            uint value = Converter.FromRomanToDecimal("MMMCMLXXXVIII");

            uint expectedValue = 3988;

            Assert.AreEqual(expectedValue, value);
        }
    }
}
