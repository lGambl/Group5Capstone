using Microsoft.EntityFrameworkCore;
using StudyWeb.Data;

namespace StudyHallTests.StudyWebTests.data;

[TestFixture]
public class ApplicationDbContextTest
{
    [Test]
    public void TestApplicationDbContext()
    {
        var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        Assert.Multiple(() =>
        {
            Assert.That(context, Is.Not.Null);
            Assert.That(context.Source, Is.Not.Null);
            Assert.That(context.Note, Is.Not.Null);
            Assert.That(context.SourceType, Is.Not.Null);
        });
    }
}