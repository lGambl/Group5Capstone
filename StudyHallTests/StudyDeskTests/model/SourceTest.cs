using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests.model;

[TestFixture]
public class SourceTest
{
    [Test]
    public void TestSourceConstructor()
    {
        var deskSource = new Source(1, "test", "test", SourceType.Pdf, "test");
        Assert.Multiple(() =>
        {
            Assert.That(deskSource.Id, Is.EqualTo(1));
            Assert.That(deskSource.Title, Is.EqualTo("test"));
            Assert.That(deskSource.Owner, Is.EqualTo("test"));
            Assert.That(deskSource.Type, Is.EqualTo(SourceType.Pdf));
            Assert.That(deskSource.Link, Is.EqualTo("test"));
            Assert.That(deskSource.TypeString, Is.EqualTo("pdf"));
        });
    }

    [Test]
    public void TestSourceTypeToString()
    {
        var videoSource = new Source(1, "test", "test", SourceType.Video, "test");
        var pdfLinkSource = new Source(1, "test", "test", SourceType.PdfLink, "test");
        var videoLinkSource = new Source(1, "test", "test", SourceType.VideoLink, "test");
        var imageSource = new Source(1, "test", "test", SourceType.Image, "test");
        Assert.Multiple(() =>
        {
            Assert.That(videoSource.TypeString, Is.EqualTo("video"));
            Assert.That(pdfLinkSource.TypeString, Is.EqualTo("pdfLink"));
            Assert.That(videoLinkSource.TypeString, Is.EqualTo("videoLink"));
            Assert.That(imageSource.TypeString, Is.EqualTo("image"));
        });


    }
}