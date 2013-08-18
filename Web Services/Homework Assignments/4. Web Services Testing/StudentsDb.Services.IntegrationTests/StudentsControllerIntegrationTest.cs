using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Models;
using StudentsDb.Repositories;
using StudentsDb.Services.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Telerik.JustMock;

namespace StudentsDb.Services.IntegrationTests
{
    [TestClass]
    public class StudentsControllerIntegrationTest
    {
        private StudentsController controller;
        private IRepository repository = Mock.Create<IRepository>();

        [TestInitialize]
        public void TestInit()
        {
            controller = new StudentsController(repository);
        }

        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var students = new List<Student>();
            students.Add(new Student()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = 1
            });

            Mock.Arrange(() => repository.All<Student>(new[] { "School", "Marks" }))
                .Returns(() => students.AsQueryable());

            var studentsFound = controller.Get();

            var server = new InMemoryHttpServer("http://localhost/");

            var response = server.Get("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
