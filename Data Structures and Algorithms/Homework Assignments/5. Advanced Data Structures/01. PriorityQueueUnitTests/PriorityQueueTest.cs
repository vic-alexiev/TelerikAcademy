using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01.PriorityQueueUnitTests
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void TestPriorityQueue()
        {
            int operationsCount = 100000;

            Random rand = new Random(0);

            PriorityQueue<double> queue = new PriorityQueue<double>();

            for (int op = 0; op < operationsCount; ++op)
            {
                int opType = rand.Next(0, 2);

                if (opType == 0) // Enqueue
                {
                    double item = (100.0 - 1.0) * rand.NextDouble() + 1.0;
                    queue.Enqueue(item);

                    Assert.IsTrue(queue.IsConsistent(), "Test fails after enqueue operation # " + op);
                }
                else // Dequeue
                {
                    if (queue.Count > 0)
                    {
                        double item = queue.Dequeue();
                        Assert.IsTrue(queue.IsConsistent(), "Test fails after dequeue operation # " + op);
                    }
                }
            }
        }
    }
}
