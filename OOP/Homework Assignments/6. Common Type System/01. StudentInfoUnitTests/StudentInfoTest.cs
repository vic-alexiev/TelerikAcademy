using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentInfo;
using StudentInfo.Enums;
using System;

namespace StudentInfoUnitTests
{
    [TestClass]
    public class StudentInfoTest
    {
        [TestMethod]
        public void TestStudentConstructor1()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("Charles", charlie.FirstName);
        }

        [TestMethod]
        public void TestStudentConstructor2()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("James", charlie.MiddleName);
        }

        [TestMethod]
        public void TestStudentConstructor3()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("Stuart", charlie.LastName);
        }

        [TestMethod]
        public void TestStudentConstructor4()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("721-07-4426", charlie.Ssn);
        }

        [TestMethod]
        public void TestStudentConstructor5()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("151 South Almaden Boulevard, San Jose, California", charlie.PermanentAddress);
        }

        [TestMethod]
        public void TestStudentConstructor6()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("020 7290 7701", charlie.MobilePhone);
        }

        [TestMethod]
        public void TestStudentConstructor7()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual("charles.stuart@gmail.com", charlie.Email);
        }

        [TestMethod]
        public void TestStudentConstructor8()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual(3, charlie.Year);
        }

        [TestMethod]
        public void TestStudentConstructor9()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual(Speciality.Architecture, charlie.Speciality);
        }

        [TestMethod]
        public void TestStudentConstructor10()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual(University.MassachusettsInstituteOfTechnology, charlie.University);
        }

        [TestMethod]
        public void TestStudentConstructor11()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Assert.AreEqual(School.ArchitectureAndPlanning, charlie.School);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor12_ThrowsException()
        {
            Student charlie = new Student(
                "",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor13_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                null,
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor14_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor15_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                null,
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor16_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "           ",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor17_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                null,
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor18_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentConstructor19_ThrowsException()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                -9,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);
        }

        [TestMethod]
        public void TestStudentOperatorEquals()
        {
            Student charlie = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Student daniel = new Student(
                "Daniel",
                "Ray",
                "Coats",
                "144-04-9020",
                "8050 Microsoft Way, Charlotte, North Carolina",
                "031 7861 9238",
                "daniel.coats@gmail.com",
                4,
                Speciality.PoliticalScience,
                University.Harvard,
                School.HumanitiesArtsAndSocialSciences);

            Assert.AreEqual(false, charlie == daniel);
        }

        [TestMethod]
        public void TestStudentCloneMethod()
        {
            Student charlie1 = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Student charlie2 = charlie1.Clone();

            charlie2.Ssn = "144-04-9020";

            Assert.AreNotEqual("144-04-9020", charlie1.Ssn);
        }

        [TestMethod]
        public void TestStudentEqualsMethod1()
        {
            Student charlie1 = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Student charlie2 = new Student(
                "Charles",
                "James",
                "Stuart",
                "138-12-7345",
                "Apple Campus, 1 Infinite Loop, Cupertino, California, U.S.",
                "032 9871 6346",
                "charles.james.stuart@gmail.com",
                4,
                Speciality.OperationsResearch,
                University.UniversityOfChicago,
                School.Science);

            Assert.AreEqual(false, charlie1.Equals(charlie2));
        }

        [TestMethod]
        public void TestStudentEqualsMethod2()
        {
            Student charlie1 = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning);

            Student charlie2 = new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "Apple Campus, 1 Infinite Loop, Cupertino, California, U.S.",
                "032 9871 6346",
                "charles.james.stuart@gmail.com",
                4,
                Speciality.OperationsResearch,
                University.UniversityOfChicago,
                School.Science);

            Assert.AreEqual(true, charlie1.Equals(charlie2));
        }

        [TestMethod]
        public void TestStudentCompareToMethod()
        {
            Student[] students = new Student[]
            {
                new Student(
                    "Charles",
                    "James",
                    "Stuart",
                    "721-07-4426",
                    "151 South Almaden Boulevard, San Jose, California",
                    "020 7290 7701",
                    "charles.stuart@gmail.com",
                    3,
                    Speciality.Architecture,
                    University.MassachusettsInstituteOfTechnology,
                    School.ArchitectureAndPlanning),
                    
                new Student(
                    "Charles",
                    "James",
                    "Stuart",
                    "138-12-7345",
                    "Apple Campus, 1 Infinite Loop, Cupertino, California, U.S.",
                    "032 9871 6346",
                    "charles.james.stuart@gmail.com",
                    4,
                    Speciality.OperationsResearch,
                    University.UniversityOfChicago,
                    School.Science)
            };

            Array.Sort(students);

            Assert.AreEqual("138-12-7345", students[0].Ssn);
        }
    }
}
