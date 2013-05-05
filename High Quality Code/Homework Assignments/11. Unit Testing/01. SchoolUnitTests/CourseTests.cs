// ********************************
// <copyright file="CourseTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace SchoolUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="Course"/> class.
    /// </summary>
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void TestCourseConstructor1()
        {
            Course course = new Course("Operating Systems", "Andrew S. Tanenbaum");

            Assert.AreEqual("Operating Systems", course.Name, "Course name not set correctly.");
        }

        [TestMethod]
        public void TestCourseConstructor2()
        {
            Course course = new Course("Operating Systems", "Andrew S. Tanenbaum");

            Assert.AreEqual("Andrew S. Tanenbaum", course.ProfessorName, "Course professor not set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor3_ThrowsException()
        {
            Course course = new Course(null, "Andrew S. Tanenbaum");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor4_ThrowsException()
        {
            Course course = new Course(string.Empty, "Andrew S. Tanenbaum");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor5_ThrowsException()
        {
            Course course = new Course("     ", "Andrew S. Tanenbaum");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor6_ThrowsException()
        {
            Course course = new Course("C# Fundamentals", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor7_ThrowsException()
        {
            Course course = new Course("C# Fundamentals", string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor8_ThrowsException()
        {
            Course course = new Course("C# Fundamentals", "    ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddStudent1_ThrowsException()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");
            course.AddStudent(null);
        }

        [TestMethod]
        public void TestAddStudent2()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");
            Student martinFowler = new Student("Martin Fowler");
            course.AddStudent(martinFowler);

            Assert.AreEqual(1, course.Students.Count, "Couldn't add the student to the course.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddStudent3_ThrowsException()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");
            for (int i = 0; i < Course.MaxStudentsCount + 1; i++)
            {
                course.AddStudent(new Student("Martin Fowler"));
            }
        }

        [TestMethod]
        public void TestRemoveStudent1()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");
            Student kentBeck = new Student("Kent Beck");
            course.AddStudent(kentBeck);
            bool studentRemoved = course.RemoveStudent(kentBeck);

            Assert.AreEqual(true, studentRemoved, "Couldn't remove student.");
            Assert.AreEqual(0, course.Students.Count, "Couldn't remove student.");
        }

        [TestMethod]
        public void TestRemoveStudent2()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");
            Student kentBeck = new Student("Kent Beck");
            course.AddStudent(kentBeck);
            bool studentRemoved = course.RemoveStudent(new Student("Ward Cunningham"));

            Assert.AreEqual(false, studentRemoved, "Non-existent student removed.");
            Assert.AreEqual(1, course.Students.Count, "Non-existent student removed.");
        }

        [TestMethod]
        public void TestRemoveStudent3()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");
            Student kentBeck = new Student("Kent Beck");
            course.AddStudent(kentBeck);
            bool studentRemoved = course.RemoveStudent(null);

            Assert.AreEqual(false, studentRemoved, "Non-existent student removed.");
            Assert.AreEqual(1, course.Students.Count, "Non-existent student removed.");
        }

        [TestMethod]
        public void TestCourseToString1()
        {
            Course course = new Course("Design Patterns", "Erich Gamma");

            Student kentBeck = new Student("Kent Beck");
            Student andrewTanenbaum = new Student("Andrew S. Tanenbaum");

            course.AddStudent(kentBeck);
            course.AddStudent(andrewTanenbaum);

            Assert.AreEqual(
                string.Format(
                "Name = Design Patterns; Professor = Erich Gamma; Students = {{ {0}, {1} }}",
                kentBeck,
                andrewTanenbaum),
                course.ToString(),
                "Course.ToString() is not correct.");
        }

        [TestMethod]
        public void TestCourseToString2()
        {
            Course course = new Course("Extreme Programming", "Martin Fowler");

            Assert.AreEqual(
                "Name = Extreme Programming; Professor = Martin Fowler; Students = { }",
                course.ToString(),
                "Course.ToString() is not correct.");
        }
    }
}
