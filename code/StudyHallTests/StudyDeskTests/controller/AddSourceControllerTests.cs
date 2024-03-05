using Moq;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.controller;

[TestFixture]
public class AddSourceControllerTests
{

    [Test]
    public void AddSourceTestOk()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.AddSource("title", "filePath", SourceType.Pdf));
        
        
        var addSourceController = new AddSourceController(mockAuthService.Object);
        const string title = "title";
        const string filePath = "filePath";
        const SourceType sourceType = SourceType.Pdf;

        
        var result = addSourceController.AddSource(title, filePath, sourceType);

        
        Assert.That(result);
    }

    [Test]
    public void AddSourceThrowsException()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.AddSource("title", "filePath", SourceType.Pdf))
            .Throws<Exception>();

        var addSourceController = new AddSourceController(mockAuthService.Object);
        const string title = "title";
        const string filePath = "filePath";
        const SourceType sourceType = SourceType.Pdf;

        var result = addSourceController.AddSource(title, filePath, sourceType);

        Assert.That(!result);
    }
}