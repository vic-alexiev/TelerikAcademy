using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericStackUnitTests
{
    [TestClass]
    public class GenericStackTest
    {
        [TestMethod]
        public void TestGenericStackConstructor()
        {
            GenericStack<string> stack = new GenericStack<string>();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackPush()
        {
            GenericStack<string> stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual(4, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackPeek()
        {
            GenericStack<string> stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual("4. George", stack.Peek());
        }

        [TestMethod]
        public void TestGenericStackPop()
        {
            GenericStack<string> stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual("4. George", stack.Pop());
            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackToString()
        {
            GenericStack<string> stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");

            Assert.AreEqual(
                "4. George, 3. Mary, 2. Nicholas, 1. John",
                stack.ToString());
        }

        [TestMethod]
        public void TestGenericStackContains()
        {
            GenericStack<string> stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");
            stack.Push("5. Michael");

            Assert.IsTrue(stack.Contains("5. Michael"));
        }

        [TestMethod]
        public void TestGenericStackClear()
        {
            GenericStack<string> stack = new GenericStack<string>();
            stack.Push("1. John");
            stack.Push("2. Nicholas");
            stack.Push("3. Mary");
            stack.Push("4. George");
            stack.Push("5. Michael");

            Assert.AreEqual(5, stack.Count);

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestGenericStackPop_ReferenceType()
        {
            GenericStack<int[]> stack = new GenericStack<int[]>();
            stack.Push(new int[] { 1, 1, 1 });
            stack.Push(new int[] { 2, 2, 2 });
            stack.Push(new int[] { 3, 3, 3 });
            stack.Push(new int[] { 4, 4, 4 });
            stack.Push(new int[] { 5, 5, 5 });
            stack.Push(new int[] { 6, 6, 6 });


            Assert.AreEqual(6, stack.Count);

            CollectionAssert.AreEqual(new int[] { 6, 6, 6 }, stack.Pop());
        }
    }
}
