using StudyDesk.Model;

namespace StudyHallTests.StudyDeskTests;

[TestFixture]
public class NoteTest
{
    [Test]
    public void TestNoteConstructor()
    {
        var note = new Note(1, "test", 1, "test");
        Assert.Multiple(() =>
        {
            Assert.That(note.Id, Is.EqualTo(1));
            Assert.That(note.Text, Is.EqualTo("test"));
            Assert.That(note.SourceId, Is.EqualTo(1));
            Assert.That(note.Owner, Is.EqualTo("test"));
        });
    }
}