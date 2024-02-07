using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.model;

[TestFixture]
public class RegisterDtoTest
{
    [Test]
    public void TestDefaultValues()
    {
        var registerDto = new RegisterDto();
        Assert.Multiple(() =>
        {
            Assert.That(registerDto.Username, Is.EqualTo(null));
            Assert.That(registerDto.Email, Is.EqualTo(null));
            Assert.That(registerDto.Password, Is.EqualTo(null));
        });
    }

    [Test]
    public void TestSetValues()
    {
        var registerDto = new RegisterDto
        {
            Username = "TestUser",
            Email = "",
            Password = "TestPassword"
        };
        Assert.Multiple(() =>
        {
            Assert.That(registerDto.Username, Is.EqualTo("TestUser"));
            Assert.That(registerDto.Email, Is.EqualTo(""));
            Assert.That(registerDto.Password, Is.EqualTo("TestPassword"));
        });
    }
}