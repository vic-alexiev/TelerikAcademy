using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchoolUnitTests
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestStudentConstructor1()
        {
            Student student = new Student("Lina", "Ivanova", 7);

            Assert.AreEqual("Lina", student.FirstName);
        }

        [TestMethod]
        public void TestStudentConstructor2()
        {
            Student student = new Student("Martin", "Yankov", 5);

            Assert.AreEqual("Yankov", student.LastName);
        }

        [TestMethod]
        public void TestStudentConstructor3()
        {
            Student student = new Student("Vladimir", "Georgiev", 6);

            Assert.AreEqual(6, student.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor4_ThrowsException()
        {
            Student student = new Student("", "Georgiev", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor5_ThrowsException()
        {
            Student student = new Student("Georgi", null, 10);
        }

        [TestMethod]
        public void TestCourseConstructor1()
        {
            Course course = new Course("C# Fundamentals Part I", 8, 8);

            Assert.AreEqual("C# Fundamentals Part I", course.Title);
        }

        [TestMethod]
        public void TestCourseConstructor2()
        {
            Course course = new Course("C# Fundamentals Part I", 8, 8);

            Assert.AreEqual(8, course.Lectures);
        }

        [TestMethod]
        public void TestCourseConstructor3()
        {
            Course course = new Course("C# Fundamentals Part I", 8, 12);

            Assert.AreEqual(12, course.Exercises);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor4_ThrowsException()
        {
            Course course = new Course(null, 8, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor5_ThrowsException()
        {
            Course course = new Course("HTML5", -1, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor6_ThrowsException()
        {
            Course course = new Course("HTML5", 20, -6);
        }

        [TestMethod]
        public void TestTeacherConstructor1()
        {
            Course[] courses = new Course[]
            {
                new Course("C# Fundamentals Part I", 10, 0),
                new Course("C# Fundamentals Part II", 5, 5),
                new Course("Object-Oriented Programming", 9, 9),
                new Course("ASP.NET MVC", 8, 8)
            };

            Teacher teacher = new Teacher("Nikolay", "Kostov", courses);

            Assert.AreEqual("ASP.NET MVC", teacher.Courses[3].Title);
        }

        [TestMethod]
        public void TestTeacherConstructor2()
        {
            Course[] courses = new Course[]
            {
                new Course("C# Fundamentals Part I", 10, 0),
                new Course("C# Fundamentals Part II", 15, 5),
                new Course("Object-Oriented Programming", 9, 19),
                new Course("ASP.NET MVC", 8, 8)
            };

            Teacher teacher = new Teacher("Nikolay", "Kostov", courses);

            Assert.AreEqual(9, teacher.Courses[2].Lectures);
        }

        [TestMethod]
        public void TestTeacherConstructor3()
        {
            Course[] courses = new Course[]
            {
                new Course("C# Fundamentals Part I", 10, 0),
                new Course("C# Fundamentals Part II", 15, 5),
                new Course("Object-Oriented Programming", 9, 19),
                new Course("ASP.NET MVC", 8, 8)
            };

            Teacher teacher = new Teacher("Nikolay", "Kostov", courses);

            Assert.AreEqual(5, teacher.Courses[1].Exercises);
        }

        [TestMethod]
        public void TestSchoolClassConstructor1()
        {
            Student[] students = new Student[]
            {
                new Student("Kiril", "Nikolov", 1),
                new Student("Stamo", "Petkov", 2)
            };

            Course[] courses = new Course[]
            {
                new Course("C# Fundamentals Part I", 10, 10),
                new Course("C# Fundamentals Part II", 18, 3),
                new Course("Object-Oriented Programming", 8, 1),
                new Course("Knowledge Sharing and Teamwork", 10, 0)
            };

            Teacher[] teachers = new Teacher[]
            {
                new Teacher("Svetlin", "Nakov", courses)
            };

            SchoolClass schoolClass = new SchoolClass("XIIc", students, teachers);

            Assert.AreEqual("Nakov", schoolClass.Teachers[0].LastName);
        }
    }
}
