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
    public class BugsControllerTest
    {
        [TestMethod]
        public void IndexMethodShouldReturnProperNumberOfBugs()
        {
            var bugsList = DataHelper.GetBugData();

            var bugsRepoMock = new Mock<IRepository<Bug>>();
            bugsRepoMock.Setup(x => x.All()).Returns(bugsList.AsQueryable());

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepository<Bug>()).Returns(bugsRepoMock.Object);

            var controller = new BugsController(uowMock.Object);
            ViewResult viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "Index action returns null.");
            var model = viewResult.Model as IQueryable<BugViewModel>;
            Assert.IsNotNull(model, "The model is null.");
            Assert.AreEqual(3, model.Count());
        }

        [TestMethod]
        public void TestUpdateWhenModelStateIsValidAndBugIsNotNull()
        {
            var bugsRepoMock = new Mock<IRepository<Bug>>();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepository<Bug>()).Returns(bugsRepoMock.Object);

            var controller = new BugsController(uowMock.Object);

            var bug = new Bug();

            RedirectToRouteResult result = controller.Edit(bug) as RedirectToRouteResult;
            bugsRepoMock.Verify(x => x.Update(bug), Times.Once);
            uowMock.Verify(x => x.Save(), Times.Once);

            Assert.IsNotNull(result, "Index action returns null.");
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TestUpdateWhenBugIsNull()
        {
            var bugsRepoMock = new Mock<IRepository<Bug>>();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepository<Bug>()).Returns(bugsRepoMock.Object);

            var controller = new BugsController(uowMock.Object);

            Bug bug = null;

            var result = controller.Edit(bug) as ViewResult;
            bugsRepoMock.Verify(x => x.Update(bug), Times.Never());
            uowMock.Verify(x => x.Save(), Times.Never());

            Assert.IsNotNull(result, "Action returns null.");
        }
    }
}
