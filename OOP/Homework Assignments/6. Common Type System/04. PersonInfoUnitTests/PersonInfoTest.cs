using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonInfo;
using System;

namespace PersonInfoUnitTests
{
    [TestClass]
    public class PersonInfoTest
    {
        [TestMethod]
        public void TestPersonConstructor1()
        {
            Person richardStallman = new Person("Richard Stallman", new DateTime(1953, 3, 16));

            Assert.AreEqual("Richard Stallman", richardStallman.Name);
        }

        [TestMethod]
        public void TestPersonConstructor2()
        {
            Person carlLinnaeus = new Person("Carl Linnaeus");

            Assert.AreEqual(null, carlLinnaeus.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPersonConstructor3_ThrowsException()
        {
            Person anonymous = new Person(String.Empty, new DateTime(1993, 3, 16));
        }

        [TestMethod]
        public void TestPersonConstructor4()
        {
            Person ericSRaymond = new Person("Eric S. Raymond", null);

            Assert.AreEqual(false, ericSRaymond.Age.HasValue);
        }
    }
}
