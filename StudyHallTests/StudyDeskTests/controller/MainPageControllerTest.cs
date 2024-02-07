using Moq;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.controller;

[TestFixture]
public class MainPageControllerTest
{
    [Test]
    public void TestGetSources()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.GetSources())
            .ReturnsAsync(new List<Source>()); // Assuming successful login returns a new instance of AuthService

        var mainPageController = new MainPageController(mockAuthService.Object);

        var result = mainPageController.Sources;

        Assert.That(result, Is.Not.Null);
        mockAuthService.Verify(service => service.GetSources(), Times.Once);
    }
}