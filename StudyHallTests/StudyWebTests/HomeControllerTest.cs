using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyWeb.Controllers;
using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests;

[TestFixture]
public class HomeControllerTest
{
    [Test]
    public void TestIndex()
    {
        var controller = new HomeController();
        var result = controller.Index();
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public void TestPrivacy()
    {
        var controller = new HomeController();
        var result = controller.Privacy();
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public void Error_Returns_ErrorViewModel_With_RequestId()
    {
        // Arrange
        var controller = new HomeController
        {
            ControllerContext = new ControllerContext()
        };
        controller.ControllerContext.HttpContext = new DefaultHttpContext
        {
            TraceIdentifier = "TestTraceId"
        };

        // Act
        var result = controller.Error() as ViewResult;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.IsAssignableFrom<ErrorViewModel>(result!.ViewData.Model);
        var model = (ErrorViewModel)result.ViewData.Model!;
        Assert.That(model.RequestId, Is.EqualTo("TestTraceId"));
    }

}