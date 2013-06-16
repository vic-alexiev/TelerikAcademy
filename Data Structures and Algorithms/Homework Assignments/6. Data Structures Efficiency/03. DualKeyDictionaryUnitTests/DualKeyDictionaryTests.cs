using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03.DualKeyDictionaryUnitTests
{
    [TestClass]
    public class DualKeyDictionaryTests
    {
        [TestMethod]
        public void BasicTest()
        {
            DualKeyDictionary<int, string, string> dictionary = new DualKeyDictionary<int, string, string>();

            // Adding "Zero" to dictionary with primary int key of 0
            dictionary.Add(0, "Zero");
            Assert.AreEqual(1, dictionary.Count);

            // Associating binary sub-key of "0000" with primary int key of 0
            dictionary.Associate("0000", 0);

            // Adding "Three" to dictionary with primary int key of 3 and a binary sub-key of "0011"
            dictionary.Add(3, "0011", "Three");
            Assert.AreEqual(2, dictionary.Count);

            // Getting value for binary sub-key "0000"
            string value = dictionary["0000"]; // value will be "Zero"
            Assert.AreEqual("Zero", value);

            // Getting value for binary sub-key "0011"
            value = dictionary["0011"]; // value will be "Three"
            Assert.AreEqual("Three", value);

            // Getting value for int primary key 3
            value = dictionary[3]; // value will be "Three"
            Assert.AreEqual("Three", value);
        }
    }
}
