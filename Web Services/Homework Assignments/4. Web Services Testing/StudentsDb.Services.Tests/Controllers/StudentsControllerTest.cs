using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Models;
using StudentsDb.Repositories;
using StudentsDb.Services.Controllers;
using StudentsDb.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Telerik.JustMock;

namespace StudentsDb.Services.Tests.Controllers
{
    [TestClass]
    public class StudentsControllerTest
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void Add_WhenStudentIsValid_ShouldAddTheStudent()
        {
            var studentDto = new StudentDto()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = 1
            };

            var student = new Student()
            {
                Id = 1,
                FirstName = studentDto.FirstName,
                LastName = studentDto.FirstName,
                Age = studentDto.Age,
                Grade = studentDto.Grade,
            };

            bool isStudentAdded = false;
            var repository = Mock.Create<IRepository>();

            Mock.Arrange(() => repository.Create(Arg.IsAny<Student>()))
                .DoInstead(() => isStudentAdded = true)
                .Returns(student);

            var controller = new StudentsController(repository);
            SetupController(controller);

            HttpResponseMessage response = controller.Post(studentDto);

            Assert.IsTrue(isStudentAdded);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllStudents()
        {
            var student = new Student()
            {
                Id = 1,
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = 1
            };

            IList<Student> students = new List<Student>();
            students.Add(student);

            var repository = Mock.Create<IRepository>();

            Mock.Arrange(() => repository.All<Student>(new[] { "School", "Marks" })).Returns(() => students.AsQueryable());

            var controller = new StudentsController(repository);

            var studentsFound = controller.Get();
            Assert.IsTrue(studentsFound.Count() == 1);
            Assert.AreEqual(student.FirstName, studentsFound.First().FirstName);
        }

        [TestMethod]
        public void GetById_ShouldReturnSingleStudent()
        {
            var student = new Student()
            {
                Id = 1,
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = 1
            };

            var repository = Mock.Create<IRepository>();

            Mock.Arrange(() => repository.Find<Student>(
                Arg.IsAny<Expression<Func<Student, bool>>>(),
                new[] { "School", "Marks" }))
                .Returns(student);

            var controller = new StudentsController(repository);

            var studentFound = controller.Get(student.Id);
            Assert.AreEqual(student.Id, studentFound.Id);
            Assert.AreEqual(student.FirstName, studentFound.FirstName);
            Assert.AreEqual(student.LastName, studentFound.LastName);
            Assert.AreEqual(student.Age, studentFound.Age);
            Assert.AreEqual(student.Grade, studentFound.Grade);
            Assert.AreEqual(student.SchoolId, studentFound.SchoolId);
        }

        [TestMethod]
        public void Filter_ShouldReturnAllStudentsMatchingThePredicate()
        {
            var student = new Student()
            {
                Id = 1,
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = 1
            };

            IList<Student> students = new List<Student>();
            students.Add(student);

            var repository = Mock.Create<IRepository>();

            Mock.Arrange(() => repository.Filter<Student>(
                Arg.IsAny<Expression<Func<Student, bool>>>(),
                new[] { "School", "Marks" }))
                .Returns(() => students.AsQueryable());

            var controller = new StudentsController(repository);

            var studentsFound = controller.Get("Maths", 6.0f);
            Assert.IsTrue(studentsFound.Count() == 1);
            Assert.AreEqual(student.FirstName, studentsFound.First().FirstName);
        }
    }
}
