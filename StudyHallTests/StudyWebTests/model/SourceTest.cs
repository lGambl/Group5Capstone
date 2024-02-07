using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.model;

[TestFixture]
public class SourceTest
{

    [Test]
    public void TestDefaultValues()
    {
        var source = new Source();
        Assert.Multiple(() =>
        {
            Assert.That(source.Id, Is.EqualTo(0));
            Assert.That(source.Link, Is.EqualTo(""));
            Assert.That(source.Title, Is.EqualTo(""));
            Assert.That(source.Notes, Is.Not.Null);
            Assert.That(source.Notes, Is.Empty);
            Assert.That(source.Owner, Is.EqualTo(""));

            Assert.Throws<ArgumentException>(() => source.SourceTypeToString());
            
        });
    }

    [Test]
    public void TestSourceTypeToString()
    {
        var source = new Source { Type = SourceTypes.ImageLink };
        Assert.That(source.SourceTypeToString(), Is.EqualTo("imageLink"));
        source = new Source { Type = SourceTypes.Pdf };
        Assert.That(source.SourceTypeToString(), Is.EqualTo("pdf"));
        source = new Source { Type = SourceTypes.PdfLink };
        Assert.That(source.SourceTypeToString(), Is.EqualTo("pdfLink"));
        source = new Source { Type = SourceTypes.Image };
        Assert.That(source.SourceTypeToString(), Is.EqualTo("image"));
        source = new Source { Type = SourceTypes.Video };
        Assert.That(source.TypeString, Is.EqualTo("video"));
        source = new Source { Type = SourceTypes.VideoLink };
        Assert.That(source.TypeString, Is.EqualTo("videoLink"));
    }

    [Test]
    public void TestSetters()
    {
        var source = new Source
        {
            Id = 1,
            Link = "http://www.google.com",
            Title = "Google",
            Type = SourceTypes.Image,
            Owner = "Me",
            Notes = new List<Note>()
        };
        Assert.Multiple(() =>
        {
            Assert.That(source.Id, Is.EqualTo(1));
            Assert.That(source.Link, Is.EqualTo("http://www.google.com"));
            Assert.That(source.Title, Is.EqualTo("Google"));
            Assert.That(source.Type, Is.EqualTo(SourceTypes.Image));
            Assert.That(source.Owner, Is.EqualTo("Me"));
        });
    }
}
