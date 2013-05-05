// ********************************
// <copyright file="SchoolTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace SchoolUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="School"/> class.
    /// </summary>
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolConstructor1_ThrowsException()
        {
            School school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolConstructor2_ThrowsException()
        {
            School school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSchoolConstructor3_ThrowsException()
        {
            School school = new School("   ");
        }

        [TestMethod]
        public void TestSchoolConstructor4()
        {
            School school = new School("School of Engineering");

            Assert.AreEqual("School of Engineering", school.Name, "School name not set correctly.");
        }

        [TestMethod]
        public void TestAddCourse1()
        {
            School school = new School("School of Engineering");
            Course course = new Course("JavaScript Fundamentals", "John Resig");

            school.AddCourse(course);
            Assert.AreEqual(1, school.Courses.Count, "Couldn't add the course.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddCourse2_ThrowsException()
        {
            School school = new School("School of Engineering");
            school.AddCourse(null);
        }

        [TestMethod]
        public void TestRemoveCourse1()
        {
            School school = new School("School of Engineering");
            Course course = new Course("JavaScript Fundamentals", "John Resig");

            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.Courses.Count, "Couldn't remove the course.");
        }
    }
}
