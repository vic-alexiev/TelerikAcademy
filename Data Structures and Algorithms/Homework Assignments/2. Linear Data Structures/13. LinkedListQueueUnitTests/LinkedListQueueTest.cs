using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedListQueueUnitTests
{
    [TestClass]
    public class LinkedListQueueTest
    {
        [TestMethod]
        public void TestLinkedListQueueDequeue()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(4, queue.Count);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestLinkedListQueueDequeue_ThrowsException()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
        }

        [TestMethod]
        public void TestLinkedListQueueEnqueue()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            // enqueue some items to test and check that the items are inserted correctly
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Count);
            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Count);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);
            queue.Enqueue(4);
            Assert.AreEqual(4, queue.Count);
            queue.Enqueue(5);
            Assert.AreEqual(5, queue.Count);
        }

        [TestMethod]
        public void TestLinkedListQueuePeek()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            // enqueue some items to test
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            // check that after peek we have the correct value but the item
            // is not deleted
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(5, queue.Count);
            queue.Dequeue();
            Assert.AreEqual(2, queue.Peek());
            Assert.AreEqual(4, queue.Count);
            queue.Dequeue();
            Assert.AreEqual(3, queue.Peek());
            Assert.AreEqual(3, queue.Count);
            queue.Dequeue();
            Assert.AreEqual(4, queue.Peek());
            Assert.AreEqual(2, queue.Count);
            queue.Dequeue();
            Assert.AreEqual(5, queue.Peek());
            Assert.AreEqual(1, queue.Count);
            queue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestLinkedListQueuePeek_ThrowsException()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            // enqueue some items to test
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            queue.Peek();
        }

        [TestMethod]
        public void TestLinkedListQueueClear()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Clear();

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestLinkedListQueueToString()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual("1, 2, 3, 4, 5", queue.ToString());
        }

        [TestMethod]
        public void TestLinkedListQueueContains()
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.IsTrue(queue.Contains(5));
        }
    }
}
