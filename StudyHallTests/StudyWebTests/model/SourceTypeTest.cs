using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.model;

[TestFixture]
public class SourceTypeTest
{

    [Test]
    public void TestDefaultValues()
    {
        var sourceType = new SourceType();
        Assert.Multiple(() =>
        {
            Assert.That(sourceType.Id, Is.EqualTo(0));
            Assert.That(sourceType.Name, Is.EqualTo(""));
        });
    }

    [Test]
    public void TestSetValues()
    {
        var sourceType = new SourceType
        {
            Id = 1,
            Name = "Video"
        };
        Assert.Multiple(() =>
        {
            Assert.That(sourceType.Id, Is.EqualTo(1));
            Assert.That(sourceType.Name, Is.EqualTo("Video"));
        });
    }
}