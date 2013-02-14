using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodsTestProject
{
    [TestClass]
    public class TestFindMaximumElementInArray
    {
        [TestMethod]
        public void TestSelectSortAscending1()
        {
            int[] array = new int[] { 6, 3, 9, 2, 1, 0, 8, 15, -4, -3, 11, 4, 6 };
            FindMaximumElementInArray.SelectSortDescending(array);

            int[] expectedSortedArray = new int[] { 15, 11, 9, 8, 6, 6, 4, 3, 2, 1, 0, -3, -4 };

            CollectionAssert.AreEqual(expectedSortedArray, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSelectSortAscending2_ThrowsException()
        {
            FindMaximumElementInArray.SelectSortDescending((int[])null);

            Assert.Fail();
        }
    }
}
