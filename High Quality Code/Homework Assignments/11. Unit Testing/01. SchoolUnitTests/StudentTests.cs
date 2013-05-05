// ********************************
// <copyright file="StudentTests.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace SchoolUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Used to test the <see cref="Student"/> class.
    /// </summary>
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor1_ThrowsException()
        {
            Student anonymous = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor2_ThrowsException()
        {
            Student anonymous = new Student("      ");
        }

        [TestMethod]
        public void TestStudentConstructor3()
        {
            Student kentBeck = new Student("Kent Beck");

            Assert.AreEqual("Kent Beck", kentBeck.Name, "Student's name is not set  correctly.");
        }

        [TestMethod]
        public void TestStudentConstructor4()
        {
            Student erichGamma = new Student("Erich Gamma");

            string message = string.Format(
                "Student's Id does not fall within the expected range from {0} to {1}.",
                Student.IdMinValue,
                Student.IdMaxValue);

            Assert.IsTrue(Student.IdMinValue <= erichGamma.Id && erichGamma.Id <= Student.IdMaxValue, message);
        }

        [TestMethod]
        public void TestStudentConstructor5()
        {
            Student kentBeck = new Student("Kent Beck");

            Student erichGamma = new Student("Erich Gamma");

            Assert.IsTrue(kentBeck.Id == (erichGamma.Id - 1), "Student Id's don't have consecutive values.");
        }

        [TestMethod]
        public void TestStudentToString1()
        {
            Student kentBeck = new Student("Kent Beck");

            Assert.AreEqual(
                string.Format("{{ Id = {0}, Name = Kent Beck }}", kentBeck.Id),
                kentBeck.ToString(),
                "Student.ToString() is not correct.");
        }
    }
}
