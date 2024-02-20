using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StudyWeb.Controllers;
using StudyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHallTests.StudyWebTests.controller
{
    [TestFixture]
    public class HomeControllerTest
    {

        private Mock<ILogger<HomeController>> mockLogger;

        [SetUp]
        public void SetUp()
        {
            mockLogger = new Mock<ILogger<HomeController>>();
        }

        [Test]
        public void TestIndex()
        {
            var controller = new HomeController(mockLogger.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));

        }

        [Test]
        public void TestPrivacy()
        {
            var controller = new HomeController(mockLogger.Object);
            var result = controller.Privacy();
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
        }

        [Test]
        public void TestError()
        {
            var controller = new HomeController(mockLogger.Object);
            var httpContext = new DefaultHttpContext();
            controller.ControllerContext = new ControllerContext() { HttpContext = httpContext };
            var result = controller.Error();
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf(typeof(ViewResult)));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult.Model);
            Assert.That(viewResult.Model, Is.InstanceOf(typeof(ErrorViewModel)));
            var viewModel = viewResult.Model as ErrorViewModel;
            Assert.IsFalse(string.IsNullOrEmpty(viewModel.RequestId));
        }

    }
}