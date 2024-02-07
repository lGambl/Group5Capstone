using StudyWeb.Models;

namespace StudyHallTests.StudyWebTests.model;

[TestFixture]
public class NoteTest
{
    [Test]
    public void TestDefaultValues()
    {
        var note = new Note();
        Assert.Multiple(() =>
        {
            Assert.That(note.Id, Is.EqualTo(0));
            Assert.That(note.Text, Is.EqualTo(""));
            Assert.That(note.SourceId, Is.EqualTo(0));
            Assert.That(note.Owner, Is.EqualTo(""));
        });
    }

    [Test]
    public void TestSetValues()
    {
        var note = new Note
        {
            Id = 1,
            Text = "This is a note",
            SourceId = 1,
            Owner = "Me"
        };
        Assert.Multiple(() =>
        {
            Assert.That(note.Id, Is.EqualTo(1));
            Assert.That(note.Text, Is.EqualTo("This is a note"));
            Assert.That(note.SourceId, Is.EqualTo(1));
            Assert.That(note.Owner, Is.EqualTo("Me"));
        });
    }
}