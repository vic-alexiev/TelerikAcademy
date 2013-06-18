using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmsUnitTests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSelectionSorterWhenCollectionIsNull_ThrowsException()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            TestsHelper.TestInt32SorterWhenCollectionIsNull(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestQuicksorterWhenCollectionIsNull_ThrowsException()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            TestsHelper.TestInt32SorterWhenCollectionIsNull(sorter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMergeSorterWhenCollectionIsNull_ThrowsException()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            TestsHelper.TestInt32SorterWhenCollectionIsNull(sorter);
        }

        [TestMethod]
        public void TestInt32SelectionSorter_RandomNumberOfItems()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            TestsHelper.TestInt32Sorter(sorter);
        }

        [TestMethod]
        public void TestInt32Quicksorter_RandomNumberOfItems()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            TestsHelper.TestInt32Sorter(sorter);
        }

        [TestMethod]
        public void TestInt32MergeSorter_RandomNumberOfItems()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            TestsHelper.TestInt32Sorter(sorter);
        }

        [TestMethod]
        public void TestStringSelectionSorter_RandomNumberOfItems()
        {
            ISorter<string> sorter = new SelectionSorter<string>();
            TestsHelper.TestStringSorter(sorter);
        }

        [TestMethod]
        public void TestStringQuicksorter_RandomNumberOfItems()
        {
            ISorter<string> sorter = new Quicksorter<string>();
            TestsHelper.TestStringSorter(sorter);
        }

        [TestMethod]
        public void TestStringMergeSorter_RandomNumberOfItems()
        {
            ISorter<string> sorter = new MergeSorter<string>();
            TestsHelper.TestStringSorter(sorter);
        }
    }
}
