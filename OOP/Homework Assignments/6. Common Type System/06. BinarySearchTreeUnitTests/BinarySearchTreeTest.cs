using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTreeUnitTests
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void TestBinarySearchTreeConstructor()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(1, 9, 7);

            Assert.AreEqual(false, tree.Equals(null));
        }

        [TestMethod]
        public void TestBinarySearchTreeToString()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(1, 9, 7);

            Assert.AreEqual("1, 7, 9", tree.ToString());
        }

        [TestMethod]
        public void TestBinarySearchTreeAsStringAscending()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(34, 6, -9, 12);

            Assert.AreEqual("-9, 6, 12, 34", tree.AsString(true));
        }

        [TestMethod]
        public void TestBinarySearchTreeAsStringDescending()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(34, 6, -9, 12);

            Assert.AreEqual("34, 12, 6, -9", tree.AsString(false));
        }

        [TestMethod]
        public void TestBinarySearchTreeEquals1()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(1, 9, 7);

            BinarySearchTree<int> tree2 = new BinarySearchTree<int>();
            tree2.Add(1);
            tree2.Add(9);
            tree2.Add(7);

            Assert.AreEqual(true, tree1.Equals(tree2));
        }

        [TestMethod]
        public void TestBinarySearchTreeEquals2()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(1, 9, 7);

            BinarySearchTree<int> tree2 = new BinarySearchTree<int>();
            tree2.Add(7);
            tree2.Add(5);
            tree2.Add(9);

            Assert.AreEqual(false, tree1.Equals(tree2));
        }

        [TestMethod]
        public void TestBinarySearchTreeEquals3()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(1, 9, 7);

            BinarySearchTree<int> tree2 = tree1;

            Assert.AreEqual(true, tree1.Equals(tree2));
        }

        [TestMethod]
        public void TestBinarySearchTreeOperatorEquals()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(1, 9, 7);

            BinarySearchTree<int> tree2 = tree1;

            Assert.AreEqual(true, tree1 == tree2);
        }

        [TestMethod]
        public void TestBinarySearchTreeCount1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void TestBinarySearchTreeCount2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(12, 4, 8, 6, 10, 2);

            Assert.AreEqual(6, tree.Count);
        }

        [TestMethod]
        public void TestBinarySearchTreeClone1()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(12, 4, 8, 6, 10, 2);

            BinarySearchTree<int> tree2 = tree1.Clone();

            tree1.Remove(12);

            Assert.AreEqual(true, tree2.Contains(12));
        }

        [TestMethod]
        public void TestBinarySearchTreeClone2()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(12, 4, 8, 6, 10, 2);

            BinarySearchTree<int> tree2 = tree1.Clone();

            tree2.Add(1);

            Assert.AreEqual(false, tree1.Contains(1));
        }

        [TestMethod]
        public void TestBinarySearchTreeClone3()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(12, 4, 8, 6, 10, 2);

            BinarySearchTree<int> tree2 = tree1.Clone();

            Assert.AreEqual(true, tree1.Equals(tree2));
        }

        [TestMethod]
        public void TestBinarySearchTreeClone4()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(12, 4, 8, 6, 10, 2);

            BinarySearchTree<int> tree2 = tree1.Clone();

            Assert.AreEqual(true, tree1 == tree2);
        }

        [TestMethod]
        public void TestBinarySearchTreeGetHashCode()
        {
            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(5, 7, 9);

            BinarySearchTree<int> tree2 = new BinarySearchTree<int>();
            tree2.Add(7);
            tree2.Add(5);
            tree2.Add(9);

            Assert.AreEqual(true, tree1.GetHashCode() != tree2.GetHashCode());
        }
    }
}
