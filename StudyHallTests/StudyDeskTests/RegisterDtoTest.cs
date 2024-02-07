using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests;

[TestFixture]
public class RegisterDtoTest
{
    [Test]
    public void TestDefaultConstruction()
    {
        var dto = new RegisterDto();

        Assert.Multiple(() =>
        {
            Assert.That(dto.Email, Is.EqualTo(null));
            Assert.That(dto.Username, Is.EqualTo(null));
            Assert.That(dto.Password, Is.EqualTo(null));
        });
    }

    [Test]
    public void TestConstructionWithValues()
    {
        var dto = new RegisterDto();
        dto.Username = "username";
        dto.Email = "email@email.com";
        dto.Password = "password";

        Assert.Multiple(() =>
        {
            Assert.That(dto.Email, Is.EqualTo("email@email.com"));
            Assert.That(dto.Username, Is.EqualTo("username"));
            Assert.That(dto.Password, Is.EqualTo("password"));
        });
    }

}

