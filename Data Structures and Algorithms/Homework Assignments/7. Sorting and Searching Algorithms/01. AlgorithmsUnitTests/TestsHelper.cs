using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmsUnitTests
{
    public static class TestsHelper
    {
        private static readonly Random randomProvider = new Random();

        public static void TestInt32SorterWhenCollectionIsNull(ISorter<int> sorter)
        {
            int[] numbers = null;
            sorter.Sort(numbers);
        }

        public static void TestInt32Sorter(ISorter<int> sorter)
        {
            int[] array = new int[randomProvider.Next(2, 1000)];
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = randomProvider.Next(1000);
            }

            sorter.Sort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsTrue(array[i] <= array[i + 1]);
            }
        }

        public static void TestStringSorter(ISorter<string> sorter)
        {
            string[] array = new string[] { "foo", "fOo2", "Fuzzle", "FOb", "zander", "Alphabet", "QuiRk", "foo", "fiddle", "fast", "finagle", "g1", "gross", "g3", "gimpy", "horse", "hippo", "igloo", "rascal", "splurge" };

            sorter.Sort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0);
            }
        }
    }
}
