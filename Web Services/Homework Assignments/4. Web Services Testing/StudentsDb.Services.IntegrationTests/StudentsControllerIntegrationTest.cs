using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsDb.Models;
using StudentsDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Telerik.JustMock;

namespace StudentsDb.Services.IntegrationTests
{
    [TestClass]
    public class StudentsControllerIntegrationTest
    {
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

            var repository = Mock.Create<IRepository>();

            Mock.Arrange(() => repository.All<Student>(new[] { "School", "Marks" }))
                .Returns(() => students.AsQueryable());

            var server = new InMemoryHttpServer("http://localhost/", repository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostStudent_WhenNameIsNull_ShouldReturnStatusCode400()
        {
            var repository = Mock.Create<IRepository>();

            Mock.Arrange(() => repository
                .Create(Arg.Matches<Student>(s => s.FirstName == null)))
                .Throws<Exception>();


            var server = new InMemoryHttpServer("http://localhost/", repository);

            var response = server.CreatePostRequest("api/students",
                new Student()
                {
                    FirstName = null
                });

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
