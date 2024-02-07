using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.model;

[TestFixture]
public class LoginDtoTest
{
    [Test]
    public void TestDefaultValues()
    {
        var loginDto = new LoginDto();
        Assert.Multiple(() =>
        {
            Assert.That(loginDto.Username, Is.EqualTo(null));
            Assert.That(loginDto.Password, Is.EqualTo(null));
        });
    }

    [Test]
    public void TestSetValues()
    {
        var loginDto = new LoginDto
        {
            Username = "TestUser",
            Password = "TestPassword"
        };
        Assert.Multiple(() =>
        {
            Assert.That(loginDto.Username, Is.EqualTo("TestUser"));
            Assert.That(loginDto.Password, Is.EqualTo("TestPassword"));
        });
    }
}