using Moq;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.controller;

[TestFixture]
public class LoginControllerTest
{
    [Test]
    public void VerifyLoginCredentials_SuccessfulLogin_ReturnsAuthService()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new AuthService()); // Assuming successful login returns a new instance of AuthService

        var loginController = new LoginController(mockAuthService.Object);

        var result = loginController.VerifyLoginCredentials("validUser", "validPassword");

        Assert.That(result, Is.Not.Null);
        mockAuthService.Verify(service => service.LoginAsync("validUser", "validPassword"), Times.Once);
    }

    [Test]
    public void VerifyLoginCredentials_UnsuccessfulLogin_ReturnsNull()
    {
        var mockAuthService = new Mock<AuthService>();
        mockAuthService.Setup(service => service.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync((AuthService)null!); // Assuming unsuccessful login returns null

        var loginController = new LoginController(mockAuthService.Object);

        var result = loginController.VerifyLoginCredentials("invalidUser", "invalidPassword");

        Assert.That(result, Is.Null);
        mockAuthService.Verify(service => service.LoginAsync("invalidUser", "invalidPassword"), Times.Once);
    }

}