using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHallTests.StudyWebTests.controller
{
    [TestFixture]
    public class AuthControllerTest
    {

        /*private SignInManager<IdentityUser> MockSignInManager()
        {
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var userManager = new UserManager<IdentityUser>(
                userStoreMock.Object,
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<IPasswordHasher<IdentityUser>>(),
                new IUserValidator<IdentityUser>[0],
                new IPasswordValidator<IdentityUser>[0],
                Mock.Of<ILookupNormalizer>(),
                Mock.Of<IdentityErrorDescriber>(),
                Mock.Of<IServiceProvider>(),
                Mock.Of<ILogger<UserManager<IdentityUser>>>()
            );

            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<IdentityUser>>();

            return new SignInManager<IdentityUser>(
                userManager,
                contextAccessor.Object,
                userPrincipalFactory.Object,
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<ILogger<SignInManager<IdentityUser>>>(),
                Mock.Of<IAuthenticationSchemeProvider>(),
                Mock.Of<IUserConfirmation<IdentityUser>>()
            );
        }*/

        /*[Test]
        public async Task LoginValidUser()
        {
            // Arrange
            var signInManager = MockSignInManager();
            signInManager.Setup(x => x.PasswordSignInAsync("validUser", "validPassword", false, false))
                .ReturnsAsync(SignInResult.Success);
            var controller = new AuthController(signInManager);
            var loginDto = new LoginDto { Username = "validUser", Password = "validPassword" };

            // Act
            var result = await controller.Login(loginDto);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult?.Value);
        }*/

        /*[Test]
        public async Task Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
        {
            // Arrange
            var signInManager = MockSignInManager();
            signInManager.Setup(x => x.PasswordSignInAsync("invalidUser", "invalidPassword", false, false))
                .ReturnsAsync(SignInResult.Failed);
            var controller = new AuthController(signInManager);
            var loginDto = new LoginDto { Username = "invalidUser", Password = "invalidPassword" };

            // Act
            var result = await controller.Login(loginDto);

            // Assert
            Assert.IsInstanceOf<UnauthorizedResult>(result);
        }*/

    }
}
