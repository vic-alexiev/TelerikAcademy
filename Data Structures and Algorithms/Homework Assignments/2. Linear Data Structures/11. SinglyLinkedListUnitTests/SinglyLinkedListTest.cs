using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace SinglyLinkedListUnitTests
{
    [TestClass]
    public class SinglyLinkedListTest
    {
        [TestMethod]
        public void TestSinglyLinkedListConstructor()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestSinglyLinkedListAdd()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestSinglyLinkedListIndexer()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";

            string[] array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListRemoveAt()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.RemoveAt(1);

            string[] array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListForEach()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";

            string[] array = new string[list.Count];
            int index = 0;

            foreach (string item in list)
            {
                array[index] = item;
                index++;
            }

            Assert.AreEqual("Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListInsert_InsertInTheMiddle()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.Insert(1, "Ten");

            string[] array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Ten, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListInsert_InsertAtTheEnd()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.Insert(3, "Ten");

            string[] array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two, Three, Ten", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListInsert_InsertAtTheBeginning()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.Insert(0, "Ten");

            string[] array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Ten, Zero, Two, Three", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListRemove()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.Remove("Three");

            string[] array = new string[list.Count];
            list.CopyTo(array);
            Assert.AreEqual("Zero, Two", string.Join(", ", array));
        }

        [TestMethod]
        public void TestSinglyLinkedListIndexOf()
        {
            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list[0] = "Zero";
            list.Insert(2, "Four");

            Assert.AreEqual(3, list.IndexOf("Three"));
        }
    }
}
