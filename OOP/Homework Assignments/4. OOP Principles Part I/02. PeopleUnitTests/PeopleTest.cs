using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleUnitTests
{
    [TestClass]
    public class PeopleTest
    {
        [TestMethod]
        public void TestStudentConstructor1()
        {
            Student student = new Student("Yordan", "Yordanov", 89.12);

            Assert.AreEqual("Yordan", student.FirstName);
        }

        [TestMethod]
        public void TestStudentConstructor2()
        {
            Student student = new Student("Yordan", "Yordanov", 89.12);

            Assert.AreEqual("Yordanov", student.LastName);
        }

        [TestMethod]
        public void TestStudentConstructor3()
        {
            Student student = new Student("Yordan", "Yordanov", 89.12);

            Assert.AreEqual(89.12, student.Grade);
        }

        [TestMethod]
        public void TestStudentCompareToMethod()
        {
            Student student1 = new Student("Lina", "Ivanova", 78.93);
            Student student2 = new Student("Mihail", "Petrov", 19.75);


            Assert.AreEqual(1, student2.CompareTo(student1));
        }

        [TestMethod]
        public void TestWorkerConstructor1()
        {
            Worker worker = new Worker("Mihail", "Petrov", 275);

            Assert.AreEqual("Mihail", worker.FirstName);
        }

        [TestMethod]
        public void TestWorkerConstructor2()
        {
            Worker worker = new Worker("Mihail", "Petrov", 275);

            Assert.AreEqual("Petrov", worker.LastName);
        }

        [TestMethod]
        public void TestWorkerConstructor3()
        {
            Worker worker = new Worker("Mihail", "Petrov", 275);

            Assert.AreEqual(6.875, worker.MoneyPerHour);
        }

        [TestMethod]
        public void TestWorkerCompareToMethod()
        {
            Worker worker1 = new Worker("Lyubomir", "Yanchev", 350);
            Worker worker2 = new Worker("Nikolay", "Alexiev", 295);


            Assert.AreEqual(-1, worker1.CompareTo(worker2));
        }
    }
}
