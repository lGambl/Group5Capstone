using System.Net;
using Moq;
using Moq.Protected;
using StudyDesk.Controller;

namespace StudyHallTests.StudyDeskTests.controller;

[TestFixture]
public class UserRegistrationControllerTest
{
    private Mock<HttpMessageHandler>? handlerMock;

    [SetUp]
    public void Setup()
    {
        this.handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
    }

    [Test]
    public void RegisterUser_SuccessfulRegistration_ReturnsTrue()
    {
        var expectedUri = new Uri("https://localhost:7240/account/register");
        this.handlerMock!.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("..."),
            })
            .Verifiable();

        var client = new HttpClient(this.handlerMock!.Object)
        {
            BaseAddress = new Uri("https://localhost:7240/"),
        };

        var userRegistrationController = new UserRegistrationController(client);

        var result = userRegistrationController.CreateNewUser("username", "email", "pass").Result;

        Assert.That(result, Is.True);
        this.handlerMock!.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri == expectedUri), ItExpr.IsAny<CancellationToken>());
    }

    [Test]
    public void TestDefaultConstructor()
    {
        var userRegistrationController = new UserRegistrationController();
        Assert.That(userRegistrationController, Is.Not.Null);
        Assert.That(userRegistrationController, Is.InstanceOf<UserRegistrationController>());
    }
}