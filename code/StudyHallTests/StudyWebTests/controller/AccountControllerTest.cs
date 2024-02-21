using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using StudyWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.controller
{
    [TestFixture]
    public class AccountControllerTest
    {

        private Mock<UserManager<IdentityUser>> createMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var optionsMock = new Mock<IOptions<IdentityOptions>>();
            var passwordHasherMock = new Mock<IPasswordHasher<IdentityUser>>();
            var userValidatorMock = new Mock<IUserValidator<IdentityUser>>();
            var passwordValidatorMock = new Mock<IPasswordValidator<IdentityUser>>();
            var lookupNormalizerMock = new Mock<ILookupNormalizer>();
            var identityErrorDescriberMock = new Mock<IdentityErrorDescriber>();
            var serviceProviderMock = new Mock<IServiceProvider>();
            var loggerMock = new Mock<ILogger<UserManager<IdentityUser>>>();

            var userManagerMock = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object,
                optionsMock.Object,
                passwordHasherMock.Object,
                new IUserValidator<IdentityUser>[] { userValidatorMock.Object },
                new IPasswordValidator<IdentityUser>[] { passwordValidatorMock.Object },
                lookupNormalizerMock.Object,
                identityErrorDescriberMock.Object,
                serviceProviderMock.Object,
                loggerMock.Object
            );

            return userManagerMock;
        }

        [Test]
        public async Task RegisterNewValidUser()
        {
            var userManagerMock = this.createMockUserManager();
            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            var model = new RegisterDto { Password = "Password5%", Username = "new@email.com" };
            var controller = new AccountController(userManagerMock.Object);
            var result = await controller.Register(model);
            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public async Task RegisterNewInvalidUser()
        {
            var userManagerMock = this.createMockUserManager();
            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError()));
            var model = new RegisterDto { Password = "pw", Username = "new" };
            var controller = new AccountController(userManagerMock.Object);
            var result = await controller.Register(model);
            Assert.That(result, Is.InstanceOf(typeof(BadRequestObjectResult)));
        }

    }
}
