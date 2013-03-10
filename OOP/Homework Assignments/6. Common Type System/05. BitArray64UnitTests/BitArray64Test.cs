using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitArray64UnitTests
{
    [TestClass]
    public class BitArray64Test
    {
        [TestMethod]
        public void TestBitArray64Constructor1()
        {
            BitArray64 bitArray = new BitArray64();

            Assert.AreEqual(0, bitArray[63]);
        }

        [TestMethod]
        public void TestBitArray64Constructor2()
        {
            BitArray64 bitArray = new BitArray64(8388608);

            Assert.AreEqual(1, bitArray[23]);
        }

        [TestMethod]
        public void TestBitArray64Indexer1()
        {
            BitArray64 bitArray = new BitArray64();

            bitArray[23] = 1;
            bitArray[24] = 1;
            bitArray[25] = 1;
            bitArray[49] = 1;

            Assert.AreEqual(562950012141568U, bitArray.BitsValue);
        }

        [TestMethod]
        public void TestBitArray64Indexer2()
        {
            BitArray64 bitArray = new BitArray64();

            bitArray[19] = 1;
            bitArray[49] = 1;
            bitArray[62] = 1;
            bitArray[63] = 1;

            Assert.AreEqual(
                "1100000000000010000000000000000000000000000010000000000000000000", bitArray.ToString());
        }
    }
}
