using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Data;
using StudentsDb.Models;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace StudentsDb.Repositories.Tests
{
    [TestClass]
    public class StudentsRepositoryTests
    {
        private TransactionScope scope;
        private DbContext dbContext;
        private IRepository repository;
        private int schoolId;

        public StudentsRepositoryTests()
        {
            dbContext = new StudentsDbContext();
            repository = new StudentsDbRepository(dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            scope = new TransactionScope();

            var school = new School()
            {
                Name = "Sofia Maths High School",
                Location = "Sofia"
            };

            repository.Create(school);
            schoolId = school.Id;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            scope.Dispose();
        }

        [TestMethod]
        public void Add_WhenStudentDataIsValid_ShouldAddStudentToDatabase()
        {
            var newStudent = new Student()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = schoolId
            };

            this.repository.Create(newStudent);
            var studentFound = this.dbContext.Set<Student>().Find(newStudent.Id);

            Assert.IsNotNull(studentFound);
            Assert.AreEqual(newStudent.FirstName, studentFound.FirstName);
            Assert.AreEqual(newStudent.LastName, studentFound.LastName);
            Assert.AreEqual(newStudent.Age, studentFound.Age);
            Assert.AreEqual(newStudent.Grade, studentFound.Grade);
            Assert.AreEqual(newStudent.SchoolId, studentFound.SchoolId);
        }

        [TestMethod]
        public void All_WhenStudentDataIsValid()
        {
            var student1 = new Student()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = schoolId
            };

            var student2 = new Student()
            {
                FirstName = "Robert",
                LastName = "King",
                Age = 20,
                Grade = 1,
                SchoolId = schoolId
            };

            int oldStudentsCount = this.dbContext.Set<Student>().Count();

            this.repository.Create(student1);
            this.repository.Create(student2);

            var studentsFound = this.repository.All<Student>(new[] { "School", "Marks" });

            Assert.AreEqual(oldStudentsCount + 2, studentsFound.Count());
            Assert.IsTrue(studentsFound.Any(s => s.Id == student1.Id));
            Assert.IsTrue(studentsFound.Any(s => s.Id == student2.Id));
        }

        [TestMethod]
        public void Find_WhenStudentDataIsValid()
        {
            var newStudent = new Student()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = schoolId
            };

            this.repository.Create(newStudent);

            var studentFound = this.repository.Find<Student>(s => s.Id == newStudent.Id, new[] { "School", "Marks" });

            Assert.IsNotNull(studentFound);
            Assert.AreEqual(newStudent.FirstName, studentFound.FirstName);
            Assert.AreEqual(newStudent.LastName, studentFound.LastName);
            Assert.AreEqual(newStudent.Age, studentFound.Age);
            Assert.AreEqual(newStudent.Grade, studentFound.Grade);
            Assert.AreEqual(newStudent.SchoolId, studentFound.SchoolId);
        }

        [TestMethod]
        public void Filter_WhenStudentDataIsValid()
        {
            var newStudent = new Student()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = schoolId
            };

            this.repository.Create(newStudent);

            var studentsFound = this.repository.Filter<Student>(s => s.Id == newStudent.Id, new[] { "School", "Marks" });

            Assert.AreEqual(1, studentsFound.Count());
            Assert.AreEqual(newStudent.FirstName, studentsFound.First().FirstName);
            Assert.AreEqual(newStudent.LastName, studentsFound.First().LastName);
            Assert.AreEqual(newStudent.Age, studentsFound.First().Age);
            Assert.AreEqual(newStudent.Grade, studentsFound.First().Grade);
            Assert.AreEqual(newStudent.SchoolId, studentsFound.First().SchoolId);
        }
    }
}
