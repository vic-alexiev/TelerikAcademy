using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableUnitTests
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHashTableConstructor_NegativeCapacity_ThrowsException()
        {
            HashTable<int, int> hashTable = new HashTable<int, int>(-10, 0.5f);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHashTableConstructor_LoadFactorLessThanMinLoadFactor_ThrowsException()
        {
            HashTable<int, int> hashTable = new HashTable<int, int>(16, 0.0f);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHashTableConstructor_LoadFactorGreaterThanMaxLoadFactor_ThrowsException()
        {
            HashTable<int, int> hashTable = new HashTable<int, int>(16, 2.0f);
        }

        [TestMethod]
        public void TestHashTableSetterAndGetter1()
        {
            HashTable<Point3D, int> hashTable = new HashTable<Point3D, int>(3, 0.9f);

            hashTable[new Point3D(1, 2, 3)] = 1;

            Assert.AreEqual(1, hashTable[new Point3D(1, 2, 3)]);
        }

        [TestMethod]
        public void TestHashTableSetterAndGetter2()
        {
            HashTable<Point3D, int> hashTable = new HashTable<Point3D, int>(3, 0.9f);

            hashTable[new Point3D(1, 2, 3)] = 1;
            hashTable[new Point3D(1, 2, 3)] += 1;

            Assert.AreEqual(2, hashTable[new Point3D(1, 2, 3)]);
        }

        [TestMethod]
        public void TestHashTable_CreateCollision()
        {
            HashTable<Point3D, int> hashTable = new HashTable<Point3D, int>(3, 0.9f);

            hashTable[new Point3D(1, 2, 3)] = 1;

            // this point will cause a collision with the
            // previous one and the elements will be chained
            hashTable[new Point3D(3, 2, 2)] = 42;

            Assert.AreEqual(42, hashTable[new Point3D(3, 2, 2)]);
            Assert.AreEqual(1, hashTable[new Point3D(1, 2, 3)]);
        }

        [TestMethod]
        public void TestHashTableResize()
        {
            HashTable<Point3D, int> hashTable = new HashTable<Point3D, int>(3, 0.9f);

            hashTable[new Point3D(1, 2, 3)] = 1;

            // this point will cause a collision with the
            // previous one and the elements will be chained
            hashTable[new Point3D(3, 2, 2)] = 42;

            hashTable[new Point3D(4, 5, 6)] = 1111;

            Assert.AreEqual(42, hashTable[new Point3D(3, 2, 2)]);
            Assert.AreEqual(1, hashTable[new Point3D(1, 2, 3)]);
            Assert.AreEqual(1111, hashTable[new Point3D(4, 5, 6)]);
        }

        [TestMethod]
        public void TestHashTableRemoveByKey()
        {
            HashTable<Point3D, int> hashTable = new HashTable<Point3D, int>(3, 0.9f);

            hashTable[new Point3D(1, 2, 3)] = 1;

            // this point will cause a collision with the
            // previous one and the elements will be chained
            hashTable[new Point3D(3, 2, 2)] = 42;

            hashTable[new Point3D(4, 5, 6)] = 1111;

            Assert.AreEqual(42, hashTable[new Point3D(3, 2, 2)]);
            Assert.AreEqual(1, hashTable[new Point3D(1, 2, 3)]);
            Assert.AreEqual(1111, hashTable[new Point3D(4, 5, 6)]);

            hashTable.Remove(new Point3D(3, 2, 2));

            Assert.IsFalse(hashTable.ContainsKey(new Point3D(3, 2, 2)));
        }

        [TestMethod]
        public void TestHashTableAdd()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 0);
            hashTable.Add("b", 0);
            hashTable.Add("t", 0);
            hashTable.Add("o", 0);
            hashTable.Add("z", 0);
            hashTable.Add("k", 0);
            hashTable.Add("g", 0);
            hashTable.Add("a5", 0);
            hashTable.Add("c", 0);
            hashTable.Add("a2", 0);
            hashTable.Add("a7", 0);
            hashTable.Add("i", 0);
            hashTable.Add("h", 0);

            Assert.AreEqual(13, hashTable.Count);
        }

        [TestMethod]
        public void TestHashTableContains()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 0);
            hashTable.Add("b", 0);
            hashTable.Add("t", 0);
            hashTable.Add("o", 0);
            hashTable.Add("z", 0);
            hashTable.Add("k", 0);
            hashTable.Add("g", 0);
            hashTable.Add("a5", 0);
            hashTable.Add("c", 0);
            hashTable.Add("a2", 0);
            hashTable.Add("a7", 0);
            hashTable.Add("i", 0);
            hashTable.Add("h", 0);

            Assert.IsTrue(hashTable.ContainsKey("m"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("m", 0)));
            Assert.IsTrue(hashTable.ContainsKey("b"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("b", 0)));
            Assert.IsTrue(hashTable.ContainsKey("t"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("t", 0)));
            Assert.IsTrue(hashTable.ContainsKey("o"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("o", 0)));
            Assert.IsTrue(hashTable.ContainsKey("z"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("z", 0)));
            Assert.IsTrue(hashTable.ContainsKey("k"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("k", 0)));
            Assert.IsTrue(hashTable.ContainsKey("g"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("g", 0)));
            Assert.IsTrue(hashTable.ContainsKey("a5"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("a5", 0)));
            Assert.IsTrue(hashTable.ContainsKey("c"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("a2", 0)));
            Assert.IsTrue(hashTable.ContainsKey("a7"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("a7", 0)));
            Assert.IsTrue(hashTable.ContainsKey("i"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("i", 0)));
            Assert.IsTrue(hashTable.ContainsKey("h"));
            Assert.IsTrue(hashTable.Contains(new KeyValuePair<string, int>("h", 0)));
        }

        [TestMethod]
        public void TestHashTableTryGetValue_KeyFound()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 101);
            hashTable.Add("b", 202);
            hashTable.Add("t", 303);

            int value = 0;
            bool success = false;

            success = hashTable.TryGetValue("m", out value);
            Assert.IsTrue(success);
            Assert.AreEqual(101, value);

            success = hashTable.TryGetValue("b", out value);
            Assert.IsTrue(success);
            Assert.AreEqual(202, value);

            success = hashTable.TryGetValue("t", out value);
            Assert.IsTrue(success);
            Assert.AreEqual(303, value);
        }

        [TestMethod]
        public void TestHashTableTryGetValue_KeyNotFound()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 101);
            hashTable.Add("b", 202);
            hashTable.Add("t", 303);

            int value = 0;
            bool success = hashTable.TryGetValue("tt", out value);
            Assert.IsFalse(success);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestHashTableTryGetValue_ThrowsException()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 101);
            hashTable.Add("b", 202);
            hashTable.Add("t", 303);

            string key = null;
            int value = 0;

            bool success = hashTable.TryGetValue(key, out value);
        }

        [TestMethod]
        public void TestHashTableRemove()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 10);
            hashTable.Add("b", 2000);
            hashTable.Add("t", 0);
            hashTable.Add("o", 33);
            hashTable.Add("z", 0);
            hashTable.Add("k", -812);
            hashTable.Add("g", 0);
            hashTable.Add("a5", 91);
            hashTable.Add("c", 0);
            hashTable.Add("a2", 22);
            hashTable.Add("a7", 66);
            hashTable.Add("i", 707);
            hashTable.Add("h", -15);

            int value = 0;

            bool success = hashTable.Remove(new KeyValuePair<string, int>("a5", 91));
            Assert.IsTrue(success);
            Assert.AreEqual(12, hashTable.Count);
            Assert.IsFalse(hashTable.ContainsKey("a5"));
            Assert.IsFalse(hashTable.Contains(new KeyValuePair<string, int>("a5", 91)));

            success = hashTable.TryGetValue("a5", out value);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void TestHashTableClear()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 10);
            hashTable.Add("b", 2000);
            hashTable.Add("t", 0);
            hashTable.Add("o", 33);
            hashTable.Add("z", 0);
            hashTable.Add("k", -812);
            hashTable.Add("g", 0);
            hashTable.Add("a5", 91);
            hashTable.Add("c", 0);
            hashTable.Add("a2", 22);
            hashTable.Add("a7", 66);
            hashTable.Add("i", 707);
            hashTable.Add("h", -15);

            hashTable.Clear();

            Assert.IsFalse(hashTable.ContainsKey("m"));
            Assert.IsFalse(hashTable.ContainsKey("b"));
            Assert.IsFalse(hashTable.ContainsKey("t"));
            Assert.IsFalse(hashTable.ContainsKey("o"));
            Assert.IsFalse(hashTable.ContainsKey("z"));
            Assert.IsFalse(hashTable.ContainsKey("k"));
            Assert.IsFalse(hashTable.ContainsKey("g"));
            Assert.IsFalse(hashTable.ContainsKey("a5"));
            Assert.IsFalse(hashTable.ContainsKey("c"));
            Assert.IsFalse(hashTable.ContainsKey("a2"));
            Assert.IsFalse(hashTable.ContainsKey("a7"));
            Assert.IsFalse(hashTable.ContainsKey("i"));
            Assert.IsFalse(hashTable.ContainsKey("h"));

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void TestHashTableCopyTo()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(3, 0.9f);

            hashTable.Add("m", 10);
            hashTable.Add("b", 2000);
            hashTable.Add("t", 0);
            hashTable.Add("o", 33);

            KeyValuePair<string, int>[] array = new KeyValuePair<string, int>[hashTable.Count];

            hashTable.CopyTo(array);

            KeyValuePair<string, int>[] expectedArray = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string, int>("t", 0),
                new KeyValuePair<string, int>("o", 33),
                new KeyValuePair<string, int>("m", 10),
                new KeyValuePair<string, int>("b", 2000)
            };

            CollectionAssert.AreEqual(expectedArray, array);
        }
    }
}
