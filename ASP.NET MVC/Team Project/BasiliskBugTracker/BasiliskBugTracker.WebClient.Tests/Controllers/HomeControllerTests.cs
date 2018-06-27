using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using BasiliskBugTracker.Models;
using BasiliskBugTracker.Repository;
using BasiliskBugTracker.WebClient.Controllers;
using System.Linq;
using BasiliskBugTracker.WebClient.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BasiliskBugTracker.WebClient.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfProjects()
        {
            var list = new List<Project>();
            list.Add(new Project());
            list.Add(new Project());

            var bugsRepoMock = new Mock<IRepository<Project>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWork>();
            uofMock.Setup(x => x.GetRepository<Project>()).Returns(bugsRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            ViewResult viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ChartViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void IndexMethodShouldReturnExactlyProjects()
        {
            var list = new List<Project>();
            list.Add(new Project
            {
                Id = 0,
                IsDeleted = false,
                Name = "Test Project",
                Bugs = new List<Bug>()
                {
                    new Bug(),
                    new Bug()
                }
            });

            var bugsRepoMock = new Mock<IRepository<Project>>();
            bugsRepoMock.Setup(x => x.All()).Returns(list.AsQueryable());

            var uofMock = new Mock<IUnitOfWork>();
            uofMock.Setup(x => x.GetRepository<Project>()).Returns(bugsRepoMock.Object);

            var controller = new HomeController(uofMock.Object);
            ViewResult viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ChartViewModel>;
            var modelList = model.ToList();
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(1, model.Count());
            Assert.AreEqual("Test Project", modelList[0].Name);
            Assert.AreEqual(0, modelList[0].Id);
            Assert.AreEqual(1, modelList[0].Bugs.Count(), "The bugs group isn't 1.");
            Assert.AreEqual(2, modelList[0].Bugs.First().Count, "The bugs in group are not 2.");
            Assert.AreEqual("New", modelList[0].Bugs.First().category, "The bug category is not 'New'.");
        }
    }
}
