using Moq;
using StudyDesk.Controller;
using StudyDesk.Model;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace StudyHallTests.StudyDeskTests.controller;

[TestFixture]
public class MainPageControllerTest
{
    [Test]
    public void TestGetSources()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.GetSources())
            .ReturnsAsync(new List<Source>());

        var mainPageController = new MainPageController(mockAuthService.Object);
        var result = mainPageController.Sources;
        Assert.That(result, Is.Not.Null);
        mockAuthService.Verify(service => service.GetSources(), Times.Once);
    }

    [Test]
    public void TestLogout()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.Logout())
            .Returns(true);

        var mainPageController = new MainPageController(mockAuthService.Object);
        var result = mainPageController.Logout();
        Assert.That(result, Is.True);
        mockAuthService.Verify(service => service.Logout(), Times.Once);
    }

    [Test]
    public async Task DeleteSource_SuccessfulDeletion_ReturnsTrue()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.DeleteSource(It.IsAny<int>()))
            .Returns(true);
        var controller = new MainPageController(mockAuthService.Object);
        controller.Sources.Add(new Source (400, "link", "{TestSource}", SourceType.PdfLink, "owner"));
        var result = await controller.DeleteSource("{TestSource}");
        Assert.IsTrue(result);
    }

    [Test]
    public async Task DeleteSource_SourceNotFound_ReturnsFalse()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.DeleteSource(It.IsAny<int>()))
            .Returns(false);
        var controller = new MainPageController(mockAuthService.Object);
        var result = await controller.DeleteSource("{NonExistentSource}");
        Assert.IsFalse(result);
    }

    /*[Test]
    public async Task DeleteSource_HttpRequestFails_ReturnsFalse()
    {
        var mockAuthService = new Mock<AuthService>();
        var mockHttpClient = new Mock<HttpClient>();
        var controller = new MainPageController(mockAuthService.Object, mockHttpClient.Object);

        controller.Sources.Add(new Source(450, "link", "{TestSource}", SourceType.PdfLink, "owner"));

        var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        mockHttpClient.Setup(c => c.DeleteAsync(It.IsAny<string>())).ReturnsAsync(httpResponse);
        var result = await controller.DeleteSource("{TestSource}");
        Assert.IsFalse(result);
    }*/

    [Test]
    public async Task GetSourcesWithMatchingNoteTags_ReturnsSourcesWithModifiedLinks()
    {
        var tags = new List<string> { "tag1", "tag2" };
        var expectedSources = new List<Source>
        {
            new Source(1, "originalLink1", "Source 1", SourceType.Pdf, "Owner 1"),
            new Source(2, "originalLink2", "Source 2", SourceType.Video, "Owner 2")
        };

        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.GetSourcesWithMatchingTags(It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(expectedSources);

        var mainPageController = new MainPageController(mockAuthService.Object);
        var result = await mainPageController.GetSourcesWithMatchingNoteTags(tags);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedSources.Count, result.Count);
        for (int i = 0; i < expectedSources.Count; i++)
        {
            string expectedLink = expectedSources[i].Link;
            Assert.AreEqual(expectedLink, result[i].Link);
        }
        mockAuthService.Verify(service => service.GetSourcesWithMatchingTags(It.IsAny<IEnumerable<string>>()), Times.Once);
    }

    [Test]
    public async Task GetSourcesWithMatchingNoteTags_NoMatchingSources_ReturnsNull()
    {
        var tags = new List<string> { "tag1", "tag2" };

        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.GetSourcesWithMatchingTags(It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(new List<Source>());

        var mainPageController = new MainPageController(mockAuthService.Object);
        var result = await mainPageController.GetSourcesWithMatchingNoteTags(tags);

        Assert.IsNull(result);
        mockAuthService.Verify(service => service.GetSourcesWithMatchingTags(It.IsAny<IEnumerable<string>>()), Times.Once);
    }

    [Test]
    public void ResetUserSources_SetsSourcesToUserSources()
    {
        var mockAuthService = new Mock<AuthService>();
        var mainPageController = new MainPageController(mockAuthService.Object);

        var initialSources = new List<Source>
        {
            new Source(1, "link1", "Source 1", SourceType.Image, "owner1"),
        };
        var userSources = new List<Source>
        {
            new Source(2, "link2", "Source 2", SourceType.Video, "owner2"),
            new Source(3, "link3", "Source 3", SourceType.Pdf, "owner3")
        };

        mainPageController.Sources = initialSources;

        mainPageController.GetType().GetProperty("userSources")?.SetValue(mainPageController, userSources);

        mainPageController.ResetUserSources();

        Assert.AreEqual(userSources, mainPageController.Sources);
    }
}