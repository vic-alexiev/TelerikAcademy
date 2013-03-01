using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericListUnitTests
{
    [TestClass]
    public class GenericListTest
    {
        [TestMethod]
        public void TestAdd1()
        {
            GenericList<double> numbers = new GenericList<double>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            Assert.AreEqual(2, numbers[1]);
        }

        [TestMethod]
        public void TestAdd2()
        {
            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            Assert.AreEqual(5, numbers[4]);
        }

        [TestMethod]
        public void TestRemove1()
        {
            GenericList<short> numbers = new GenericList<short>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            numbers.RemoveAt(3);

            Assert.AreEqual(5, numbers[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemove2_ThrowsException()
        {
            GenericList<long> numbers = new GenericList<long>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            numbers.RemoveAt(-4);
        }

        [TestMethod]
        public void TestInsert1()
        {
            GenericList<double> numbers = new GenericList<double>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            numbers.Insert(0, 20);

            Assert.AreEqual(20, numbers[0]);
        }

        [TestMethod]
        public void TestInsert2()
        {
            GenericList<uint> numbers = new GenericList<uint>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            numbers.Insert(5, 100);

            Assert.AreEqual(100U, numbers[5]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInsert3_ThrowsException()
        {
            GenericList<ulong> numbers = new GenericList<ulong>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            numbers.Insert(6, 10);
        }

        [TestMethod]
        public void TestFindIndex()
        {
            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);

            int value = 5;
            int pos = numbers.FindIndex(n => n == value);

            Assert.AreEqual(4, pos);
        }

        [TestMethod]
        public void TestMin1()
        {
            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(4);

            int min = numbers.Min();

            Assert.AreEqual(1, min);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMin2_ThrowsException()
        {
            GenericList<int> numbers = new GenericList<int>();

            int min = numbers.Min();
        }

        [TestMethod]
        public void TestGetMin()
        {
            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(4);

            int min = numbers.GetMin();

            Assert.AreEqual(1, min);
        }

        [TestMethod]
        public void TestMax()
        {
            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(4);

            int max = numbers.Max();

            Assert.AreEqual(5, max);
        }

        [TestMethod]
        public void TestGetMax()
        {
            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(4);

            int max = numbers.GetMax();

            Assert.AreEqual(5, max);
        }
    }
}
