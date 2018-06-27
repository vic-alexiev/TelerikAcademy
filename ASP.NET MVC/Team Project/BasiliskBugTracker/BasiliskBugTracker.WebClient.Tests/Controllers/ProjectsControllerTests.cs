using BasiliskBugTracker.Models;
using BasiliskBugTracker.Repository;
using BasiliskBugTracker.WebClient.Areas.Administration.Models;
using BasiliskBugTracker.WebClient.Controllers;
using BasiliskBugTracker.WebClient.Models;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BasiliskBugTracker.WebClient.Tests.Controllers
{
    [TestClass]
    public class ProjectsControllerTests
    {
        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfProjects()
        {
            var projects = DataHelper.GetProjectData();

            var bugsRepoMock = new Mock<IRepository<Project>>();
            bugsRepoMock.Setup(x => x.All()).Returns(projects.AsQueryable());

            var uofMock = new Mock<IUnitOfWork>();
            uofMock.Setup(x => x.GetRepository<Project>()).Returns(bugsRepoMock.Object);

            var controller = new ProjectsController(uofMock.Object);
            ViewResult viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ProjectViewModelEx>;
            Assert.IsNotNull(model, "The model is null.");
            var modelList = model.ToList();
            Assert.AreEqual(7, modelList.Count(), "The projects aren't 7");
        }

        [TestMethod]
        public void IndexMethodShouldReturnExactlyProjectDetails()
        {
            var projects = DataHelper.GetProjectData();

            var bugsRepoMock = new Mock<IRepository<Project>>();
            bugsRepoMock.Setup(x => x.All()).Returns(projects.AsQueryable());

            var uofMock = new Mock<IUnitOfWork>();
            uofMock.Setup(x => x.GetRepository<Project>()).Returns(bugsRepoMock.Object);

            var controller = new ProjectsController(uofMock.Object);
            ViewResult viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IEnumerable<ProjectViewModelEx>;
            var modelList = model.ToList();
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(7, model.Count());
            Assert.AreEqual("Accounting System", modelList[0].Name);
            Assert.AreEqual(1, modelList[0].Id);
            Assert.AreEqual(1, modelList[0].BugsCount, "The bugs count isn't 1");
            Assert.AreEqual(1, modelList[0].Bugs.Count(), "The bugs are not 1");
            Assert.AreEqual("Login form does not open.", modelList[0].Bugs.First(), "The bug title is not as expected.");
            Assert.AreEqual("Nancy Davolio", modelList[0].Manager.Name, "The manager name is not as expected");
        }

        [TestMethod]
        public void Contributors_ReadShouldReturnTheSameContributors()
        {
            var projects = DataHelper.GetProjectData();

            var bugsRepoMock = new Mock<IRepository<Project>>();
            bugsRepoMock.Setup(x => x.GetById(1)).Returns(projects[0]);

            var uofMock = new Mock<IUnitOfWork>();
            uofMock.Setup(x => x.GetRepository<Project>()).Returns(bugsRepoMock.Object);

            var controller = new ProjectsController(uofMock.Object);

            JsonResult result = controller.Contributors_Read(new DataSourceRequest(), 1) as JsonResult;

            var resultData = result.Data as DataSourceResult;

            var projectContributors = (resultData.Data as IEnumerable<UserViewModel>).ToList();

            Assert.AreEqual(3, projectContributors.Count);
            Assert.AreEqual("nancy", projectContributors[0].UserName);
            Assert.AreEqual("Andrew Fuller", projectContributors[1].Name);
            Assert.AreEqual("2065553412", projectContributors[2].Phone);
            Assert.AreEqual("davolio@gmail.com", projectContributors[0].Email);
            Assert.IsFalse(projectContributors[1].IsDeleted);
            Assert.AreEqual(3, projectContributors[0].Roles.Count());
        }
    }
}
