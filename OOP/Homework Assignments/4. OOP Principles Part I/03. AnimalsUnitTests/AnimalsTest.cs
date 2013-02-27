using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03.AnimalsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAnimalConstructor1()
        {
            Animal dog = new Dog("Rex", 5, true);

            Assert.AreEqual("Rex", dog.Name);
        }

        [TestMethod]
        public void TestAnimalConstructor2()
        {
            Animal frog = new Frog("Charlie", 15, true);

            Assert.AreEqual(15, frog.Age);
        }

        [TestMethod]
        public void TestAnimalConstructor3()
        {
            Animal dog = new Frog("Caesar", 3, true);

            Assert.AreEqual(true, dog.IsMale);
        }

        [TestMethod]
        public void TestAnimalConstructor4()
        {
            Animal pussycat = new Pussycat("Cleopatra", 5);

            Assert.AreEqual(false, pussycat.IsMale);
        }

        [TestMethod]
        public void TestAnimalConstructor5()
        {
            Animal tomcat = new Tomcat("Hoho", 8);

            Assert.AreEqual(true, tomcat.IsMale);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAnimalConstructor6_ThrowsException()
        {
            Animal tomcat = new Tomcat(null, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAnimalConstructor7_ThrowsException()
        {
            Frog frog = new Frog("Charlie", -12, true);
        }
    }
}
